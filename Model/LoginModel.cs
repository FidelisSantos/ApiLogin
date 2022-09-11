namespace ApiLogin.Model
{
  public class LoginModel
  {
    public LoginModel(string Email, string Password)
    {
      this.Email = Email;
      this.Password = Password;
    }
    public LoginModel(int Registration, string Email, string Password, int AccesLevel)
    {
      this.Registration = Registration;
      this.Email = Email;
      this.Password = Password;
      this.AccesLevel = AccesLevel;
    }
    public int Registration { get; private set; }
    public string Email { get; private set; }
    public string Password { get; private set; }
    public int AccesLevel { get; private set; }
    public DateTime LastAcess { get; set; }
  }
}