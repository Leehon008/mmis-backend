using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using MMIS.DataAccessLayer.Contracts;
using System.Linq;
using MMIS.DataAccessLayer.Shared.Contracts;
using MMIS.BusinessLogicLayer.Shared.PlantData.Contract;

namespace MMIS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Microsoft.AspNetCore.Authorization.Authorize]


    public class PlantController : ControllerBase
    {
        private readonly IPlantLogic _IPlantLogic;
        private readonly IPlantRepository _Repository;

        public PlantController(IPlantLogic IPlantLogic, IPlantRepository Repository)
        {
            _IPlantLogic = IPlantLogic;
            _Repository = Repository;
        }

        /// <summary>
        /// Used to retrieve available Plants
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
 
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var res =await _Repository.GetData();
            if (res.Count != 0)
            {
                return Ok(res);
            }
            else if (res.Count == 0)
            {
                return Ok("No data exists");
            }

            return BadRequest("An error occured, Please try again.");
            
        }
    }
}