using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InventoryApplication
{
    public class Loan
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int LoanId { get; set; }

        public int UserId { get; set; }

        public int ItemId { get; set; }
 
        public virtual User User { get; set; }
        public virtual Item Item { get; set; }

        [Required]
        public DateTime DateTimeLoaned { get; set; }
        public DateTime? DateTimeReturned { get; set; } = null;
    }
}
