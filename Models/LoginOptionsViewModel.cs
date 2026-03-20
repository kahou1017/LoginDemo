namespace LoginDemo.Models;

public class LoginOptionsViewModel
{
    public string Title { get; set; } = "登入入口";

    public IReadOnlyList<LoginMethodViewModel> Methods { get; set; } =
    [
        new LoginMethodViewModel
        {
            Key = "AD",
            Name = "AD 登入",
            Description = "提供企業內部使用者透過 Active Directory 進行身分驗證。"
        },
        new LoginMethodViewModel
        {
            Key = "Password",
            Name = "帳號密碼登入",
            Description = "提供一般帳號透過系統帳號密碼進行登入。"
        }
    ];
}

public class LoginMethodViewModel
{
    public string Key { get; set; } = string.Empty;

    public string Name { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;
}
