using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlTypes;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;

namespace ExtensionProject.common.Extensions
{
    /// <summary>
    /// common extentions
    /// </summary>
    public static class CommonExtensions
    {
        public static bool Assigned(this string source)
        {
            return !String.IsNullOrEmpty(source);
        }

        public static bool Assigned(this DateTime source)
        {
            return ((DateTime)source > DateTime.MinValue);
        }

        public static bool Assigned(this Double source)
        {
            return !double.IsNaN(source);
        }

        public static bool Assigned(this object source)
        {
            if (source is DateTime) return Assigned(Convert.ToDateTime(source));
            else if (source is String) return Assigned(Convert.ToString(source));
            else if (source is double) return Assigned(Convert.ToDouble(source));
            else return ((source != null) && (source != System.DBNull.Value));
        }

        public static bool NotAssigned(this object source)
        {
            return !Assigned(source);
        }

        public static bool NotAssigned(this string source)
        {
            return !Assigned(source);
        }

        public static bool NotAssigned(this DateTime source)
        {
            return !Assigned(source);
        }

        public static bool NotAssigned(this Double source)
        {
            return !Assigned(source);
        }

        public static String RootNamespace(this Assembly source)
        {
            return source.FullName.Split(new char[] { ',' }, StringSplitOptions.None)[0];
        }

        public static bool ValidArray(this object[] o)
        {
            return ((Assigned(o)) && (o.Length > 0));
        }

        public static bool IsBaseType(this Type parent, Type child)
        {
            if (parent.Assigned() && child.Assigned())
                while (child.BaseType.Assigned())
                {
                    if (child.BaseType.Equals(parent)) return true;
                    child = child.BaseType;
                }
            return false;
        }

        public static Type ToType(this Type type)
        {
            return Nullable.GetUnderlyingType(type) ?? type;
        }

        public static string IncrementLastChar(this string word)
        {
            var lastChar = word.ToCharArray(word.Length - 1, 1)[0];
            if (lastChar == 'Z' || lastChar == 'z') return word + "a";

            lastChar = (char)(lastChar + 1);
            return word.Substring(0, word.Length - 1) + lastChar;
        }

        public static Double ToVal(this double? nullable)
        {
            return nullable.HasValue ? nullable.Value : default(Double);
        }

        public static Int16 ToVal(this short? nullable)
        {
            return nullable.HasValue ? nullable.Value : default(Int16);
        }

        public static Int32 ToVal(this int? nullable)
        {
            return nullable.HasValue ? nullable.Value : default(Int32);
        }

        public static DateTime ToVal(this DateTime? nullable)
        {
            return nullable.HasValue ? nullable.Value : new DateTime(1753, 1, 1);
        }

        public static Byte ToVal(this byte? nullable)
        {
            return nullable.HasValue ? nullable.Value : default(Byte);
        }

        public static Char ToVal(this char? nullable)
        {
            return nullable.HasValue ? nullable.Value : default(Char);
        }

        public static DateTime OnlyDate(this DateTime date)
        {
            return new DateTime(date.Year, date.Month, date.Day);
        }

        public static bool isInList(this object o, params object[] list)
        {
            return (new ArrayList(list).Contains(o));
        }

        /// <summary>
        /// Encodes string to byte array using UTF8
        /// </summary>
        public static byte[] ToUTF8ByteArray(this String source)
        {
            return ToEncodedByteArray<System.Text.UTF8Encoding>(source);
        }

        public static byte[] ToEncodedByteArray<T>(this String source)
            where T : System.Text.Encoding, new()
        {
            return (new T()).GetBytes(source);
        }

        /// <summary>
        /// Decodes byte array from string using UTF8
        /// </summary>
        public static String FromUTF8ByteArrayToStr(this Byte[] source)
        {
            return FromEncodedByteArrayToStr<System.Text.UTF8Encoding>(source);
        }

        public static String FromEncodedByteArrayToStr<T>(this Byte[] source)
            where T : System.Text.Encoding, new()
        {
            return (new T()).GetString(source, 0, source.Length);
        }

