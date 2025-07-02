using System.Globalization;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text;
using Alor.OpenAPI.Enums;

namespace Alor.OpenAPI.Utilities
{
    internal static class Utilities
    {
        internal static string ConvertToString(object? value, IFormatProvider cultureInfo)
        {
            switch (value)
            {
                case null:
                    return "";
                case Enum:
                {
                    var name = Enum.GetName(value.GetType(), value);
                    if (name != null)
                    {
                        var field = value.GetType().GetTypeInfo()
                            .GetDeclaredField(name);
                        if (field != null)
                        {
                            if (field.GetCustomAttribute(typeof(EnumMemberAttribute)) is EnumMemberAttribute attribute)
                            {
                                return attribute.Value ?? name;
                            }
                        }

                        var converted = Convert.ToString(Convert.ChangeType(value,
                            Enum.GetUnderlyingType(value.GetType()), cultureInfo));
                        return converted ?? string.Empty;
                    }

                    break;
                }
                case bool b:
                    return Convert.ToString(b, cultureInfo).ToLowerInvariant();
                case byte[] bytes:
                    return Convert.ToBase64String(bytes);
                default:
                {
                    if (value.GetType().IsArray)
                    {
                        var array = ((Array)value).OfType<object>();
                        return string.Join(",", array.Select(o => ConvertToString(o, cultureInfo)));
                    }

                    break;
                }
            }

            var result = Convert.ToString(value, cultureInfo);
            return result ?? "";
        }

        internal static void AppendQueryParam(StringBuilder urlBuilder, string paramName, object? paramValue)
        {
            if (paramValue != null)
            {
                urlBuilder.Append(
                    $"{Uri.EscapeDataString(paramName)}={Uri.EscapeDataString(Utilities.ConvertToString(paramValue, CultureInfo.InvariantCulture))}&");
            }
        }

        private static string? ConvertToBase62<T>(T? number) where T : struct, IComparable, IConvertible
        {
            if (number == null) return null;
            
            if (number.Value.CompareTo((T)Convert.ChangeType(0, typeof(T))) < 0)
                throw new ArgumentOutOfRangeException(nameof(number), "Number must be non-negative.");

            var longNumber = Convert.ToInt64(number.Value);
            const string chars = "0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";

            if (longNumber == 0) return "0";

            var result = new StringBuilder();
            while (longNumber > 0)
            {
                result.Insert(0, chars[(int)(longNumber % 62)]);
                longNumber /= 62;
            }

            return result.ToString();
        }

        internal static string GuidFormatter<T>(string subsMarker, T? number, Format? format = null) where T : struct, IComparable, IConvertible
        {
            var subsType = subsMarker;

            if (format != null)
            {
                subsType = format switch
                {
                    Format.Simple => $"{subsMarker}0",
                    Format.Slim => $"{subsMarker}1",
                    _ => $"{subsMarker}2",
                };
            }

            return $"{subsType}_{Utilities.ConvertToBase62(number)}";
        }

        internal static bool StartsWithPattern(Span<byte> sourceArray, byte[]? patternArray)
        {
            if (sourceArray == null || patternArray == null || sourceArray.Length < patternArray.Length)
            {
                return false;
            }

            for (var i = 0; i < patternArray.Length; i++)
            {
                if (sourceArray[i] != patternArray[i])
                {
                    return false;
                }
            }

            return true;
        }
    }
}
