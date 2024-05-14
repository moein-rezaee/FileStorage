using FileStorage.Common;
using FileStorage.DTOs;
using FileStorage.Models;
using Microsoft.AspNetCore.Mvc;

namespace MyApp.Namespace
{
    [Route("[controller]")]
    [ApiController]
    public class FileController : ControllerBase
    {

        [HttpPost]
        public async Task<IActionResult> Add(AddDto dto)
        {
            var result = new Result();
            try
            {

                long size = dto.File.Length;
                if (dto.File.Length > 0)
                {
                    string path = "Files" + dto.Address;
                    Directory.CreateDirectory(path);

                    string[] arr = dto.File.FileName.Split(".");
                    string ext = arr[^1];
                    string? filePath = Path.Combine(path, dto.Id.ToString() + ext);

                    using var stream = System.IO.File.Create(filePath);
                    await dto.File.CopyToAsync(stream);

                    result = CustomResults.FileSaved(dto.Address + dto.Id.ToString() + ext);
                }
                else
                {
                    result = CustomErrors.FileNotSelected();
                }
                return StatusCode(result.StatusCode, result);
            }
            catch (Exception ex)
            {
                result = CustomErrors.SaveFileFailed();
                return StatusCode(result.StatusCode, result);
            }
        }

        [HttpDelete]
        public IActionResult Delete(string address)
        {
            var result = new Result();
            try
            {
                string path = Path.Combine("Files", address);
                if (System.IO.File.Exists(path))
                {
                    System.IO.File.Delete(path);
                    result = CustomResults.FileRemoved();
                } 
                else
                {
                    result = CustomErrors.FileNotFound();
                }

                return StatusCode(result.StatusCode, result);
            }
            catch (Exception ex)
            {
                result = CustomErrors.RemoveFileFailed();
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

    }

}


