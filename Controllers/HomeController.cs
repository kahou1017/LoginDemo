using System.Diagnostics;
using LoginDemo.Models;
using Microsoft.AspNetCore.Mvc;

namespace LoginDemo.Controllers;

public class HomeController : Controller
{
    [HttpGet]
    public IActionResult Index()
    {
        return View(new LoginOptionsViewModel());
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Login(string loginType)
    {
        var loginOption = loginType switch
        {
            "AD" => "Active Directory 登入流程",
            "Password" => "帳號密碼登入流程",
            _ => "未知登入流程"
        };

        TempData["LoginMessage"] = $"已選擇：{loginOption}。此頁面目前先作為登入入口示意。";
        return RedirectToAction(nameof(Index));
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
