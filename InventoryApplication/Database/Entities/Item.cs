using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace InventoryApplication
{
    public class Item
    {
        public Item()
        {
            this.Loans = new HashSet<Loan>();
        }
        [Key]
        public int ItemId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Type { get; set; }
        public string Location { get; set; }

        public virtual ICollection<Loan> Loans { get; set; }
    }
}