using System.Reflection;
using Aspose.Drawing;
using Aspose.Drawing.Imaging;
using TagCloud.Utils.ResultPattern;

namespace TagCloud.Utils.Extensions;

public static class StringExtensions
{
    public static Result<ImageFormat> ConvertToImageFormat(this string str)
    {
        return Result
            .Of(() => typeof(ImageFormat)
                .GetProperty(str, BindingFlags.Public | BindingFlags.Static | BindingFlags.IgnoreCase)
                ?.GetValue(null) as ImageFormat)
            .Then(format => format is null ? Result.Fail<ImageFormat>($"Формат {str} недоступен") : format);
    }

    public static Result<FontFamily> ParseFontFamily(this string str)
    {
        return Result
            .Of(() => new FontFamily(str))
            .ReplaceError(_ => $"В системе не обнаружено шрифта {str}");
    }
}