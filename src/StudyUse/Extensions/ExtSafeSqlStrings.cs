using System.Text.RegularExpressions;

namespace StudyUse.Extensions
{
    public class ExtSafeSqlStrings
    {
        #region 检测是否有Sql危险字符

        /// <summary>
        /// 检测是否有Sql危险字符
        /// </summary>
        /// <param name="str">要判断字符串</param>
        /// <returns>判断结果</returns>
        public static bool IsSafeSqlString(string str)
        {
            return !Regex.IsMatch(str, @"[-|;|,|\/|\(|\)|\[|\]|\}|\{|%|@|\*|!|\']");
        }

        /// <summary>
        /// 检查危险字符
        /// </summary>
        /// <param name="Input"></param>
        /// <returns></returns>
        public static string Filter(string sInput)
        {
            if (string.IsNullOrEmpty(sInput))
                return null;
            var sInput1 = sInput.ToLower();
            var output = sInput;
            var pattern = @"*|and|exec|insert|select|delete|update|count|master|truncate|declare|char(|mid(|chr(|'";
            if (Regex.Match(sInput1, Regex.Escape(pattern), RegexOptions.Compiled | RegexOptions.IgnoreCase).Success)
            {
                throw new Exception("字符串中含有非法字符!");
            }

            output = output.Replace("'", "''");

            return output;
        }

        /// <summary> 
        /// 检查过滤设定的危险字符
        /// </summary>
        /// <param name="word"></param>
        /// <param name="inText">要过滤的字符串 </param> 
        /// <returns>如果参数存在不安全字符，则返回true </returns> 
        public static bool SqlFilter(string word, string inText)
        {
            if (inText == null)
                return false;
            foreach (var i in word.Split('|'))
            {
                if (inText.ToLower().IndexOf(i + " ", StringComparison.Ordinal) > -1 ||
                    inText.ToLower().IndexOf(" " + i, StringComparison.Ordinal) > -1)
                {
                    return true;
                }
            }

            return false;
        }

        #endregion

        #region 过滤特殊字符

        /// <summary>
        /// 过滤特殊字符
        /// </summary>
        /// <param name="Input"></param>
        /// <returns></returns>
        public static string Htmls(string Input)
        {
            if (!string.IsNullOrEmpty(Input))
            {
                var ihtml = Input.ToLower();
                ihtml = ihtml.Replace("<script", "&lt;script");
                ihtml = ihtml.Replace("script>", "script&gt;");
                ihtml = ihtml.Replace("<%", "&lt;%");
                ihtml = ihtml.Replace("%>", "%&gt;");
                ihtml = ihtml.Replace("<$", "&lt;$");
                ihtml = ihtml.Replace("$>", "$&gt;");
                return ihtml;
            }

            return string.Empty;
        }
        

        #endregion
    }
}