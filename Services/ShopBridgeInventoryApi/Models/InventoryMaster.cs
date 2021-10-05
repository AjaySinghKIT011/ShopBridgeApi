using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ShopBridgeInventoryApi.Models
{
    public class InventoryMaster
    {
        [Key]
        [Required]
        public int ItemId { get; set; }

        [Required(ErrorMessage = "Item Name is reuired"), MaxLength(100)]
        public string ItemName { get; set; }

        [Required(ErrorMessage = "Item Description is reuired"), MaxLength(1000)]
        public string Description { get; set; }

        [Required(ErrorMessage = "Item Description is reuired"), Range(1, 100)]      
        public decimal Price { get; set; }
        public string CreatedBy { get; set; }

        public string ModifiedBy { get; set; }

        public bool IsDeleted { get; set; }

    }
}
