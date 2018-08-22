using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Common.Models
{
    public class CustomMethod : Method
    {
        public Type ControlType { get; set; }
        public MethodInfo AddControl { get; set; }
        public MethodInfo GetControl { get; set; }
        public MethodInfo SaveData { get; set; }
    }
}
