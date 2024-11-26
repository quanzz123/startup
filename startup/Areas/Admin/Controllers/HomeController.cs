using Microsoft.AspNetCore.Mvc;
using startup.Utilities;

namespace startup.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        [Area("Admin")]
        public IActionResult Index()
        {
            //kiểm tra trạng thái đăng nhập
            if (!Functions.IsLogin())
            {
                return RedirectToAction("Index", "Login");
            }
            return View();
        }
    }
}