        public static string AsciiEncodeToBase64(string s)
        {
            byte[] toEncodeAsBytes = System.Text.ASCIIEncoding.ASCII.GetBytes(s);
            return System.Convert.ToBase64String(toEncodeAsBytes);
        }

        public static string AsciiDecodeFromBase64(string s)
        {
            byte[] encodedDataAsBytes = System.Convert.FromBase64String(s);
            return System.Text.ASCIIEncoding.ASCII.GetString(encodedDataAsBytes);
        }

        public static Type GetRealType(this Type genericType)
        {
            return (genericType.IsGenericType) ? genericType.GetGenericArguments().First() : genericType;
        }

        public static byte ToByte(this object value)
        {
            return Convert.ToByte(value);
        }

        public static int ToInt(this object value)
        {
            return Convert.ToInt32(value);
        }

        public static long ToLong(this object value)
        {
            return Convert.ToInt64(value);
        }

        public static double ToDouble(this object value)
        {
            if (value.NotAssigned()) return 0;
            double toReturn;
            if (Double.TryParse(value.ToString(), out toReturn)) return toReturn;
            return 0;
        }

        public static DateTime ToDateTime(this object value)
        {
            DateTime toReturn;
            if (DateTime.TryParse(value.ToString(), out toReturn)) return toReturn;
            return SqlDateTime.MinValue.Value;
        }

        public static decimal ToDecimal(this object value)
        {
            decimal toReturn;
            if (Decimal.TryParse(value.ToString(), out toReturn)) return toReturn;
            return 0;
        }

        public static List<T> ToNewList<T>(this IList list)
        {
            if (list == null)
            {
                return null;
            }
            var resultList = new List<T>();
            foreach (object item in list)
            {
                resultList.Add((T)item);
            }

            return resultList;
        }

        public static List<T> ToNewList<T>(this IEnumerator enumerator)
        {
            if (enumerator == null)
            {
                return null;
            }

            var resultList = new List<T>();
            while (enumerator.MoveNext())
            {
                resultList.Add((T)enumerator.Current);
            }

            return resultList;
        }

        public static IList ToNewList(this IEnumerator enumerator)
        {
            if (enumerator == null)
            {
                return null;
            }

            var resultList = new ArrayList();
            while (enumerator.MoveNext())
            {
                resultList.Add(enumerator.Current);
            }

            return resultList;
        }

        public static string RegexReplace(this string input, string pattern, string replacement)
        {
            return Regex.Replace(input, pattern, replacement);
        }

        /// <summary>
        /// Extracts stream content as byte array.
        /// </summary>
        /// <param name="st">Stream given to extract content as byte array</param>
        /// <returns></returns>
        public static Byte[] StreamToByteArray(this Stream st)
        {
            Byte[] result = null;
            using (MemoryStream ms = new MemoryStream())
            {
                st.Position = 0;
                st.CopyTo(ms);
                ms.Position = 0;
                result = ms.ToArray();
            }
            return result;
        }

        /// <summary>
        /// Creates a new memory stream from given byte array
        /// </summary>
        /// <param name="byteArr">Byte Array content to create stream from</param>
        /// <returns>Created memory stream object</returns>
        public static MemoryStream ToMemoryStream(this Byte[] byteArr)
        {
            return new MemoryStream(byteArr);
        }

        /// <summary>
        /// Converts stream contents to string 
        /// </summary>
        public static string StreamToStr(this MemoryStream ms)
        {
            if (ms.NotAssigned()) throw new ArgumentNullException("ms");
            //
            ms.Seek(0, SeekOrigin.Begin);
            return Convert.ToBase64String(ms.ToArray());
        }

        /// <summary>
        /// Initializes a memory stream from base64 encoded string value and set current read position to begining
        /// </summary>
        public static MemoryStream StrToStream(this String base64Value)
        {
            if (base64Value.NotAssigned()) throw new ArgumentNullException("base64Value");
            //
            var result = new MemoryStream(Convert.FromBase64String(base64Value));
            result.Seek(0, SeekOrigin.Begin);
            return result;
        }

