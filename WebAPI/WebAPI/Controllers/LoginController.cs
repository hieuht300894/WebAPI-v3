using System.Web.Http;
using WebAPI.BLL;
using WebAPI.Models.EF;
using WebAPI.Models.OtherEF;

namespace WebAPI.Controllers
{
    public class LoginController : BaseController<xAccount>
    {
        public LoginController(UnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        [HttpPost]
        public IHttpActionResult SignIn(LoginRequest login)
        {
            bool IsValid = true;

            if (login == null)
            {
                ModelState.AddModelError("", "Đăng nhập không thành công.");
                IsValid = false;
            }
            if (login.Username.IsEmpty())
            {
                ModelState.AddModelError(nameof(login.Username), "Vui lòng nhập tài khoản.");
                IsValid = false;
            }
            if (login.Password.IsEmpty())
            {
                ModelState.AddModelError(nameof(login.Password), "Vui lòng nhập mật khẩu.");
                IsValid = false;
            }

            if (IsValid)
            {
                clsEnum.fLogin res = Instance.CheckLogin(login.Username, login.Password);
                switch (res)
                {
                    case clsEnum.fLogin.NotFound:
                        ModelState.AddModelError("", "Tài khoản không tồn tại.");
                        goto default;
                    case clsEnum.fLogin.Disable:
                        ModelState.AddModelError("", "Tài khoản đã bị khóa.");
                        goto default;
                    case clsEnum.fLogin.Success:
                        return Ok();
                    default:
                        return BadRequest(ModelState);
                }
            }
            return BadRequest(ModelState);
        }
    }
}