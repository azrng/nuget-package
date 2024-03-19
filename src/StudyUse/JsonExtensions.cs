using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace StudyUse
{
    /// <summary>
    /// 官方默认的json扩展
    /// </summary>
    public static class JsonExtensions
    {
        /// <summary>
        /// 对象转json字符串
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string ToJson(this object obj)
        {
            if (obj is null)
                return null;

            var options = new JsonSerializerOptions
            {
                // 忽略只读属性
                IgnoreReadOnlyProperties = true,
                // 关闭不转义
                Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
                // 忽略循环引用
                ReferenceHandler = ReferenceHandler.IgnoreCycles,
                // 属性名不区分大小写
                PropertyNameCaseInsensitive = true,
                IgnoreNullValues = true,
            };
            return JsonSerializer.Serialize(obj, options);
        }

        /// <summary>
        /// json字符串转对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="json"></param>
        /// <returns></returns>
        public static T ToObject<T>(this string json)
        {
            var options = new JsonSerializerOptions
            {
                // 忽略只读属性
                IgnoreReadOnlyProperties = true,
                // 关闭不转义
                Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
                // 忽略循环引用
                ReferenceHandler = ReferenceHandler.IgnoreCycles,
                // 属性名不区分大小写
                PropertyNameCaseInsensitive = true,
            };
            return json == null ? default : JsonSerializer.Deserialize<T>(json, options);
        }

        /// <summary>
        /// json字符串转list
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="json"></param>
        /// <returns></returns>
        public static List<T> ToList<T>(this string json)
        {
            var options = new JsonSerializerOptions
            {
                // 忽略只读属性
                IgnoreReadOnlyProperties = true,
                // 关闭不转义
                Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
                // 忽略循环引用
                ReferenceHandler = ReferenceHandler.IgnoreCycles,
                // 属性名不区分大小写
                PropertyNameCaseInsensitive = true,
            };
            return json == null ? null : JsonSerializer.Deserialize<List<T>>(json, options);
        }
    }
}