using ShopBridgeInventoryApi.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopBridgeInventoryApi.Repositories
{
    public interface IInventoryMasterRepository
    {
        Task<IEnumerable<InventoryMasterDto>> GetInventories();
        Task<InventoryMasterDto> GetInventory(int itemId);
        Task<InventoryMasterDto> UpdateInventory(InventoryMasterDto inventoryMasterDto);
        Task<InventoryMasterDto> CreateInventory(InventoryMasterDto inventoryMasterDto);
        Task<bool> DeleteInventory(int itemId);

    }
}
