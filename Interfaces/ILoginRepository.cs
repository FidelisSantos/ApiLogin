using ApiLogin.Model;
using ApiLogin.Request;

namespace ApiLogin.Interfaces
{
  public interface ILoginRepository
  {
    List<LoginModel> AllLogins();
    bool LoginIsValid(LoginModel login);
  }
}