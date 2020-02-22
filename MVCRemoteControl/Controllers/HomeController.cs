using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.Mvc;

namespace MVCRemoteControl.Controllers
{
    public class HomeController : Controller
    {
        [DllImport("user32", CharSet = CharSet.Auto)]
        static extern IntPtr SendMessage(IntPtr hWnd, UInt32 Msg, IntPtr wParam, IntPtr lParam);

        [DllImport("kernel32")]
        static extern IntPtr GetConsoleWindow();

        const UInt32 WM_APPCOMMAND = 0x0319;
        const UInt32 APPCOMMAND_VOLUME_DOWN = 9;
        const UInt32 APPCOMMAND_VOLUME_UP = 10;

        static void IncreaseVolume(int vol)
        {
            var cw = GetConsoleWindow();
            SendMessage(cw, WM_APPCOMMAND, cw, new IntPtr(APPCOMMAND_VOLUME_DOWN << 16));
        }

        public ActionResult Index()
        {
            return View();
        }

        public JsonResult AjaxPostCall(int volume)
        {
            IncreaseVolume(volume);

            return Json(volume);
        }

    }
}