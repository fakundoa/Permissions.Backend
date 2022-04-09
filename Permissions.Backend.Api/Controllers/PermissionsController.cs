using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Permissions.Backend.Contract.Dtos;
using Permissions.Backend.Contract.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Permissions.Backend.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PermissionsController : ControllerBase
    {
        private IPermissionsService _permissionsService;

        public PermissionsController(IPermissionsService permissionsService)
        {
            _permissionsService = permissionsService;
        }


        [HttpGet]
        public IActionResult GetPermissions()
        {
            return Ok(_permissionsService.GetPermissions());
        }

        
        [HttpGet("{id}")]
        public IActionResult GetPermission(int id)
        {
            try
            {
                return Ok(_permissionsService.GetPermission(id));
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
           
        }

        [HttpGet]
        [Route("~/api/PermissionsTypes")]
        public IActionResult GetPermissionsTypes()
        {
            return Ok(_permissionsService.GetPermissionTypes());
        }

        [HttpPost]
        public IActionResult Post([FromBody] PermissionDTO permission)
        {
            try
            {
                if(ModelState.IsValid)
                    _permissionsService.SavePermission(permission);

                return Ok("Operación realiazada con éxito.");
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }                    
        }

        
        [HttpPut]
        public IActionResult Put([FromBody] PermissionDTO permission)
        {
            try
            {
                if (ModelState.IsValid)
                    _permissionsService.UpdatePermission(permission);

                return Ok("Operación realiazada con éxito.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _permissionsService.Delete(id);

                return Ok("Operación realiazada con éxito.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }
    }
}
