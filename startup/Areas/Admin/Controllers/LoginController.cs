using Microsoft.AspNetCore.Mvc;
using startup.Areas.Admin.Models;
using startup.Models;
using startup.Utilities;

namespace startup.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class LoginController : Controller
    {
        private readonly DataContext _context;
        public LoginController(DataContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(AdminUser user)
        {
            if (user == null)
            {
                return NotFound();
            }
            //mã hoá mật khẩu trước khi kiểm tra
            string pw = Functions.MD5Password(user.Password);
            //kiểm tra sự tồn tại của email trong csdl
            var check = _context.AdminUsers.Where(m => (m.Email == user.Email) && (m.Password == pw)).FirstOrDefault();
            if (check == null)
            {
                //hiển thị thông báo
                Functions._Message = "Invalid UseName or Password";

                return RedirectToAction("Index", "Login");
            }
            //vào trang Admin nếu dúng userName và PW
            Functions._Message = string.Empty;
            Functions._UserID = check.UserID;
            Functions._UserName = string.IsNullOrEmpty(check.UserName) ? string.Empty : check.UserName;
            Functions._Email = string.IsNullOrEmpty(check.Email) ? string.Empty : check.Email;
            return RedirectToAction("Index", "Home");
        }
    }
}