        /// <summary>
        /// binary copy
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="input"></param>
        /// <returns></returns>
        public static T Clone<T>(this Stream input) where T : Stream, new()
        {
            T result = new T();
            byte[] buffer = new byte[2048]; // copy in 2K chunks..
            int readPos = 0;
            do
            {
                readPos = input.Read(buffer, 0, buffer.Length);
                result.Write(buffer, 0, readPos);
            } while (readPos > 0);
            return result;
        }

        public static T Value<T>(this IDictionary<String, T> list, String key)
        {
            return list.Value<T, String>(key);
        }

        public static T Value<T, TKey>(this IDictionary<TKey, T> list, TKey key)
        {
            T result = default(T);
            list.TryGetValue(key, out result);
            return result;
        }

        public static DateTime ToNetDateTime(object value)
        {
            if (value.NotAssigned()) return DateTime.MinValue;
            //
            DateTime d1 = new DateTime(1970, 1, 1);
            return d1.AddMilliseconds(Convert.ToDouble(value)).ToLocalTime();
        }

        public static String ToUnixDateTime(this DateTime dt)
        {
            DateTime d1 = new DateTime(1970, 1, 1);
            TimeSpan ts = new TimeSpan(dt.ToUniversalTime().Ticks - d1.Ticks);
            return ts.TotalMilliseconds < 0 ? String.Empty : Convert.ToInt64(ts.TotalMilliseconds).ToString();
        }

        public static String AddSfxIfSrcExists(this String source, String sfx)
        {
            return source.Assigned() ? String.Concat(source, sfx) : String.Empty;
        }

        public static String AddPfxIfSrcExists(this String source, String pfx)
        {
            return source.Assigned() ? String.Concat(pfx, source) : String.Empty;
        }

        public static IEnumerable<T> Clone<T>(T value, int count)
        {
            return Enumerable.Repeat<T>(value, count);
        }

        public static String Clone(this char value, int count)
        {
            return String.Join("", Enumerable.Repeat<char>(value, count).Select(c => c.ToString()).ToArray());
        }

        public static String FillWPrefix(this String value, char fillChar, int maxLength)
        {
            String result = value;
            int fillLength = maxLength - value.Length;
            return (maxLength > 0 && fillLength > 0) ? String.Concat(fillChar.Clone(fillLength), value) : result;
        }

        public static String FillWSuffix(this String value, char fillChar, int maxLength)
        {
            String result = value;
            int fillLength = maxLength - value.Length;
            return (maxLength > 0 && fillLength > 0) ? String.Concat(value, fillChar.Clone(fillLength)) : result;
        }

        public static Boolean IsAlphaNumeric(this Type dataType)
        {
            switch (Type.GetTypeCode(dataType.GetRealType()))
            {
                case TypeCode.Char:
                case TypeCode.String: return true;
                default: return false;
            }
        }

        public static Boolean IsPrimitiveNumericOrString(this Type type)
        {
            return type == typeof(String) || type == typeof(Decimal) || type.IsPrimitive;
        }

        public static Boolean IsBoolean(this Type dataType)
        {
            switch (Type.GetTypeCode(dataType.GetRealType()))
            {
                case TypeCode.Boolean: return true;
                default: return false;
            }
        }

        public static Boolean IsNumeric(this Type dataType)
        {
            switch (Type.GetTypeCode(dataType.GetRealType()))
            {
                case TypeCode.Decimal:
                case TypeCode.Double:
                case TypeCode.Int16:
                case TypeCode.Int32:
                case TypeCode.Int64:
                case TypeCode.SByte:
                case TypeCode.Single:
                case TypeCode.UInt16:
                case TypeCode.UInt32:
                case TypeCode.UInt64:
                case TypeCode.Byte: return true;
                default: return false;
            }
        }

        public static Boolean IsFloating(this Type dataType)
        {
            switch (Type.GetTypeCode(dataType.GetRealType()))
            {
                case TypeCode.Single:
                case TypeCode.Decimal:
                case TypeCode.Double: return true;
                default: return false;
            }
        }

        public static Boolean IsDateTime(this Type dataType)
        {
            return (dataType.GetRealType() == typeof(DateTime));
        }

        public static bool IsInterfaceSupported(this Type srcType, Type intfType)
        {
            return srcType.GetInterfaces().Any(p => p == intfType);
        }

