using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopBridgeInventoryApi.Models.Dtos
{
    public class InventoryMasterDto
    {      
        public int ItemId { get; set; }
      
        public string ItemName { get; set; }
       
        public string Description { get; set; }
     
        public decimal Price { get; set; }

        public string CreatedBy { get; set; }

        public string ModifiedBy { get; set; }

        public bool IsDeleted { get; set; }
    }
}
