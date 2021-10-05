using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ShopBridgeInventoryApi.Models;
using ShopBridgeInventoryApi.Models.Dtos;

namespace ShopBridgeInventoryApi
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<InventoryMasterDto, InventoryMaster>();
                config.CreateMap<InventoryMaster, InventoryMasterDto>();
            });

            return mappingConfig;
        }
    }
}
