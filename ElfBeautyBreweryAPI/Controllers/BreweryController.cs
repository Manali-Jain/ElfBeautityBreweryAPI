﻿
using BusinessEntities;
using BusinessLogics.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ElfBeautyBreweryAPI.Controllers
{
    [ApiController]
    [Route("v{apiVersion:apiVersion}/api/[controller]")]
    [ApiVersion("1.0")]
    public class BreweryController : ControllerBase
    {
        private IBreweryManager _breweryManager;


        #region Custructor        
        public BreweryController(IBreweryManager breweryManager)
        {
            _breweryManager = breweryManager;
        }
        #endregion

        #region Method

        /// <summary>
        /// Provide all Breweries List
        /// </summary>
        /// <param></param>
        /// <returns>Return Breweries List</returns>
        [HttpGet("GetAll")]
        [Authorize]
        public async Task<IActionResult> GetAll()
        {
            var response = await _breweryManager.GetAllBreweriesList();
            return Ok(response);
        }


        /// <summary>
        /// Search from Breweries List along with sorted column and order
        /// </summary>
        /// <param></param>
        /// <returns>Return Breweries List</returns>
        [HttpPost("Search")]
        [Authorize]
        public async Task<IActionResult> Search([FromBody] BreweriesSearchRequestModel searchRequestModel)
        {
            var breweries = await _breweryManager.SearchBreweries(searchRequestModel);
            return Ok(breweries);
        }

        /// <summary>
        /// find the matched data from serach string, used for autocomplete drop down
        /// </summary>
        /// <param></param>
        /// <returns>Return Breweries List</returns>
        [HttpGet("Autocomplete")]
        [Authorize]
        public async Task<IActionResult> Autocomplete([FromQuery] string search)
        {
            var breweries = await _breweryManager.AutocompleteBreweries(search);
            return Ok(breweries);
        }

        #endregion


    }
}
