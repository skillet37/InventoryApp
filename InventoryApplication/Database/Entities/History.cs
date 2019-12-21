using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InventoryApplication
{
    public class History
    {
        [Key, Column(Order = 0)]
        public int HistoryId { get; set; }
        [Key, Column(Order = 1)]
        public int UserId { get; set; }
        [Key, Column(Order = 2)]
        public int ItemId { get; set; }
    }
}
