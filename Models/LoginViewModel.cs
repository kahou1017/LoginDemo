using System.ComponentModel.DataAnnotations;

namespace LoginDemo.Models;

public class LoginViewModel
{
    public string Title { get; set; } = "一般帳號密碼登入";

    [Required(ErrorMessage = "請輸入帳號。")]
    [Display(Name = "帳號")]
    public string Username { get; set; } = "demo";

    [Required(ErrorMessage = "請輸入密碼。")]
    [DataType(DataType.Password)]
    [Display(Name = "密碼")]
    public string Password { get; set; } = "1234";

    public string HintMessage { get; set; } = "展示版本固定使用 demo / 1234 登入。";
}
