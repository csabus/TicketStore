using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TicketStore.API.Dto;
using TicketStore.Domain;

namespace TicketStore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IMapper _mapper;

        public AccountController(UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            IMapper mapper)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _mapper = mapper;
        }

        [HttpPost("register")]
        public async Task<ActionResult<ApplicationUser>> Register(RegisterUserRequest registerUserRequest)
        {
            var applicationUser = _mapper.Map<RegisterUserRequest, ApplicationUser>(registerUserRequest);

            var result = await _userManager.CreateAsync(applicationUser, registerUserRequest.Password);
            if(result.Succeeded)
            {
                applicationUser = await _userManager.FindByNameAsync(applicationUser.Username);
                return Ok(applicationUser);
            } 

            /*if (result.Succeeded)
            {
                applicationUserIdentity = await _userManager.FindByNameAsync(applicationUserCreate.Username ?? "");

                var applicationUser = new ApplicationUser
                {
                    ApplicationUserId = applicationUserIdentity.ApplicationUserId,
                    Username = applicationUserIdentity.Username,
                    Email = applicationUserIdentity.Email,
                    Fullname = applicationUserIdentity.Fullname,
                    Token = _tokenService.CreateToken(applicationUserIdentity)
                };

                return Ok(applicationUser);
            }*/

            return BadRequest(result.Errors);
        }

    }
}
