using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TicketStore.API.Dto.Account;
using TicketStore.Domain;
using TicketStore.Service.Abstractions;

namespace TicketStore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ITokenService _tokenService;
        private readonly IMapper _mapper;

        public AccountController(UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            ITokenService tokenService,
            IMapper mapper)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenService = tokenService;
            _mapper = mapper;
        }

        [HttpPost("register")]
        public async Task<ActionResult<AuthenticatedUser>> Register(RegisterUserRequest registerUserRequest)
        {
            var applicationUser = _mapper.Map<RegisterUserRequest, ApplicationUser>(registerUserRequest);

            var result = await _userManager.CreateAsync(applicationUser, registerUserRequest.Password);
            if(result.Succeeded)
            {
                applicationUser = await _userManager.FindByNameAsync(applicationUser.Username);
                
                var authenticatedUser = _mapper.Map<ApplicationUser, AuthenticatedUser>(applicationUser);
                authenticatedUser.Token = _tokenService.CreateToken(applicationUser);
                
                return Ok(authenticatedUser);
            } 

            return BadRequest(result.Errors);
        }

        [HttpPost("login")]
        public async Task<ActionResult<AuthenticatedUser>> Login(LoginUserRequest loginUserRequest)
        {
            var applicationUser = await _userManager.FindByNameAsync(loginUserRequest.Username ?? "");

            if (applicationUser != null)
            {
                var result = await _signInManager.CheckPasswordSignInAsync(applicationUser, loginUserRequest.Password, false);
                if (result.Succeeded)
                {
                    var authenticatedUser = _mapper.Map<ApplicationUser, AuthenticatedUser>(applicationUser);
                    authenticatedUser.Token = _tokenService.CreateToken(applicationUser);
                    
                    return Ok(authenticatedUser);
                }
            }

            return Unauthorized("Invalid login attempt.");
        }


    }
}
