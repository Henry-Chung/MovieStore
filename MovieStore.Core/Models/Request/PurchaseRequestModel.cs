using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Security.Principal;
using System.Text;

namespace MovieStore.Core.Models.Request
{
    public class PurchaseRequestModel
    {
        public PurchaseRequestModel()
        {
            PurchaseNumber = Guid.NewGuid();
            PurchaseDate = DateTime.UtcNow;
        }

        public int UserId { get; set; }
        public int MovieId { get; set; }
        
        public Guid? PurchaseNumber { get; set; }
        public decimal? TotalPrice { get; set; }
        public DateTime? PurchaseDate { get; set; }
    }
}
