using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KybalionSoft.Api.Controllers.V1
{
    [Route("v1/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {

        public async Task<IActionResult> Get()
        {
            try
            {
                var model = new List<string> { "erik","danna","lia", "sophia"};
                if (model.Count() > 0)
                {
                    return Ok(model);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {                
                return BadRequest(ex);
            }
        }

    }
}
