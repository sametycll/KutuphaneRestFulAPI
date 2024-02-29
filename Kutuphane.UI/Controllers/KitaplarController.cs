using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Kutuphane.UI.Controllers
{
    [Authorize(Roles ="Admin")]
    public class KitaplarController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
