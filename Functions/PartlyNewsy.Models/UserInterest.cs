using System;
namespace PartlyNewsy.Models
{
    public class UserInterest
    {
        public string NewsCategoryName { get; set; }
        public DateTime DateAdded => DateTime.UtcNow;
    }
}
