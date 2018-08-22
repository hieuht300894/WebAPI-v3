using NLog;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class Log
    {
        static Logger logger = NLog.LogManager.GetCurrentClassLogger();

        public static void Debug(params object[] values)
        {
            string text = string.Join(" ", values.Where(x => x != null).Select(x => x.ToString()).ToArray());
            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic.Add("Time", DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"));
            dic.Add("Type", Define.fLog.Debug.ToString());
            dic.Add("Values", values);
            logger.Debug(dic.SerializeObjectToJson());
        }
        public static void Debug(MethodBase mBase, params object[] values)
        {
            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic.Add("Time", DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"));
            dic.Add("Type", Define.fLog.Debug.ToString());
            dic.Add("Method", $"{mBase.ReflectedType.FullName}.{mBase.Name}");
            dic.Add("Values", values);
            logger.Debug(dic.SerializeObjectToJson());
        }

        public static void Error(Exception ex)
        {
            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic.Add("Time", DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"));
            dic.Add("Type", Define.fLog.Error.ToString());
            dic.Add("Exception", ex);
            logger.Error(dic.SerializeObjectToJson());
        }
        public static void Error(MethodBase mBase, Exception ex)
        {
            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic.Add("Time", DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"));
            dic.Add("Type", Define.fLog.Error.ToString());
            dic.Add("Method", $"{mBase.ReflectedType.FullName}.{mBase.Name}");
            dic.Add("Exception", ex);
            logger.Error(dic.SerializeObjectToJson());
        }
    }
}
