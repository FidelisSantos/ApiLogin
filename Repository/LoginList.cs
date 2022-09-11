using ApiLogin.Interfaces;
using ApiLogin.Model;

namespace ApiLogin.Repository
{
  public class LoginList : ILoginRepository
  {
    private static List<LoginModel> LoginModel = new List<LoginModel>();
    public List<LoginModel> AllLogins()
    {
      if (!LoginModel.Any())
      {
        AddDefaultLogins();
      }
      return LoginModel;
    }

    public bool LoginIsValid(LoginModel Login)
    {
      if (!LoginModel.Any())
      {
        AddDefaultLogins();
      }
      var ComparatePassword = FindPerson(Login.Email);
      ComparatePassword.LastAcess = DateTime.UtcNow;
      return ComparatePassword.Password == Login.Password ? true : false;
    }
    private LoginModel FindPerson(string Email)
    {
      var SearchLogin = LoginModel.FirstOrDefault(Login => Login.Email == Email);
      return SearchLogin != null ? SearchLogin : throw new Exception("Login ou senha incorretos");
    }
    public void AddDefaultLogins()
    {
      var vitor = new LoginModel(1, "vitorfidelissantos@gmail.com", "test", 1);
      LoginModel.Add(vitor);
    }
  }
}