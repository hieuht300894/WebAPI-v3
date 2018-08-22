using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Common.Models
{
    public class Method
    {
        public string Name { get; set; }
        public string Text { get; set; }
        public MethodInfo InvokeMethod { get; set; }

        /// <summary>
        /// If method is static, set target is null. otherwise target is not null
        /// </summary>
        /// <param name="target"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public bool ExecuteMethod(object target, object[] args)
        {
            try
            {
                InvokeMethod?.Invoke(target, args);
                return true;
            }
            catch (Exception ex)
            {
                Log.Error(MethodBase.GetCurrentMethod(), ex);
                return false;
            }
        }

        /// <summary>
        /// Execute method is defined. If method is static, set target is null. otherwise target is not null
        /// </summary>
        /// <param name="mInfo"></param>
        /// <param name="target"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public bool ExecuteMethod(MethodInfo mInfo, object target, object[] args)
        {
            try
            {
                mInfo?.Invoke(target, args);
                return true;
            }
            catch (Exception ex)
            {
                Log.Error(MethodBase.GetCurrentMethod(), ex);
                return false;
            }
        }
    }
}
