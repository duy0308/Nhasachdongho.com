using Models.EF;
using System;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Facebook;
using System.Configuration;
using System.Net;
using Microsoft.Owin.Security;

namespace M1SHOP.Controllers
{
    public class AccountController : dbController
    {
        
        
        public ActionResult Index()
        {
            if (Request.Cookies["User"] != null)
            {
                ViewBag.Id = Request.Cookies["User"].Values["Id"];
                ViewBag.Password = Request.Cookies["User"].Values["Pw"];
            }
            return View();
        }
        
        //LOGIN FACEBOOK
      
        [AllowAnonymous]
        public ActionResult LoginFacebook()
        {
            var fb = new FacebookClient();
            var loginUrl = fb.GetLoginUrl(new
            {
                client_id = "530227913843175",
                client_secret = "982cccb8d900b7f61159aaf2dee86545",
                redirect_uri = RedirectUri.AbsoluteUri,
                response_type = "code",
                scope = "email",
            });
            return Redirect(loginUrl.AbsoluteUri);
        }
        public ActionResult FacebookCallback(string code)
        {
            if (code != null)
            {
                string accessCode = code;

                var fb = new FacebookClient();

                // throws OAuthException 
                dynamic result = fb.Post("oauth/access_token", new
                {
                    client_id = "530227913843175",
                    client_secret = "982cccb8d900b7f61159aaf2dee86545",
                    redirect_uri = RedirectUri.AbsoluteUri,
                    code = accessCode
                });

                var accessToken = result.access_token;
                var expires = result.expires;

                // Store the access token in the session
                Session["AccessToken"] = accessToken;

                // update the facebook client with the access token 
                fb.AccessToken = accessToken;

                // Calling Graph API for user info
                dynamic me = fb.Get("me?fields=id,name,birthday,email");
                string id = me.id; // You can store it in the database
                string email = me.email;
                string userName = me.email;
                string birthday = me.birthday;
            }

           
            return View();
        }
        private Uri RedirectUri
        {
            get
            {
                var uriBuilder = new UriBuilder(Request.Url);
                uriBuilder.Query = null;
                uriBuilder.Fragment = null;
                uriBuilder.Path = Url.Action("FacebookCallback");
                return uriBuilder.Uri;
            }
        }
        public ActionResult LoginGoogle()
        {

            return View();
        }

        public ActionResult Login()
        {
            if(Session["User"] != null)
            {
                return RedirectToAction("Index","Home");
            }
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(String username, String Password, Boolean Remember)
        {
            var matkhau = Password.ToMD5();
            if(username == "")
            {
                return View();
            }
            /***********************************************/
            var users = db.M1Custumers.Where(u=>u.UserName == username).ToList();
            foreach (var user in users)
            {
                if (user == null)
                {
                    ModelState.AddModelError("", "Sai tên đăng nhập !");
                }
                else if (user.Password != matkhau)
                {
                    ModelState.AddModelError("", "Sai mật khẩu !");
                }
                else
                {
                    ModelState.AddModelError("", "Đăng nhập thành công !");

                    // Duy trì thông tin user trong session
                    Session["User"] = user;
                    Session["orderID"] = user.ID;

                    // Ghi nhớ tài khoản bằng cookie
                    var ckUser = new HttpCookie("User");
                    if (Remember)
                    {
                        ckUser.Values["username"] = username;
                        ckUser.Values["Id"] = user.ID.ToString();
                        ckUser.Values["Pw"] = matkhau;
                        ckUser.Expires = DateTime.Now.AddDays(30);
                    }
                    else
                    {
                        ckUser.Expires = DateTime.Now.AddDays(-1);
                    }
                    Response.Cookies.Add(ckUser);

                    // Quay lại trang yêu cầu trước đó
                    if (Session["ReturnUrl"] != null)
                    {
                        Response.Redirect(Session["ReturnUrl"].ToString());
                    }
                    return RedirectToAction("Index", "Home");
                }
            }
            return View();
        }

        [XAuthorize]
        public ActionResult Logoff()
        {
            Session.Remove("User");
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Register()
        {
            //ViewBag.idTinhthanh = new SelectList(db.Tinhthanhs, "idT", "Ten");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(M1Custumers model, string MatkhauNhaplai)
        {
            //Kiêrm tra mật khẩu
            if (model.Password != MatkhauNhaplai)
            {
                ModelState.AddModelError("", "Mật khẩu nhập lại không khớp với nhau !");
                //ViewBag.idTinhthanh = new SelectList(db.Tinhthanhs, "idT", "Ten", model.idTinhthanh);
                return View(model);
            }
            /********************************/
            var user = db.M1Custumers.Where(u => u.UserName == model.UserName).ToList();
            if (user.Count == 0)
            {
                if (ModelState.IsValid)
                {
                    model.Password = MatkhauNhaplai.ToMD5();
                    model.CreatedDate = DateTime.Now;
                    model.Status = false;
                    model.GroupID = 2;
                    db.M1Custumers.Add(model);
                    db.SaveChanges();
                    return RedirectToAction("Login");
                }
            }
            else
            {
                ModelState.AddModelError("", "Tên đăng nhập đã có người sử dụng !");
            }
            //ViewBag.idTinhthanh = new SelectList(db.Tinhthanhs, "idT", "Ten", model.idTinhthanh);
            return View(model);


        }

        public ActionResult Activate(String Id)
        {
            //db.M1Custumers.Find(Id.FromBase64()).Status = 1;
            //db.SaveChanges();
            return RedirectToAction("Login");
        }

        public ActionResult Forgot()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Forgot(String Id, String Email)
        {
            //var user = db.M1Custumers.Find(Id);
            //if (user == null)
            //{
            //    ModelState.AddModelError("", "Sai tên đăng nhập");
            //}
            //else if (user.Email != Email)
            //{
            //    ModelState.AddModelError("", "Sai tên địa chỉ email");
            //}
            //else
            //{
            //    XMailer.Send(Email, "Your password", user.Password);
            //    ModelState.AddModelError("", "Mật khẩu đã được gửi qua email");
            //}
            return View();
        }

        [XAuthorize]
        public ActionResult Change()
        {
            return View();
        }
        [HttpPost, XAuthorize]
        public ActionResult Change(String Id, String Password, String Password1, String Password2)
        {
            if (Password1 != Password2)
            {
                ModelState.AddModelError("", "Xác nhận mật khẩu mới không đúng");
            }
            else
            {
                var user = db.M1Custumers.Find(Id);
                if (user == null)
                {
                    ModelState.AddModelError("", "Sai tên đăng nhập");
                }
                else if (user.Password != Password)
                {
                    ModelState.AddModelError("", "Sai mật khẩu cũ");
                }
                else
                {
                    user.Password = Password1;
                    db.SaveChanges();
                    ModelState.AddModelError("", "Đổi mật khẩu thành công");
                }
            }
            return View();
        }

        [XAuthorize]
        public ActionResult EditProfile()
        {
            var model = Session["User"] as M1Custumers;
            return View(model);
        }
        [HttpPost, XAuthorize]
        public ActionResult EditProfile(M1Custumers model)
        {
            
            try
            {
                db.Entry(model).State = EntityState.Modified;
                db.SaveChanges();
                ModelState.AddModelError("", "Cập nhật thành công");
                // Cập nhật lại session
                Session["User"] = model;
            }
            catch
            {
                ModelState.AddModelError("", "Cập nhật thất bại");
            }
            return View(model);
        }
        
    }
}