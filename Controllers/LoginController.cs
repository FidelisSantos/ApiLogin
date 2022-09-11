using ApiLogin.Attributes;
using ApiLogin.Interfaces;
using ApiLogin.Model;
using ApiLogin.Request;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace ApiLogin.Controller
{
  [Route("login")]
  [ApiController]
  [ApiKey]
  public class LoginController : ControllerBase
  {
    private readonly IMapper _mapper;
    private ILoginRepository repository;

    public LoginController(IMapper mapper, ILoginRepository repository)
    {
      this.repository = repository;
      _mapper = mapper;
    }

    [HttpPost]
    public IActionResult UserLogin([FromBody] LoginRequest request)
    {
      var Model = _mapper.Map<LoginModel>(request);
      return repository.LoginIsValid(Model) ? Ok("Liberado Acesso") : BadRequest("Login ou senha incorreta");
    }
    [Route("all")]
    [HttpGet]
    public IActionResult AllLogin()
    {
      var Logins = repository.AllLogins();
      return Ok(Logins);
    }
  }
}