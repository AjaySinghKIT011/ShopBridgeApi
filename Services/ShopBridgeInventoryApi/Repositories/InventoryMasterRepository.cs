using AutoMapper;
using ShopBridgeInventoryApi.DbContexts;
using ShopBridgeInventoryApi.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShopBridgeInventoryApi.Models;
using Microsoft.EntityFrameworkCore;

namespace ShopBridgeInventoryApi.Repositories
{
    public class InventoryMasterRepository : IInventoryMasterRepository
    {
        private readonly ApplicationDbContext _db;
        private IMapper _mapper;

        public InventoryMasterRepository(ApplicationDbContext db, IMapper mapper)
        {
            this._db = db;
            this._mapper = mapper;
        }

        public async Task<InventoryMasterDto> UpdateInventory(InventoryMasterDto inventoryMasterDto)
        {
            InventoryMaster item = _mapper.Map<InventoryMasterDto, InventoryMaster>(inventoryMasterDto);
            if (item.ItemId > 0)
            {
                _db.InventoryMasters.Update(item);
                await _db.SaveChangesAsync();
            }
           
            return _mapper.Map<InventoryMaster, InventoryMasterDto>(item);
        }

        public async Task<InventoryMasterDto> CreateInventory(InventoryMasterDto inventoryMasterDto)
        {
            InventoryMaster item = _mapper.Map<InventoryMasterDto, InventoryMaster>(inventoryMasterDto);
           
            _db.InventoryMasters.Add(item);
           
            await _db.SaveChangesAsync();
            return _mapper.Map<InventoryMaster, InventoryMasterDto>(item);
        }

        public async Task<bool> DeleteInventory(int itemId)
        {
            try
            {
                InventoryMaster item = await _db.InventoryMasters.FirstOrDefaultAsync(u => u.ItemId == itemId);
                if (item == null)
                {
                    return false;
                }
               
                _db.InventoryMasters.Remove(item);
                await _db.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<IEnumerable<InventoryMasterDto>> GetInventories()
        {
            List<InventoryMaster> itemListList = await _db.InventoryMasters.ToListAsync();
            return _mapper.Map<List<InventoryMasterDto>>(itemListList);
        }

        public async Task<InventoryMasterDto> GetInventory(int itemId)
        {
            InventoryMaster item = await _db.InventoryMasters.Where(x => x.ItemId == itemId).FirstOrDefaultAsync();
            return _mapper.Map<InventoryMasterDto>(item);
        }
    }
}