        public static DateTime CropMilliSeconds(this DateTime source)
        {
            return new DateTime(source.Year, source.Month, source.Day, source.Hour, source.Minute, source.Second, 0);
        }

        public static DateTimeOffset CropMilliSeconds(this DateTimeOffset source)
        {
            return new DateTimeOffset(source.Year, source.Month, source.Day, source.Hour, source.Minute, source.Second, 0, source.Offset);
        }

        public static DateTime CropSeconds(this DateTime source)
        {
            return new DateTime(source.Year, source.Month, source.Day, source.Hour, source.Minute, 0);
        }

        public static DateTimeOffset CropSeconds(this DateTimeOffset source)
        {
            return new DateTimeOffset(source.Year, source.Month, source.Day, source.Hour, source.Minute, 0, source.Offset);
        }

        public static DateTime CropMinutes(this DateTime source)
        {
            return new DateTime(source.Year, source.Month, source.Day, source.Hour, 0, 0);
        }

        public static DateTimeOffset CropMinutes(this DateTimeOffset source)
        {
            return new DateTimeOffset(source.Year, source.Month, source.Day, source.Hour, 0, 0, source.Offset);
        }

        public static string ReverseString(this string str)
        {
            var arr = str.ToCharArray();
            Array.Reverse(arr);
            return new string(arr);
        }

        public static Guid ToGUID(this String guidStr)
        {
            Guid outGuid = Guid.Empty;
            return guidStr.Assigned() && Guid.TryParse(guidStr, out outGuid) ? outGuid : Guid.Empty;
        }
        /// <summary>
        /// returns url without the last slash if the app is url else returns app
        /// </summary>
        /// <param name="app">The app.</param>
        /// <returns></returns>
        public static string ReturnAbsolutePath(this string app)
        {
            if (app != null && (app.StartsWith("http", StringComparison.InvariantCultureIgnoreCase) || app.StartsWith("https", StringComparison.InvariantCultureIgnoreCase)))
            {
                var uri = new Uri(app);
                var schemeAndServer = uri.GetComponents(UriComponents.SchemeAndServer, UriFormat.UriEscaped);
                var baseUrl = string.Format("{0}/{1}", schemeAndServer, uri.Segments.Count() > 1 ? uri.Segments[1].Replace("/", string.Empty) : string.Empty);
                if (baseUrl.EndsWith("/"))
                    baseUrl = baseUrl.Remove(baseUrl.LastIndexOf("/"), 1);
                return baseUrl;
            }
            return app;
        }

        public static void SafeCall(Action execution, Action<Exception> fallback = null, string message = "")
        {
            try
            {
                execution();
            }
            catch (Exception ex)
            {
                NLogger.Instance().Error(message, ex);

                if (fallback.Assigned())
                    fallback(ex);
            }
        }


        public static T SafeCall<T>(Func<T> execution, Func<Exception, T> fallback, string message = "")
        {
            try
            {
                return execution();
            }
            catch (Exception ex)
            {
                NLogger.Instance().Error(message, ex);

                return fallback(ex);
            }
        }

        public static int GetCurrentProcessID() { return System.Diagnostics.Process.GetCurrentProcess().Id; }
        public static String GetCurrentProcessIdentityName() { return System.Security.Principal.WindowsIdentity.GetCurrent().Name; }
        public static String GetCurrentProcessName() { return System.Diagnostics.Process.GetCurrentProcess().ProcessName; }
        public static String GetMachineName() { return Environment.MachineName; }

        public static String GetMachineDomainName()
        {
            try
            {
                return System.Net.NetworkInformation.IPGlobalProperties.GetIPGlobalProperties().DomainName;
            }
            catch
            {
                return String.Empty;
            }
        }

