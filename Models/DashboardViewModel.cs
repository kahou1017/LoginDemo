namespace LoginDemo.Models;

public class DashboardViewModel
{
    public string Title { get; set; } = "Dashboard";

    public string Username { get; set; } = string.Empty;

    public DateTime LoginTime { get; set; }
}
