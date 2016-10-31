using ADMINSITE.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace ADMINSITE.Controllers
{
    public class AccountController : dbController
    {
        // GET: Account
        [XAdmin]
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Login(String uUserName, String uPassword)
        {
            const string verifyUrl = "https://www.google.com/recaptcha/api/siteverify";
            const string secret = "6LenOScTAAAAAMLOuk_L6ub8mLhc8VmSRt7juT9U";
            var response = Request["g-recaptcha-response"];
            var remoteIp = Request.ServerVariables["REMOTE_ADDR"];
            var myParameters = String.Format("secret={0}&response={1}&remoteip={2}", secret, response, remoteIp);

            using (var wc = new WebClient())
            {
                wc.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";
                var json = wc.UploadString(verifyUrl, myParameters);
                var js = new DataContractJsonSerializer(typeof(RecaptchaResult));
                var ms = new MemoryStream(Encoding.ASCII.GetBytes(json));
                var result = js.ReadObject(ms) as RecaptchaResult;
                if (result != null && result.Success) // SUCCESS!!!
                {
                    string matkhau = uPassword.ToMD5();
                    var master = db.M1Masters.Find(uUserName);
                    if(master == null)
                    {
                        ModelState.AddModelError("", "Sai tên đăng nhập !");
                    }
                    else if (master.Password != matkhau)
                    {
                        ModelState.AddModelError("", "Sai mật khẩu !");
                    }
                    else
                    {
                        Session["Master"] = master;  //Tạo một Session chứa thông tin đăng nhập cho account Admin
                        Session["User"] = master.UserName;
                        return RedirectToAction("Index", "Home");
                    }
                }
            }
            return View();
            
        }
        public ActionResult MD5(string id)
        {
            if (id != null)
            {
                ViewBag.ChuoiMD5 = id.ToMD5();
            }
            return View();
        }
    }
}