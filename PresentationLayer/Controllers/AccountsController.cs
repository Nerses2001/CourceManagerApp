using BusinessLayer.IService;
using Microsoft.AspNetCore.Mvc;
using Model;

namespace PresentationLayer.Controllers
{
    [Produces("application/json")]
    [Consumes("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase 
    {
        private readonly ICustomIdentityUserService _userService;
        //private readonly string controller = "Accounts";
        public AccountsController(ICustomIdentityUserService service)
        {
            this._userService = service;
        }

        [HttpPost("/Auth/Register")]
        [ProducesResponseType(typeof(UserManagerResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(UserManagerResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        public async Task<ActionResult<UserManagerResponse>> RegisterAsync([FromBody] RegisterModel model)
        {
            try
            {
                ActionResult<UserManagerResponse> result;
                if (!RegexUtilities.IsValidEmail(model.Email))
                {
                    ModelState.AddModelError("Email", "EmailInvalid");
                    result = UnprocessableEntity(ModelState.SelectMany(x => x.Value!.Errors).ToList());

                }
                else
                {
                    var response = await _userService.RegisterUserAsync(model);
                    if (response != null)
                        result = Ok(response);
                    else
                        result = BadRequest(response);
                }
                return result;
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
