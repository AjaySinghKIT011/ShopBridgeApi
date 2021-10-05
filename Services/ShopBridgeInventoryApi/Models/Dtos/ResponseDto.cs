using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopBridgeInventoryApi.Models.Dtos
{
    public class ResponseDto
    {        
        public bool IsSuccess { get; set; } = true;
        public object Result { get; set; }
        public string DisplayMessage { get; set; } = "";
        public string ErrorMessage { get; set; }
        
    }
}
