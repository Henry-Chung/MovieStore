using MovieStore.Core.Entities;
using MovieStore.Core.Models.Request;
using MovieStore.Core.Models.Response;
using MovieStore.Core.RepositoryInterfaces;
using MovieStore.Core.ServiceInterfaces;
using MovieStore.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MovieStore.Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly ICryptoService _cryptoService;
        private readonly IMovieService _movieService;
        private readonly IPurchaseRepository _purchaseRepository;
        private readonly IReviewRepository _reviewRepository;
        private readonly IFavoriteRepository _favoriteRepository;

        public UserService(IUserRepository userRepository, ICryptoService cryptoService, IMovieService movieService, IPurchaseRepository purchaseRepository, IReviewRepository reviewRepository, IFavoriteRepository favoriteRepository)
        {
            _userRepository = userRepository;
            _cryptoService = cryptoService;
            _movieService = movieService;
            _purchaseRepository = purchaseRepository;
            _reviewRepository = reviewRepository;
            _favoriteRepository = favoriteRepository;
        }

        public async Task<Movie> CheckTheMovieIsFavorite(int userId, int movieId)
        {
            var movies = await _movieService.CheckTheMovieIsFavorite(userId, movieId);
            return movies;
        }

        public async Task<Review> CreateReview(Review review)
        {
            var isExist = await _reviewRepository.GetExistsAsync(r => r.MovieId == review.MovieId && r.UserId == review.UserId);
            if (isExist)
            {
                return await _reviewRepository.UpdateAsync(review);
            }
            return await _reviewRepository.AddAsync(review);  
        }

        public async Task Favorite(Favorite favorite)
        {
            var isExist = await _favoriteRepository.GetExistsAsync(f => f.MovieId == favorite.MovieId && f.UserId == favorite.UserId);
            if (isExist)
            {
                await _favoriteRepository.DeleteAsync(favorite);
            }
            else
            {
                await _favoriteRepository.AddAsync(favorite);
            }
            
        }

        public async Task<Purchase> Purchase(PurchaseRequestModel purchaseRequestModel)
        {
            var movie = await _movieService.GetMovieById(purchaseRequestModel.MovieId);
            var p = new Purchase
            {
                UserId = purchaseRequestModel.UserId,
                PurchaseNumber = purchaseRequestModel.PurchaseNumber.Value,
                TotalPrice = movie.Price.Value,
                MovieId = purchaseRequestModel.MovieId,
                PurchaseDateTime = purchaseRequestModel.PurchaseDate.Value,
            };
            return await _purchaseRepository.AddAsync(p);
        }

        public async Task<UserRegisterResponseModel> RegisterUser(UserRegisterRequestModel requestModel)
        {
            // Step 1 : Check whether this user already exists in the database
            var dbUser = await _userRepository.GetUserByEmail(requestModel.Email);
            if (dbUser != null)
            {
                // we already have this user(email) in our table
                // return or throw an exception saying Conflict user
                throw new Exception("User already registered, Please try to Login");
            }
            // Step 2 : lets Generate a random unique Salt
            var salt = _cryptoService.GenerateSalt();
            // Never ever craete your own Hashing Algorithm, always use Industry tested/tried Hashing Algorithm
            // Step 3: we  hash the password with the salt created in the above step
            var hashedPassword = _cryptoService.HashPassword(requestModel.Password, salt);
            // craete User object so that we can save it to User Table
            var user = new User
            {
                Email = requestModel.Email,
                Salt = salt,
                HashedPassword = hashedPassword,
                FirstName = requestModel.FirstName,
                LastName = requestModel.LastName
            };
            // Step 4: Save it to Database
            var createdUser = await _userRepository.AddAsync(user);
            var response = new UserRegisterResponseModel
            {
                Id = createdUser.Id,
                Email = createdUser.Email,
                FirstName = createdUser.FirstName,
                LastName = createdUser.LastName
            };
            return response;
        }

        public async Task<UserLoginResponseModel> ValidateUser(string email, string password)
        {
            // Step 1 : Get user record from the databse by email;
            var user = await _userRepository.GetUserByEmail(email);
            if (user == null)
            {
                // user does not even exists
                throw new Exception("Register first, user does not exists");
            }
            // Step 2: we need to hash the password that user entered in the npage with Salt from the database from step1
            var hashedPassword = _cryptoService.HashPassword(password, user.Salt);
            // Step 3 : Compare the databse hashed password with Hashed passowrd genereated in step 2
            if (hashedPassword == user.HashedPassword)
            {
                // user entred right password
                // send some user details
                var response = new UserLoginResponseModel
                {
                    Id = user.Id,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    DateOfBirth = user.DateOfBirth,
                    Email = user.Email
                };
                return response;
            }
            return null;
        }


    }
}

