using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using API.Common;
using API.Services;
using Core.Interfaces.Common;
using System;
using System.IO;
using System.Net;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace API.Controllers.Common
{
    [Route("api/Common/[controller]")]
    [ApiController]
    public class UploadsController : Controller
    {
        public UploadsController()
        {

        }

        [HttpPost(Name = "Upload/{type}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Upload([FromForm] IFormFile Files, string type)
        {
            try
            {
                ResponseObject resObject;
                var newFileName = string.Empty;
                if (HttpContext.Request.Form.Files != null)
                {
                    var fileName = string.Empty;
                    var files = HttpContext.Request.Form.Files;
                    foreach (var file in files)
                    {
                        if (file.Length > 0)
                        {
                            //Getting FileName
                            fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                            //Getting file Extension
                            var FileExtension = Path.GetExtension(fileName);
                            if (string.IsNullOrWhiteSpace(type))
                            {

                                resObject = new ResponseObject { MessageTitle = "Folder Name (type) not Sent", Data = null };
                                return Json(resObject);
                            }

                            string paths = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot", @"Uploads\" + type);
                            if (!Directory.Exists(paths))
                                Directory.CreateDirectory(paths);

                            newFileName = fileName.ToLower().Replace(FileExtension, "") + "_" +
                                   DateTime.Now.ToString("ddMMMyyhhmmsstt") + FileExtension;
                            fileName = paths + $@"\{newFileName}";

                            using (FileStream fs = System.IO.File.Create(fileName))
                            {
                                await file.CopyToAsync(fs);
                                fs.Flush();
                            }
                        }
                    }
                }

                resObject = new ResponseObject
                {
                    MessageTitle = "Uploaded Successfully",
                    Data = newFileName
                   
                };

                return Json(resObject);
            }

            catch (Exception e)
            {
                string msg = ConstantProps.InternalServerError("Uploads");
                var resObject = new ResponseObject { MessageDescription = BuiltMessages.BuiltMessage(e, LoggingEvents.GetItem), MessageTitle = msg };
                return Json(resObject);
            }
        }

        [HttpPut(Name = "Upload/{type}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> RenameUpload(string type, string originalFileName, string newFileName)
        {


            if (string.IsNullOrWhiteSpace(type))
            {
                string msg = "Folder Name not Sent >> ";
                return StatusCode((int)HttpStatusCode.InternalServerError, msg);
            }

            string paths = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot", @"Uploads\" + type);
            string fileName = paths + $@"\{originalFileName}";
            var file = System.IO.File.Open(fileName, FileMode.Open);
            var newFile_Name = paths + $@"\{newFileName}";
            using (FileStream fs = System.IO.File.Create(newFile_Name))
            {
                await file.CopyToAsync(fs);
                fs.Flush();
            }
            return StatusCode((int)HttpStatusCode.Created);
        }

        [HttpDelete(Name = "DeleteUpload")]

        public IActionResult DeleteUpload(string filePath)
        {
            try
            {
                ResponseObject resObject;
                string paths = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot", @"Uploads\" + filePath);
                if (System.IO.File.Exists(paths))
                {
                    System.IO.File.Delete(paths);
                }
                else
                {
                    resObject = new ResponseObject
                    {
                        MessageTitle = ConstantProps.dataNotFoundText,
                        Data = filePath
                    };
                    return Json(resObject);
                }
                resObject = new ResponseObject
                {
                    MessageTitle = ConstantProps.DeletedSuccessfullyText,                    
                    Data = filePath
                };
                return Json(resObject);
            }

            catch (Exception e)
            {
                string msg = ConstantProps.InternalServerError("Delete");
                var resObject = new ResponseObject
                {
                    MessageDescription = BuiltMessages.BuiltMessage(e, LoggingEvents.GetItem),
                    MessageTitle = msg
                };
                return Json(resObject);
            }
        }
    }
}
