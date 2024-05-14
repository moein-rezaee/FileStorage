using FileStorage.Models;

namespace FileStorage.Common
{
    public class CustomResults
    {
        public static Result FileSaved(object data) => new()
        {
            Message = new()
            {
                Fa = "ذخیره فایل با موفقیت انجام شد",
                En = "File Saved"
            },
            StatusCode = StatusCodes.Status201Created,
            Data = data
        };

        public static Result FileRemoved() => new()
        {
            Message = new()
            {
                Fa = "حذف فایل با موفقیت انجام شد",
                En = "File Removed"
            },
            StatusCode = StatusCodes.Status200OK,
        };

    }
}