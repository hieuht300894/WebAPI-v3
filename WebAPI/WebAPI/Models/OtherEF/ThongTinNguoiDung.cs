using WebAPI.Models.EF;

namespace WebAPI.Models.OtherEF
{
    public class ThongTinNguoiDung
    {
        public xPersonnel xPersonnel { get; set; } = new xPersonnel();
        public xAccount xAccount { get; set; } = new xAccount();
    }

}
