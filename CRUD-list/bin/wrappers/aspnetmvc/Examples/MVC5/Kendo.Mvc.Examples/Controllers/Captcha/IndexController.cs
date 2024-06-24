using Kendo.Mvc.Examples.Models;
using Kendo.Mvc.Examples.Models.Form;
using Kendo.Mvc.UI;
using System;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web.Mvc;

namespace Kendo.Mvc.Examples.Controllers
{
    public partial class CaptchaController : Controller
    {
        private const string contentFolderRoot = "~/Content/";
        private string captchaPath = Path.Combine(contentFolderRoot, "UserFiles", "Captcha");

        [Demo]
        public ActionResult Index(CaptchaModel captchaModel)
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

            return View(new UserViewModel()
            {
                FirstName = "John",
                LastName = "Doe",
                Email = "john.doe@email.com",
                UserName = "johny",
                Password = "123456"
            });
        }

        public ActionResult Reset()
        {
            var newCaptcha = GetCaptcha();

            return Json(new CaptchaModel
            {
                Captcha = Url.Content("~/Content/UserFiles/Captcha/" + newCaptcha.CaptchaID + ".png"),
                CaptchaID = newCaptcha.CaptchaID
            }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Audio(string captchaId)
        {
            return Content(Url.Content("~/Content/UserFiles/Captcha/" + captchaId + ".wav"), "audio/wav");
        }

        public ActionResult Validate(CaptchaModel model)
        {
            IsCaptchaValid(model.CaptchaID, model.Captcha);

            return Json(IsCaptchaValid(model.CaptchaID, model.Captcha), JsonRequestBehavior.AllowGet);
        }

        private CaptchaModel GetCaptcha()
        {
            var model = new CaptchaModel();
            Random rnd = new Random();
            var path = Server.MapPath(captchaPath);
            var files = Directory.GetFiles(path).ToList();
            var randomCaptchaID = Path.GetFileNameWithoutExtension(files[rnd.Next(files.Count)]);

            model.CaptchaID = randomCaptchaID;
            model.Captcha = Url.Content("~/Content/UserFiles/Captcha/" + randomCaptchaID + ".png");

            string captchaText = System.IO.File.ReadAllText(files.First(x => x.Contains($"{randomCaptchaID}.txt")));
            Session["captcha" + model.CaptchaID] = captchaText;

            return model;
        }

        private string GetCaptchaText(string captchaId)
        {
            string text = (string)Session["captcha" + captchaId];

            return text;
        }

        private bool IsCaptchaValid(string captchaId, string captcha)
        {
            string text = GetCaptchaText(captchaId);

            return text == captcha.ToUpperInvariant();
        }
    }
}