using ApiLogin.Model;
using ApiLogin.Request;
using AutoMapper;

namespace ApiLogin.Mapper
{
  public class LoginMapper : Profile
  {
    public LoginMapper()
    {
      CreateMap<LoginRequest, LoginModel>()
          .ReverseMap();
    }
  }
}