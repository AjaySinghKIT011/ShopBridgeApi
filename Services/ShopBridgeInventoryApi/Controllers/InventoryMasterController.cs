using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShopBridgeInventoryApi.Models.Dtos;
using ShopBridgeInventoryApi.Repositories;


namespace ShopBridgeInventoryApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventoryMasterController : ControllerBase
    {

        protected ResponseDto _response;
        private IInventoryMasterRepository _inventoryMasterRepository;

        public InventoryMasterController(IInventoryMasterRepository inventoryMasterRepository)
        {
            this._inventoryMasterRepository = inventoryMasterRepository;
            this._response = new ResponseDto();
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                IEnumerable<InventoryMasterDto> items = await _inventoryMasterRepository.GetInventories();
               
                if( items.Count< InventoryMasterDto>() == 0)
                {
                    return NotFound();
                }
                _response.Result = items;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessage = "Something went wrong! We are working on it";
                   
                return StatusCode(500, _response.ErrorMessage);
            }
            
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                InventoryMasterDto item = await _inventoryMasterRepository.GetInventory(id);

                if (item == null)
                {
                    return NoContent();
                }
                _response.Result = item;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessage = "Something went wrong! We are working on it";
                 
                return StatusCode(500, _response.ErrorMessage);
            }
           
        }


        [HttpPost]
        public async Task<IActionResult> Post([FromBody] InventoryMasterDto inventoryMasterDto)
        {
            try
            {
                InventoryMasterDto model = await _inventoryMasterRepository.CreateInventory(inventoryMasterDto);
                if (model == null)
                {
                    return NoContent();
                }
                _response.Result = model;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessage = "Something went wrong! We are working on it";
                  
                return StatusCode(500, _response.ErrorMessage);
            }
           
        }


        [HttpPut]
        public async Task<IActionResult> Put([FromBody] InventoryMasterDto inventoryMasterDto)
        {
            try
            {
                InventoryMasterDto model = await _inventoryMasterRepository.UpdateInventory(inventoryMasterDto);
                if (model == null)
                {
                    return NoContent();
                }
                _response.Result = model;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessage = "Something went wrong! We are working on it";
                 
                return StatusCode(500, _response.ErrorMessage);
            }
            
        }

        [HttpDelete]        
        [Route("{id}")]
        public async Task<object> Delete(int id)
        {
            try
            {
                bool isSuccess = await _inventoryMasterRepository.DeleteInventory(id);
                _response.Result = isSuccess;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessage = "Something went wrong! We are working on it";
                
                return StatusCode(500, _response.ErrorMessage);
            }
            
        }
    }
}
