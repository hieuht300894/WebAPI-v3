using WebAPI.Models.General;
using WebAPI.Models.Interface;

namespace WebAPI.Models.EF
{
    public class eProduct : Master, IUnit
    {
        //[NotCodepped]
        //public Color Color { get; set; }
        public int ColorHex { get; set; }
        public string ColorName { get; set; }
        public string Size { get; set; }
        public int IDUnit { get; set; }
        public string UnitCode { get; set; }
        public string UnitName { get; set; }
    }
}
