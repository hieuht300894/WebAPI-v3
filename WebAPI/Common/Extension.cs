using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace Common
{
    public static class Extension
    {
        [DllImport("kernel32.dll", EntryPoint = "AllocConsole", SetLastError = true, CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        static extern int AllocConsole();

        static FileSystemWatcher watcher = null;

        public static bool InitApp()
        {
            try
            {
                InitConfig();
                GetAppConfig();
                GetWebConfig();
                InitConsole();
                return true;
            }
            catch (Exception ex)
            {
                Log.Error(MethodBase.GetCurrentMethod(), ex);
                return false;
            }
        }
        public static bool CloseApp()
        {
            try
            {
                watcher.EnableRaisingEvents = false;
                watcher.Dispose();
                return true;
            }
            catch (Exception ex)
            {
                Log.Error(MethodBase.GetCurrentMethod(), ex);
                return false;
            }
        }
        static void InitConsole()
        {
            string val = "false";
            if (GetAppSettings("add", "key", "showConsoleLog", "value", ref val))
            {
                bool bShow = false;
                bool.TryParse(val, out bShow);
                if (bShow)
                {
                    AllocConsole();
                }
            }
        }
        static void InitConfig()
        {
            //string text = string.Empty;
            //if (!File.Exists(Define.Instance.AppConfig) && ReadText(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile, ref text))
            //{
            //    File.WriteAllText(Define.Instance.AppConfig, text);
            //}

            //watcher = watcher ?? new FileSystemWatcher();
            //watcher.Filter = Define.Instance.AppConfig;
            //watcher.NotifyFilter = NotifyFilters.LastWrite | NotifyFilters.CreationTime;
            //watcher.IncludeSubdirectories = true;
            //watcher.Path = Path.GetDirectoryName(Define.Instance.AppConfig);

            //watcher.Created -= Watcher_Created;
            //watcher.Changed -= Watcher_Changed;

            //watcher.Created += Watcher_Created;
            //watcher.Changed += Watcher_Changed;

            //watcher.EnableRaisingEvents = true;
        }
        static void Watcher_Created(object sender, FileSystemEventArgs e)
        {
            watcher.EnableRaisingEvents = false;
            GetAppConfig();
            watcher.EnableRaisingEvents = true;
        }
        static void Watcher_Changed(object sender, FileSystemEventArgs e)
        {
            watcher.EnableRaisingEvents = false;
            GetAppConfig();
            watcher.EnableRaisingEvents = true;
        }

        static void GetAppConfig()
        {
            try
            {
                Define.Instance.AppConfig.Clear();
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(Define.Instance.AppConfigPath);
                foreach (XmlNode childNode in xmlDoc.ChildNodes)
                {
                    GetAppConfig(childNode);
                }
            }
            catch (Exception ex)
            {
                Log.Error(MethodBase.GetCurrentMethod(), ex);
            }
        }
        static void GetAppConfig(XmlNode node)
        {
            foreach (XmlNode childNode in node.ChildNodes)
            {
                if (childNode.NodeType == XmlNodeType.Comment) continue;
                Define.Instance.AppConfig.Add(childNode);
                GetAppConfig(childNode);
            }
        }
        public static bool GetAppSettings(string localName, string attribute, ref string value)
        {
            XmlNode node = Define.Instance.AppConfig.FirstOrDefault(x => x.LocalName.ToEqualEx(localName));
            if (node != null && node.Attributes[attribute] != null)
            {
                value = node.Attributes[attribute].Value;
                return true;
            }
            return false;
        }
        public static bool GetAppSettings(string localName, string keyName, string keyValue, string attribute, ref string value)
        {
            XmlNode node = Define.Instance.AppConfig.FirstOrDefault(x => x.LocalName.ToEqualEx(localName) && (x.Attributes[keyName] != null && x.Attributes[keyName].Value.ToEqualEx(keyValue)));
            if (node != null && node.Attributes[attribute] != null)
            {
                value = node.Attributes[attribute].Value;
                return true;
            }
            return false;
        }
        public static bool SetAppSettings(string localName, string attributeName, string value)
        {
            try
            {
                //hrow new Exception("abc");

                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(Define.Instance.AppConfigPath);

                XmlNode node = xmlDoc.SelectSingleNode($"//{localName}[@{attributeName}]");
                if (node == null)
                    return false;

                bool IsChanged = false;
                if (!node.Attributes[attributeName].Value.ToEqualEx(value))
                {
                    IsChanged = true;
                    List<KeyValuePair<string, object>> kvs = new List<KeyValuePair<string, object>>();
                    kvs.Add(new KeyValuePair<string, object>("tag", localName));
                    kvs.Add(new KeyValuePair<string, object>("attribute", attributeName));
                    kvs.Add(new KeyValuePair<string, object>("oldValue", node.Attributes[attributeName].Value));
                    kvs.Add(new KeyValuePair<string, object>("newValue", value));
                    //Log(kvs.ToArray());
                    node.Attributes[attributeName].Value = value;
                }

                if (IsChanged)
                    xmlDoc.Save(Define.Instance.AppConfigPath);

                return true;
            }
            catch (Exception ex)
            {
                Log.Error(MethodBase.GetCurrentMethod(), ex);
                return false;
            }
        }
        static void GetWebConfig()
        {
            try
            {
                Define.Instance.WebConfig.Clear();
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(Define.Instance.WebConfigPath);
                foreach (XmlNode childNode in xmlDoc.ChildNodes)
                {
                    GetWebConfig(childNode);
                }
            }
            catch (Exception ex)
            {
                Log.Error(MethodBase.GetCurrentMethod(), ex);
            }
        }
        static void GetWebConfig(XmlNode node)
        {
            foreach (XmlNode childNode in node.ChildNodes)
            {
                if (childNode.NodeType == XmlNodeType.Comment) continue;
                Define.Instance.WebConfig.Add(childNode);
                GetWebConfig(childNode);
            }
        }
        public static bool GetWebSettings(string localName, string attribute, ref string value)
        {
            XmlNode node = Define.Instance.WebConfig.FirstOrDefault(x => x.LocalName.ToEqualEx(localName));
            if (node != null && node.Attributes[attribute] != null)
            {
                value = node.Attributes[attribute].Value;
                return true;
            }
            return false;
        }
        public static bool GetWebSettings(string localName, string keyName, string keyValue, string attribute, ref string value)
        {
            XmlNode node = Define.Instance.WebConfig.FirstOrDefault(x => x.LocalName.ToEqualEx(localName) && (x.Attributes[keyName] != null && x.Attributes[keyName].Value.ToEqualEx(keyValue)));
            if (node != null && node.Attributes[attribute] != null)
            {
                value = node.Attributes[attribute].Value;
                return true;
            }
            return false;
        }
        public static bool SetWebSettings(string localName, string attributeName, string value)
        {
            try
            {
                //hrow new Exception("abc");

                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(Define.Instance.WebConfigPath);

                XmlNode node = xmlDoc.SelectSingleNode($"//{localName}[@{attributeName}]");
                if (node == null)
                    return false;

                bool IsChanged = false;
                if (!node.Attributes[attributeName].Value.ToEqualEx(value))
                {
                    IsChanged = true;
                    List<KeyValuePair<string, object>> kvs = new List<KeyValuePair<string, object>>();
                    kvs.Add(new KeyValuePair<string, object>("tag", localName));
                    kvs.Add(new KeyValuePair<string, object>("attribute", attributeName));
                    kvs.Add(new KeyValuePair<string, object>("oldValue", node.Attributes[attributeName].Value));
                    kvs.Add(new KeyValuePair<string, object>("newValue", value));
                    //Log(kvs.ToArray());
                    node.Attributes[attributeName].Value = value;
                }

                if (IsChanged)
                    xmlDoc.Save(Define.Instance.WebConfigPath);

                return true;
            }
            catch (Exception ex)
            {
                Log.Error(MethodBase.GetCurrentMethod(), ex);
                return false;
            }
        }

        public static bool ToEqualEx(this string text1, string text2)
        {
            if (text1 == null || text2 == null)
                return false;

            text1 = text1.Trim();
            text2 = text2.Trim();
            return text1.ToLowerEx().Equals(text2.ToLowerEx(), StringComparison.CurrentCulture);
        }
        public static bool ToContainEx(this string text1, string text2)
        {
            if (text1 == null || text2 == null)
                return false;

            text1 = text1.Trim();
            text2 = text2.Trim();
            return text1.ToLowerEx().Contains(text2.ToLowerEx());
        }
        public static bool ToStartsWithEx(this string text1, string text2)
        {
            if (text1 == null || text2 == null)
                return false;

            text1 = text1.Trim();
            text2 = text2.Trim();
            return text1.ToLowerEx().StartsWith(text2.ToLowerEx());
        }
        public static string ToLowerEx(this string text)
        {
            text = text ?? string.Empty;
            return text.ToLower(CultureInfo.CurrentCulture);
        }
        public static bool IsEmpty(this string text)
        {
            text = text ?? string.Empty;
            return string.IsNullOrWhiteSpace(text.Trim());
        }
        public static bool IsNotEmpty(this string text)
        {
            text = text ?? string.Empty;
            return !string.IsNullOrWhiteSpace(text.Trim());
        }
        public static bool SplitRegex(this string text, string pattern, List<KeyValuePair<string, string>> items)
        {
            if (text.IsEmpty())
                return false;
            if (pattern.IsEmpty())
                return false;

            try
            {
                Regex regex = new Regex(pattern.Trim(), RegexOptions.ECMAScript);
                Match match = regex.Match(text.Trim());
                if (!match.Success)
                    return false;

                foreach (string gName in regex.GetGroupNames())
                {
                    Group gr = match.Groups[gName];
                    if (gr.Success)
                    {
                        if (gr.Length != match.Length)
                        {
                            items.Add(new KeyValuePair<string, string>(gName, gr.Value));
                        }
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                Log.Error(MethodBase.GetCurrentMethod(), ex);
                return false;
            }
        }

        public static void Format(this NumericUpDown number)
        {
            number.Minimum = int.MinValue;
            number.Maximum = int.MaxValue;
            number.TextAlign = HorizontalAlignment.Center;
        }
        public static void Format(this TextBox txt, bool multiline = true, int height = 50)
        {
            txt.Multiline = multiline;
            if (multiline)
            {
                txt.Height = height;
                txt.ScrollBars = ScrollBars.Both;
            }
            else
            {

            }
        }
        public static void FormatEx(this ComboBox cb, string valueMember, string displayMember)
        {
            cb.DropDownStyle = ComboBoxStyle.DropDownList;
            cb.ValueMember = valueMember;
            cb.DisplayMember = displayMember;
        }
        public static void FormatEx(this ListBox lb, string valueMember, string displayMember)
        {
            lb.ValueMember = valueMember;
            lb.DisplayMember = displayMember;
        }
        public static void Format(this ListView lv, bool fullRowSelect = true, bool checkBoxes = false)
        {
            lv.View = View.Details;
            lv.FullRowSelect = fullRowSelect;
            lv.GridLines = true;
            lv.HideSelection = false;
            lv.CheckBoxes = checkBoxes;
        }
        public static List<ListViewItem> GetSelectedItems(this ListView lv)
        {
            List<ListViewItem> items = new List<ListViewItem>(lv.SelectedItems.Cast<ListViewItem>());
            return items;
        }
        public static List<ListViewItem> GetItems(this ListView lv)
        {
            List<ListViewItem> items = new List<ListViewItem>(lv.Items.Cast<ListViewItem>());
            return items;
        }

        public static string ReadText(string path)
        {
            try
            {
                if (!File.Exists(path))
                    return string.Empty;

                return File.ReadAllText(path) ?? string.Empty;
            }
            catch (Exception ex)
            {
                Log.Error(MethodBase.GetCurrentMethod(), ex);
                return string.Empty;
            }
        }
        public static bool ReadText(string path, ref string text)
        {
            try
            {
                if (!File.Exists(path))
                    return false;

                text = File.ReadAllText(path) ?? string.Empty;
                return true;
            }
            catch (Exception ex)
            {
                Log.Error(MethodBase.GetCurrentMethod(), ex);
                return false;
            }
        }
        public static bool ReadLines(string path, ref string[] lines)
        {
            try
            {
                lines = File.ReadLines(path).ToArray();
                return true;
            }
            catch (Exception ex)
            {
                Log.Error(MethodBase.GetCurrentMethod(), ex);
                return false;
            }
        }
        public static bool ReadFirst(string path, ref string line)
        {
            try
            {
                string[] lines = new string[] { };
                if (ReadLines(path, ref lines))
                {
                    line = lines.FirstOrDefault();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                Log.Error(MethodBase.GetCurrentMethod(), ex);
                return false;
            }
        }
        public static bool ReadLast(string path, ref string line)
        {
            try
            {
                string[] lines = new string[] { };
                if (ReadLines(path, ref lines))
                {
                    line = lines.LastOrDefault();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                Log.Error(MethodBase.GetCurrentMethod(), ex);
                return false;
            }
        }
        public static bool SaveText(string path, string text)
        {
            try
            {
                File.WriteAllText(path, text);
                return true;
            }
            catch (Exception ex)
            {
                Log.Error(MethodBase.GetCurrentMethod(), ex);
                return false;
            }
        }

        public static string ShortcutPath(string path)
        {
            try
            {
                List<string> projDirectories = Environment.CurrentDirectory.Split(Path.DirectorySeparatorChar).ToList();
                List<string> pathDirectories = path.Split(Path.DirectorySeparatorChar).ToList();
                int length = projDirectories.Count;
                if (pathDirectories.Count <= length)
                {
                    return path;
                }

                int i = 0;
                for (i = 0; i < length; i++)
                {
                    if (!projDirectories[i].ToEqualEx(pathDirectories[i]))
                        break;
                }
                if (i == length)
                {
                    string _path = string.Empty;
                    for (i = length; i < pathDirectories.Count; i++)
                    {
                        _path += $"{Path.DirectorySeparatorChar}{pathDirectories[i]}";
                    }
                    return _path;
                }
                else
                {
                    return path;
                }
            }
            catch (Exception ex)
            {
                Log.Error(MethodBase.GetCurrentMethod(), ex);
                return path;
            }
        }
        public static string GetFullPath(string path)
        {
            try
            {
                string _path = path.TrimStart(Path.DirectorySeparatorChar).TrimEnd(Path.DirectorySeparatorChar);

                if (Path.GetPathRoot(_path).IsNotEmpty())
                    return path;
                else
                    return Path.Combine(Environment.CurrentDirectory, _path);
            }
            catch (Exception ex)
            {
                Log.Error(MethodBase.GetCurrentMethod(), ex);
                return path;
            }
        }

        public static object CreateInstance(this object source, object[] args)
        {
            try
            {
                Type type = source.GetType();
                return Activator.CreateInstance(type, args);
            }
            catch(Exception ex)
            {
                Log.Error(MethodBase.GetCurrentMethod(), ex);
                return null;
            }
        }

        public static object CreateInstance(this Type typeSource, object[] args)
        {
            try
            {
                return Activator.CreateInstance(typeSource, args);
            }
            catch (Exception ex)
            {
                Log.Error(MethodBase.GetCurrentMethod(), ex);
                return null;
            }
        }

        /// <summary>
        /// Clone a object
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <returns></returns>
        public static T Clone<T>(this T source)
        {
            try
            {
                var serialized = JsonConvert.SerializeObject(
                    source,
                    Newtonsoft.Json.Formatting.Indented,
                    new JsonSerializerSettings()
                    {
                        ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                    });
                return JsonConvert.DeserializeObject<T>(serialized);
            }
            catch { return JsonConvert.DeserializeObject<T>("{}"); }
        }

        /// <summary>
        /// Clone a list object
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <returns></returns>
        public static List<T> Clone<T>(this List<T> source)
        {
            var serialized = JsonConvert.SerializeObject(
                source,
                Newtonsoft.Json.Formatting.Indented,
                new JsonSerializerSettings()
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                });
            return JsonConvert.DeserializeObject<List<T>>(serialized);
        }

        /// <summary>
        /// Object to json
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <returns></returns>
        public static string SerializeObjectToJson<T>(this T source)
        {
            var serialized = JsonConvert.SerializeObject(
                source,
                Newtonsoft.Json.Formatting.Indented,
                new JsonSerializerSettings()
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                });
            return serialized;
        }

        /// <summary>
        /// List object to json
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <returns></returns>
        public static string SerializeListObjectToJson<T>(this List<T> source)
        {
            var serialized = JsonConvert.SerializeObject(
                source,
                Newtonsoft.Json.Formatting.Indented,
                new JsonSerializerSettings()
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                    DateFormatHandling = DateFormatHandling.MicrosoftDateFormat
                });
            return serialized;
        }

        /// <summary>
        /// Json to object
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <returns></returns>
        public static T DeserializeJsonToObject<T>(this string source)
        {
            try { return JsonConvert.DeserializeObject<T>(source); }
            catch { return ReflectionPopulator.CreateObject<T>(); }
        }

        /// <summary>
        /// Json to list object
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <returns></returns>
        public static List<T> DeserializeJsonToListObject<T>(this string source)
        {
            try { return JsonConvert.DeserializeObject<List<T>>(source); }
            catch { return new List<T>(); }
        }

        public static T GetObjectValueByName<T>(this object oSource, string pName)
        {
            Type convertTo = typeof(T);
            if (oSource == null) return (T)Convert.ChangeType(Activator.CreateInstance(convertTo), convertTo);
            var properties = oSource.GetType().GetProperties();
            var oRe = oSource.GetType().GetProperty(pName).GetValue(oSource, null);
            return oRe != null ? (T)Convert.ChangeType(oRe, convertTo) : (T)Convert.ChangeType(Activator.CreateInstance(convertTo), convertTo);
        }
        public static TOut Sum<TIn, TOut>(this IEnumerable<TIn> List, String Column)
        {
            Type convertTo = typeof(TOut);

            if (convertTo == typeof(Int16))
            {
                Func<TIn, Int16> columnMapper = new Func<TIn, Int16>((TIn item) => { return item.GetObjectValueByName<Int16>(Column); });
                return (TOut)Convert.ChangeType(List.DefaultIfEmpty().Sum(x => columnMapper(x)), convertTo);
            }
            if (convertTo == typeof(Int32))
            {
                Func<TIn, Int32> columnMapper = new Func<TIn, Int32>((TIn item) => { return item.GetObjectValueByName<Int32>(Column); });
                return (TOut)Convert.ChangeType(List.DefaultIfEmpty().Sum(x => columnMapper(x)), convertTo);
            }
            if (convertTo == typeof(Int64))
            {
                Func<TIn, Int64> columnMapper = new Func<TIn, Int64>((TIn item) => { return item.GetObjectValueByName<Int64>(Column); });
                return (TOut)Convert.ChangeType(List.DefaultIfEmpty().Sum(x => columnMapper(x)), convertTo);
            }
            if (convertTo == typeof(Double))
            {
                Func<TIn, Double> columnMapper = new Func<TIn, Double>((TIn item) => { return item.GetObjectValueByName<Double>(Column); });
                return (TOut)Convert.ChangeType(List.DefaultIfEmpty().Sum(x => columnMapper(x)), convertTo);
            }
            if (convertTo == typeof(Decimal))
            {
                Func<TIn, Decimal> columnMapper = new Func<TIn, Decimal>((TIn item) => { return item.GetObjectValueByName<Decimal>(Column); });
                return (TOut)Convert.ChangeType(List.DefaultIfEmpty().Sum(x => columnMapper(x)), convertTo);
            }

            return (TOut)Convert.ChangeType(Activator.CreateInstance(convertTo), convertTo);
        }
        public static IEnumerable<TIn> OrderBy<TIn, TOut>(this IEnumerable<TIn> List, String Column)
        {
            Func<TIn, TOut> columnMapper = new Func<TIn, TOut>((TIn item) => { return item.GetObjectValueByName<TOut>(Column); });
            return List.OrderBy(x => columnMapper(x)).ToList();
        }
        public static IEnumerable<TIn> OrderByDescending<TIn, TOut>(this IEnumerable<TIn> List, String Column)
        {
            Func<TIn, TOut> columnMapper = new Func<TIn, TOut>((TIn item) => { return item.GetObjectValueByName<TOut>(Column); });
            return List.OrderByDescending(x => columnMapper(x)).ToList();
        }
        public static TOut Min<TIn, TOut>(this IEnumerable<TIn> List, String Column)
        {
            Func<TIn, TOut> columnMapper = new Func<TIn, TOut>((TIn item) => { return item.GetObjectValueByName<TOut>(Column); });
            return List.DefaultIfEmpty().Min(x => columnMapper(x));
        }
        public static TOut Max<TIn, TOut>(this IEnumerable<TIn> List, String Column)
        {
            Func<TIn, TOut> columnMapper = new Func<TIn, TOut>((TIn item) => { return item.GetObjectValueByName<TOut>(Column); });
            return List.DefaultIfEmpty().Max(x => columnMapper(x));
        }
    }
}
