using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NLog;
using PracaInzynierska.Application.DTO.Category;
using PracaInzynierska.Application.Services.Category;
using PracaInzynierskaAPI.API.PoliciesAndPermissions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PracaInzynierskaAPI.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _service;
        private ILogger _logger;

        public CategoryController(ICategoryService service)
        {
            _service = service;
            _logger = LogManager.GetCurrentClassLogger();
        }

        [AllowAnonymous]
        [HttpGet("GetAllCategories")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAllCategories()
        {
            try
            {
                var serviceResponse = _service.GetAllCategories();
                if (serviceResponse.Success)
                    return await Task.FromResult(Ok(serviceResponse));
                else
                    return await Task.FromResult(BadRequest(serviceResponse));
            }
            catch (Exception err)
            {
                _logger.Error(err, "CategoryController.GetAllCategories");
            }

            return await Task.FromResult(BadRequest());
        }

        [AllowAnonymous]
        [HttpGet("GetAllCategoryById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetCategoryById(Guid id)
        {
            try
            {
                var serviceResponse = _service.GetCategoryById(id);
                if (serviceResponse.Success)
                    return await Task.FromResult(Ok(serviceResponse));
                else
                    return await Task.FromResult(BadRequest(serviceResponse));
            }
            catch (Exception err)
            {
                _logger.Error(err, "CategoryController.GetCategoryById");
            }
            return await Task.FromResult(BadRequest());
        }

        [AllowAnonymous]
        [HttpGet("FindByName")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> FindByName(string name)
        {
            List<string> list = new List<string>();
            list = name.Split(" ").ToList();
            try
            {
                var serviceResponse = _service.GetCategoriesByName(list);
                if (serviceResponse.Success)
                    return await Task.FromResult(Ok(serviceResponse));
                else
                    return await Task.FromResult(BadRequest(serviceResponse));
            }
            catch (Exception err)
            {
                _logger.Error(err, "CategoryController.FindCategoryByName");
            }

            return await Task.FromResult(BadRequest());
        }

        [Authorize(Policy = Policies.Category.Write)]
        [HttpPost("CreateCategory")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateCategory(CategoryDTO category)
        {
            try
            {
                var serviceResponse = _service.AddCategory(category);
                if (serviceResponse.Success)
                    return await Task.FromResult(Ok(serviceResponse));
                else
                    return await Task.FromResult(BadRequest(serviceResponse));
            }
            catch (Exception err)
            {
                _logger.Error(err, "CategoryController.CreateCategory");
            }

            return await Task.FromResult(BadRequest());
        }

        [Authorize(Policy = Policies.Category.Update)]
        [HttpPut("UpdateCategory")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdatedCategory(CategoryDTO category)
        {
            try
            {
                var serviceResponse = _service.UpdateCategory(category);
                if (serviceResponse.Success)
                    return await Task.FromResult(Ok(serviceResponse));
                else
                    return await Task.FromResult(BadRequest(serviceResponse));
            }
            catch (Exception err)
            {
                _logger.Error(err, "CategoryController.UpdateCategory");
            }

            return await Task.FromResult(BadRequest());
        }

        [Authorize(Policy = Policies.Category.SoftDelete)]
        [HttpDelete("SoftDeleteCategory")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> SoftDeleteCategory(CategoryDTO category)
        {
            try
            {
                var serviceResponse = _service.SoftDeleteCategory(category);
                if (serviceResponse.Success)
                    return await Task.FromResult(Ok(serviceResponse));
                else
                    return await Task.FromResult(BadRequest(serviceResponse));
            }
            catch (Exception err)
            {
                _logger.Error(err, "CategoryController.SoftDeleteCategory");
            }

            return await Task.FromResult(BadRequest());
        }

        [Authorize(Policy = Policies.Category.Delete)]
        [HttpDelete("DeleteCategory")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeleteCategory(Guid id)
        {
            try
            {
                var serviceResponse = _service.DeleteCategory(id);
                if (serviceResponse.Success)
                    return await Task.FromResult(Ok(serviceResponse));
                else
                    return await Task.FromResult(BadRequest(serviceResponse));
            }
            catch (Exception err)
            {
                _logger.Error(err, "CategoryController.DeleteCategory");
            }

            return await Task.FromResult(BadRequest());
        }
    }
}
