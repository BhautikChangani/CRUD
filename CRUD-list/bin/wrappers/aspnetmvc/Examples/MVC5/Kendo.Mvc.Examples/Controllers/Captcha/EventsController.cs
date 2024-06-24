using Kendo.Mvc.Examples.Models;
using Kendo.Mvc.Examples.Models.Form;
using System;
using System.Drawing.Imaging;
using System.IO;
using System.Web.Mvc;
using Telerik.Web.Captcha;

namespace Kendo.Mvc.Examples.Controllers
{
    public partial class CaptchaController : Controller
    {
        [Demo]
        public ActionResult Events(CaptchaModel captchaModel)
        {
            if (string.IsNullOrEmpty(captchaModel.CaptchaID))
            {
                var model = GetCaptcha();
                ViewData["Captcha"] = Url.Content("~/Content/UserFiles/Captcha/" + model.CaptchaID + ".png");
                ViewData["CaptchaID"] = model.CaptchaID;
            }
            else
            {
                string text = (string)Session["captcha" + captchaModel.CaptchaID];

                if (text != null && IsCaptchaValid(captchaModel.CaptchaID, captchaModel.Captcha))
                {
                    ModelState.Clear();
                    GetCaptcha();
                }
            }

            return View();
        }
    }
}