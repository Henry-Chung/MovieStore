using MovieStore.Core.Entities;
using MovieStore.Core.Models.Request;
using MovieStore.Core.Models.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MovieStore.Core.ServiceInterfaces
{
    public interface IUserService
    {
        Task<UserRegisterResponseModel> RegisterUser(UserRegisterRequestModel requestModel);
        Task<UserLoginResponseModel> ValidateUser(string email, string password);
        Task<Purchase> Purchase(PurchaseRequestModel purchaseRequest);
        Task<Review> CreateReview(Review review);
        Task Favorite(Favorite favorite);

        Task<Movie> CheckTheMovieIsFavorite(int userId, int movieId);
    }
}
