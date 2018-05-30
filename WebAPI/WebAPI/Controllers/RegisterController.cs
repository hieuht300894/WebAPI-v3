using WebAPI.BLL;
using WebAPI.Models;
using WebAPI.Models.EF;
using WebAPI.Models.OtherEF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Controllers
{
    public class RegisterController : BaseController<xAccount>
    {
        public RegisterController(UnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        //public override ActionResult Index()
        //{
        //    return View();
        //}

        //public ActionResult SignUp()
        //{
        //    return View();
        //}

        //[HttpPost]
        //public ActionResult SignUp(RegisterRequest register)
        //{
        //    bool IsValid = true;

        //    if (register == null)
        //    {
        //        ModelState.AddModelError("", "Đăng ký không thành công.");
        //        IsValid = false;
        //    }
        //    if (register.Username.IsEmpty())
        //    {
        //        ModelState.AddModelError(nameof(register.Username), "Vui lòng nhập tài khoản.");
        //        IsValid = false;
        //    }
        //    if (register.Password.IsEmpty())
        //    {
        //        ModelState.AddModelError(nameof(register.Password), "Vui lòng nhập mật khẩu.");
        //        IsValid = false;
        //    }
        //    if (register.ConfirmPassword.IsEmpty())
        //    {
        //        ModelState.AddModelError(nameof(register.Password), "Vui lòng nhập lại mật khẩu.");
        //        IsValid = false;
        //    }

        //    if (IsValid)
        //    {
        //        if (!register.Password.Equals(register.ConfirmPassword))
        //        {
        //            ModelState.AddModelError("", "Mật khẩu không trùng khớp.");
        //            return View("Index");
        //        }

        //        if (Instance.CheckExist(register.Username))
        //        {
        //            ModelState.AddModelError("", "Tài khoản đã tồn tại.");
        //            return View("Index");
        //        }

        //        xPersonnel personnel = new xPersonnel();
        //        personnel.CreatedDate = DateTime.Now;
        //        personnel.Status = (int)clsEnum.fStatus.Add;

        //        xAccount account = new xAccount();
        //        account.Username = register.Username;
        //        account.Password = register.Password;
        //        account.CreatedDate = DateTime.Now;
        //        account.Status = (int)clsEnum.fStatus.Add;
        //        account.IsEnable = true;

        //        try
        //        {
        //            Instance.BeginTransaction();

        //            Instance.GetRepository<xPersonnel>().AddOrUpdate(personnel);
        //            Instance.SaveChanges();

        //            account.IDPersonnel = personnel.KeyID;

        //            Instance.GetRepository<xAccount>().AddOrUpdate(account);
        //            Instance.SaveChanges();

        //            Instance.CommitTransaction();
        //        }
        //        catch
        //        {
        //            Instance.RollbackTransaction();
        //        }

        //        return RedirectToAction("SignIn", "Login", new { username = register.Username, password = register.Password });
        //    }
        //    return View("Index");
        //}
    }
}