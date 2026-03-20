using System.Diagnostics;
using LoginDemo.Models;
using Microsoft.AspNetCore.Mvc;

namespace LoginDemo.Controllers;

public class HomeController : Controller
{
    private const string DemoUsername = "demo";
    private const string DemoPassword = "1234";
    private const string AdDemoUser = "ad.demo";
    private const string UserSessionKey = "AuthenticatedUser";
    private const string LoginTimeSessionKey = "LoginTime";

    [HttpGet]
    public IActionResult Index()
    {
        if (IsLoggedIn())
        {
            return RedirectToAction(nameof(Dashboard));
        }

        return View(new LoginOptionsViewModel());
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult AdLogin()
    {
        SignInUser(AdDemoUser);
        TempData["LoginMessage"] = "AD 登入成功，已進入 Dashboard。";
        return RedirectToAction(nameof(Dashboard));
    }

    [HttpGet]
    public IActionResult PasswordLogin()
    {
        if (IsLoggedIn())
        {
            return RedirectToAction(nameof(Dashboard));
        }

        return View(new LoginViewModel());
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult PasswordLogin(LoginViewModel model)
    {
        if (IsLoggedIn())
        {
            return RedirectToAction(nameof(Dashboard));
        }

        if (!ModelState.IsValid)
        {
            return View(model);
        }

        if (!string.Equals(model.Username, DemoUsername, StringComparison.OrdinalIgnoreCase) ||
            !string.Equals(model.Password, DemoPassword, StringComparison.Ordinal))
        {
            ModelState.AddModelError(string.Empty, "帳號或密碼錯誤，請使用 demo / 1234 進行測試。");
            return View(model);
        }

        SignInUser(model.Username);
        TempData["LoginMessage"] = "一般帳號密碼登入成功。";
        return RedirectToAction(nameof(Dashboard));
    }

    [HttpGet]
    public IActionResult Dashboard()
    {
        var username = HttpContext.Session.GetString(UserSessionKey);
        if (string.IsNullOrWhiteSpace(username))
        {
            TempData["LoginMessage"] = "請先登入後再查看 Dashboard。";
            return RedirectToAction(nameof(Index));
        }

        var loginTimeText = HttpContext.Session.GetString(LoginTimeSessionKey);
        var loginTime = DateTime.TryParse(loginTimeText, out var parsedLoginTime)
            ? parsedLoginTime
            : DateTime.Now;

        return View(new DashboardViewModel
        {
            Username = username,
            LoginTime = loginTime
        });
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Logout()
    {
        HttpContext.Session.Clear();
        TempData["LoginMessage"] = "您已成功登出。";
        return RedirectToAction(nameof(Index));
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

    private void SignInUser(string username)
    {
        HttpContext.Session.SetString(UserSessionKey, username);
        HttpContext.Session.SetString(LoginTimeSessionKey, DateTime.Now.ToString("O"));
    }

    private bool IsLoggedIn()
    {
        return !string.IsNullOrWhiteSpace(HttpContext.Session.GetString(UserSessionKey));
    }
}
