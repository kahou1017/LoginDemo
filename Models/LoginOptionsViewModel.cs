namespace LoginDemo.Models;

public class LoginOptionsViewModel
{
    public string Title { get; set; } = "登入方式選擇";

    public string Description { get; set; } = "請先選擇登入方式。AD 登入目前先模擬成功，一般帳號密碼登入會切換到下一頁輸入帳號與密碼。";

    public IReadOnlyList<LoginMethodViewModel> Methods { get; set; } =
    [
        new LoginMethodViewModel
        {
            Title = "AD 登入",
            Description = "沿用原本 AD 登入入口，目前先模擬成功登入後進入 Dashboard。",
            ActionName = "AdLogin",
            SubmitLabel = "使用 AD 登入",
            IsPost = true
        },
        new LoginMethodViewModel
        {
            Title = "一般帳號密碼登入",
            Description = "切換到下一個畫面，再輸入帳號與密碼登入。",
            ActionName = "PasswordLogin",
            SubmitLabel = "前往帳密登入",
            IsPost = false
        }
    ];
}

public class LoginMethodViewModel
{
    public string Title { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public string ActionName { get; set; } = string.Empty;

    public string SubmitLabel { get; set; } = string.Empty;

    public bool IsPost { get; set; }
}