        /// <summary>
        /// Verilen hostnamein Ipv4 adresini döner
        /// </summary>
        /// <param name="hostName"></param>
        /// <returns></returns>
        public static string GetHostIPv4Address(string hostName = "")
        {
            string result = string.Empty;
            if (hostName.ToLower() == "localhost")
                hostName = string.Empty;
            IPAddress[] addresslist = Dns.GetHostAddresses(hostName);
            foreach (IPAddress ip in addresslist)
            {
                if (ip.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                {
                    result = ip.ToString();
                    break;
                }
            }
            return result;
        }

        public static bool TryGetProcess(int pid, out Process process)
        {
            process = null;
            try
            {
                process = Process.GetProcessById(pid);
                return true;
            }
            catch { return false; }
        }

        public static Boolean ProcessIsRunning(int pid)
        {
            return (GetRunningProcess(pid)).Assigned();
        }

        public static Process GetRunningProcess(int pid)
        {
            try
            {
                return Process.GetProcessById(pid);
            }
            catch { return null; }
        }

        public static Boolean ProcessHasExited(Process process, Boolean throwUnknownEx = false)
        {
            try
            {
                if (process.NotAssigned()) throw new ArgumentNullException();
                return process.HasExited;
            }
            catch (InvalidOperationException) { return true; }
            catch (Win32Exception) { return true; }
            catch
            {
                if (throwUnknownEx) throw;
                else return true;
            }
        }

        public static Boolean ActualExceptionIs(this Exception ex, Type comparedException)
        {
            while (ex.Assigned())
            {
                var exType = ex.GetType();
                if (exType == comparedException || comparedException.IsAssignableFrom(exType))
                    return true;
                ex = ex.InnerException;
            };
            return false;
        }

        public static Boolean ActualExceptionIs<T>(this Exception ex)
            where T : Exception
        {
            return ex.ActualExceptionIs(typeof(T));
        }

        public static string Base64Encode(this string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }

        public static string Base64Decode(this string base64EncodedData, bool ifNotBase64StrReturnEncodedData = false)
        {
            try
            {
                var base64EncodedBytes = System.Convert.FromBase64String(base64EncodedData);
                return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
            }
            catch (Exception ex)
            {
                if (ifNotBase64StrReturnEncodedData)
                    return base64EncodedData;
                else
                    throw ex;
            }
        }


        public static T ReadXmlValue<T>(this XmlDocument doc, string key, T defaultValue = default(T))
        {
            try
            {
                XmlNode detailedInfo = doc.SelectSingleNode(key);

                if (detailedInfo.Assigned() && detailedInfo.InnerText.Assigned())
                {
                    if (typeof(int).IsAssignableFrom(typeof(T)))
                    {
                        return (T)(object)Convert.ToInt32(detailedInfo.InnerText);
                    }
                    if (typeof(bool).IsAssignableFrom(typeof(T)))
                    {
                        return (T)(object)Convert.ToBoolean(detailedInfo.InnerText == "1" || detailedInfo.InnerText.ToLowerInvariant() == "true" ? 1 : 0);
                    }
                    else
                    {
                        return (T)(object)Convert.ToString(detailedInfo.InnerText);
                    }
                }
                else
                    return defaultValue;
            }
            catch
            {
                return defaultValue;
            }
        }

        public static void DisposeAndNull(this IDisposable o)
        {
            if (o.Assigned())
            {
                try
                {
                    o.Dispose();
                    o = null;
                }
                catch
                {
                    //not impl.
                }
            }
        }
        public static List<Guid> ParseGuidList(string data)
        {
            List<Guid> GuidList = new List<Guid>();
            try
            {
                string[] oidList = new string[] { };

                if (data.Assigned())
                    oidList = data.Split(';');

                foreach (string oid in oidList)
                {
                    Guid cOid;
                    if (Guid.TryParse(oid, out cOid))
                        GuidList.Add(cOid);
                }
            }
            catch (Exception ex)
            {
                NLogger.Instance().Error("CommonExtensions. | CreateGuidList", ex);
            }

            return GuidList;
        }

        public static bool ValidateEmail(this string email)
        {
            string _regexPattern = @"^(([\w-]+\.)+[\w-]+|([a-zA-Z]{1}|[\w-]{2,}))@"
            + @"((([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\.([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\."
            + @"([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\.([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])){1}|"
            + @"([a-zA-Z]+[\w-]+\.)+[a-zA-Z]{2,4})$";

            return (email.Assigned() && System.Text.RegularExpressions.Regex.IsMatch(email, _regexPattern));
        }
    }
}
