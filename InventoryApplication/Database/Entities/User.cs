using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace InventoryApplication
{
    public class User
    {
        public User()
        {
            this.Loans = new HashSet<Loan>();
        }

        [Key]
        public string UserId { get; set; }
        [Required]
        public string Name { get; set; }
        public string Rank { get; set; } = "Not Given";
        [Required]
        public string Email { get; set; }
        [Required]
        public string Mobile { get; set; }

        public virtual ICollection<Loan> Loans { get; set; }
    }
}
