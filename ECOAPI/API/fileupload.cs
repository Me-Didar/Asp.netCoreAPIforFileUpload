using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileProviders;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ECOAPI.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class fileupload : ControllerBase
    {

        private IHostingEnvironment _hostingEnvironment;
        public fileupload(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        public IActionResult Get()
        {
            return Ok("dd");

        }

        //------------------Product Image Upload---------------------------//
        #region Trainee Image Upload
        [HttpPost]
        [Route("uploadTraineeImage")]
        public IActionResult uploadTraineeImage(IFormFile file, string Code)
        {
            string Reply = "OP";
            string Reply2 = "OP2";
            var deleteStatus = "-1";
            try
            {
                if (file != null)
                {
                    if (file.Length > 0)
                    {
                        var fileName = Path.GetFileName(file.FileName);

                        string webRootPath = _hostingEnvironment.WebRootPath;
                        string filepath = Path.Combine(webRootPath, "DIR/TraineeImages");
                        if (!Directory.Exists(filepath))
                        {
                            deleteStatus += "-2";
                            Directory.CreateDirectory(filepath);
                        }

                        if (file.Length > 0)
                        {
                            string fullPath = Path.Combine(filepath, fileName);
                            deleteStatus += "-3";
                            deleteStatus += "-filepath=" + filepath;
                            if (System.IO.File.Exists(fullPath))
                            {
                                deleteStatus += "-4";
                                System.IO.File.Delete(fullPath);
                                deleteStatus += "-5";
                            }
                            deleteStatus += "-6";
                            var stream = new FileStream(fullPath, FileMode.Create);
                            deleteStatus += "-7";
                            file.CopyTo(stream);
                            deleteStatus += "-8";
                            stream.Dispose();
                        }
                    }
                    Reply = "Upload Complete";
                }
                Reply += deleteStatus;
            }
            catch (Exception ex)
            {
                //Reply += "-Ex Start-";
                //Reply += "-Ex ToString start -" + ex.ToString();
                //Reply += "-Ex ToString end -" + ex.ToString();
                //var msg = ex.Message.ToString() + " " + ex.InnerException.ToString();
                //Reply += "-Ex End-" + msg;
                Reply2 = deleteStatus;
                Reply2 += ex.ToString();
                //return Ok(new { Reply = ex, deleteStatus });
            }
            return Ok(new { Reply, deleteStatus, Reply2 });
            //return Ok(Reply);
        }
        #endregion

        #region Trainee Image Upload2
        [HttpPost]
        [Route("uploadTraineeImage2")]
        public IActionResult uploadTraineeImage2(IFormFile file, string Code)
        {
            string Reply = "OP";
            var deleteStatus = "-1";
            string Reply2 = "OP2";
            try
            {
                if (file != null)
                {
                    if (file.Length > 0)
                    {
                        var fileName = Path.GetFileName(file.FileName);

                        string webRootPath = _hostingEnvironment.WebRootPath;
                        string filepath = Path.Combine(webRootPath, "DIR/TraineeImages");
                        if (!Directory.Exists(filepath))
                        {
                            deleteStatus += "-2";
                            Directory.CreateDirectory(filepath);
                        }

                        if (file.Length > 0)
                        {
                            string fullPath = Path.Combine(filepath, fileName);
                            deleteStatus += "-3";
                            if (System.IO.File.Exists(fullPath))
                            {
                                deleteStatus += "-4";
                                System.IO.File.SetAttributes(fullPath, FileAttributes.Normal);////
                                deleteStatus += "-42";
                                System.IO.File.Delete(fullPath);
                                deleteStatus += "-5";
                            }
                            deleteStatus += "-6";
                            using (var stream = new FileStream(fullPath, FileMode.Create))
                            {
                                deleteStatus += "-7";
                                file.CopyTo(stream);
                                deleteStatus += "-8";
                            }
                            System.IO.File.SetAttributes(fullPath, FileAttributes.Normal);////
                        }
                    }
                    Reply = "Upload Complete";
                }
                Reply += deleteStatus;
            }
            catch (Exception ex)
            {
                Reply2 = deleteStatus;
                Reply2 += ex.ToString();
            }
            return Ok(new { Reply, deleteStatus, Reply2 });
        }
        #endregion

        #region Trainee Image Upload3
        [HttpPost]
        [Route("uploadTraineeImage3")]
        public IActionResult uploadTraineeImage3(IFormFile file, string Code)
        {
            string Reply = "OP";
            var deleteStatus = "-1";
            try
            {
                if (file != null)
                {
                    if (file.Length > 0)
                    {
                        var fileName = Path.GetFileName(file.FileName);

                        string webRootPath = _hostingEnvironment.WebRootPath; ///
                        string filepath = Path.Combine(webRootPath, "DIR", "TraineeImages");
                        if (!Directory.Exists(filepath))
                        {
                            deleteStatus += "-2";
                            Directory.CreateDirectory(filepath);
                        }

                        if (file.Length > 0)
                        {
                            string fullPath = Path.Combine(filepath, fileName);
                            deleteStatus += "-3";
                            if (System.IO.File.Exists(fullPath))
                            {
                                deleteStatus += "-4";
                                deleteStatus += "-filepath=" + filepath;
                                System.IO.File.Delete(fullPath);
                                deleteStatus += "-5";
                            }
                            deleteStatus += "-6";
                            using (var stream = new FileStream(fullPath, FileMode.Create))
                            {
                                deleteStatus += "-7";
                                file.CopyTo(stream);
                                deleteStatus += "-8";
                            }
                        }
                    }
                    Reply = "Upload Complete";
                }
                Reply += deleteStatus;
            }
            catch (Exception ex)
            {
                //Reply += "-Ex Start-";
                //Reply += "-Ex ToString start -" + ex.ToString();
                //Reply += "-Ex ToString end -" + ex.ToString();
                //var msg = ex.Message.ToString() + " " + ex.InnerException.ToString();
                //Reply += "-Ex End-" + msg;
                return Ok(new { Reply = ex, deleteStatus });
            }
            return Ok(Reply);
        }
        #endregion

        #region Career Pdf Upload
        [HttpPost]
        [Route("uploadCareerPdf")]
        public IActionResult uploadCareerPdf(IFormFile file, string Code)
        {
            string Reply = "OP";
            if (file != null)
            {
                if (file.Length > 0)
                {
                    var fileName = Path.GetFileName(file.FileName);

                    string webRootPath = _hostingEnvironment.WebRootPath;
                    string filepath = Path.Combine(webRootPath, "DIR/CVPdf");
                    if (!Directory.Exists(filepath))
                    {
                        Directory.CreateDirectory(filepath);
                    }

                    if (file.Length > 0)
                    {
                        string fullPath = Path.Combine(filepath, fileName);
                        if (System.IO.File.Exists(fullPath))
                        {
                            System.IO.File.Delete(fullPath);
                        }
                        using (var stream = new FileStream(fullPath, FileMode.Create))
                        {
                            file.CopyTo(stream);
                        }
                    }
                }
                Reply = "Upload Complete";
            }
            return Ok(Reply);
        }

        [HttpGet]
        [Route("downloadloadCareerPdf")]
        public IActionResult downloadloadCareerPdf(string fileName)
        {
            try
            {
                if (fileName != null && fileName != "")
                {


                    string webRootPath = _hostingEnvironment.WebRootPath;
                    string filepath = Path.Combine(webRootPath, "DIR", "CVPdf");
                    string fullPath = Path.Combine(filepath, fileName + ".pdf");
                    var stream = new FileStream(fullPath, FileMode.Open);
                    return File(stream, "application/pdf", fileName + ".pdf");
                }
                return BadRequest();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Product Image Upload
        [HttpPost]
        [Route("upload")]
        public IActionResult Upload(IFormFile file, string Code)
        {
            string Reply = "OP";
            if (file != null)
            {
                if (file.Length > 0)
                {
                    var fileName = Path.GetFileName(file.FileName);

                    string webRootPath = _hostingEnvironment.WebRootPath;
                    string filepath = Path.Combine(webRootPath, "DIR/Com/PBS/Product/Image");
                    if (!Directory.Exists(filepath))
                    {
                        Directory.CreateDirectory(filepath);
                    }

                    if (file.Length > 0)
                    {
                        string fullPath = Path.Combine(filepath, fileName);
                        if (System.IO.File.Exists(fullPath))
                        {
                            System.IO.File.Delete(fullPath);
                        }
                        using (var stream = new FileStream(fullPath, FileMode.Create))
                        {
                            file.CopyTo(stream);
                        }
                    }


                    string filepathDetail = Path.Combine(webRootPath, "DIR/Com/PBS/Product/ImageDetails");

                    //DIR/Com/ECO/BannerTop/main_MobilebannerTop
                    //DIR/Com/ECO/BannerTop/main_WebbannerTop

                    if (!Directory.Exists(filepathDetail))
                    {
                        Directory.CreateDirectory(filepathDetail);
                    }

                    if (file.Length > 0)
                    {
                        string fullPath = Path.Combine(filepathDetail, fileName);
                        if (System.IO.File.Exists(fullPath))
                        {
                            System.IO.File.Delete(fullPath);
                        }
                        using (var stream = new FileStream(fullPath, FileMode.Create))
                        {
                            file.CopyTo(stream);
                        }
                    }
                }
                Reply = "Upload Complete";
            }
            return Ok(Reply);
        }
        #endregion

        #region Product Image Delete
        [HttpPost]
        [Route("delete")]
        public IActionResult Delete(string Code)
        {
            string Reply = "OP";
            try
            {
                if (Code != null)
                {
                    var fileName = Code;

                    string webRootPath = _hostingEnvironment.WebRootPath;
                    string filepath = Path.Combine(webRootPath, "DIR\\Com\\PBS\\Product\\Image");
                    string fullPath = Path.Combine(filepath, fileName);
                    if (System.IO.File.Exists(fullPath))
                    {
                        System.IO.File.Delete(fullPath);
                    }

                    string filepathDetail = Path.Combine(webRootPath, "DIR\\Com\\PBS\\Product\\ImageDetails");

                    string fullPath2 = Path.Combine(filepathDetail, fileName);
                    if (System.IO.File.Exists(fullPath2))
                    {
                        System.IO.File.Delete(fullPath2);
                    }
                }
                Reply = "Delete Complete";
            }
            catch (Exception ex)
            {
                Reply = ex.ToString();
                throw;
            }
            return Ok(Reply);
        }
        #endregion

        #region Publisher Panel Upload Approve Product Image
        [HttpPost]
        [Route("UploadApproveProductImage")]
        public IActionResult UploadApproveProductImage(string code, string imageName)
        {
            string Reply = "OP";
            string webRootPath = _hostingEnvironment.WebRootPath;
            string mainFilepath = Path.Combine(webRootPath, "DIR", "PublisherPanel", "cover_images");
            string mainFullPath = Path.Combine(mainFilepath, imageName);
            if (System.IO.File.Exists(mainFullPath))
            {

                var fileName = code + ".jpg";

                string filepath = Path.Combine(webRootPath, "DIR/Com/PBS/Product/Image");
                if (!Directory.Exists(filepath))
                {
                    Directory.CreateDirectory(filepath);
                }

                string fullPath = Path.Combine(filepath, fileName);
                if (System.IO.File.Exists(fullPath))
                {
                    System.IO.File.Delete(fullPath);
                }
                System.IO.File.Copy(mainFullPath, fullPath, true);

                string filepathDetail = Path.Combine(webRootPath, "DIR/Com/PBS/Product/ImageDetails");

                if (!Directory.Exists(filepathDetail))
                {
                    Directory.CreateDirectory(filepathDetail);
                }

                string fullPathDetail = Path.Combine(filepathDetail, fileName);
                if (System.IO.File.Exists(fullPath))
                {
                    System.IO.File.Delete(fullPath);
                }
                System.IO.File.Copy(mainFullPath, fullPathDetail, true);

                Reply = "Upload Complete";
            }
            return Ok(Reply);
        }
        #endregion

        #region Publisher Panel Cover Image Upload
        [HttpPost]
        [Route("UploadCoverImage")]
        public IActionResult UploadCoverImage(IFormFile file, string Code)
        {
            string Reply = "OP";
            if (file != null)
            {
                if (file.Length > 0)
                {
                    var fileName = Path.GetFileName(file.FileName);
                    var myUniqueFileName = Convert.ToString(Guid.NewGuid());
                    var fileExtension = Path.GetExtension(fileName);
                    var newFileName = String.Concat(Code);
                    var filepath =
                    new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "DIR/PublisherPanel/cover_images")).Root + $@"\{fileName}";
                    if (System.IO.File.Exists(filepath))
                    {
                        System.IO.File.Delete(filepath);
                    }
                    using (FileStream fs = System.IO.File.Create(filepath))
                    {
                        file.CopyTo(fs);
                        fs.Flush();
                    }
                }
                Reply = "Upload Complete";
            }
            return Ok(Reply);
        }
        //----------------END -------------------//
        #endregion
        #region Publisher Panel Request Cover Image Upload
        [HttpPost]
        [Route("UploadRequestCoverImage")]
        public IActionResult UploadRequestCoverImage(IFormFile file, string Code)
        {
            string Reply = "OP";
            if (file != null)
            {
                if (file.Length > 0)
                {
                    var fileName = Path.GetFileName(file.FileName);
                    var myUniqueFileName = Convert.ToString(Guid.NewGuid());
                    var fileExtension = Path.GetExtension(fileName);
                    var newFileName = String.Concat(Code);
                    var filepath =
                    new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "DIR/PublisherPanel/request_cover_images")).Root + $@"\{fileName}";
                    if (System.IO.File.Exists(filepath))
                    {
                        System.IO.File.Delete(filepath);
                    }
                    using (FileStream fs = System.IO.File.Create(filepath))
                    {
                        file.CopyTo(fs);
                        fs.Flush();
                    }
                }
                Reply = "Upload Complete";
            }
            return Ok(Reply);
        }
        //----------------END -------------------//
        #endregion

        #region Top banner Upload
        [HttpPost]
        [Route("uploadTopBanner")]
        public IActionResult UploadTopBanner(IFormFile file, string Code)
        {
            string Reply = "OP";
            if (file != null)
            {
                if (file.Length > 0)
                {
                    var fileName = Path.GetFileName(file.FileName);

                    string webRootPath = _hostingEnvironment.WebRootPath;
                    string filepath = Path.Combine(webRootPath, "DIR/Com/ECO/BannerTop/main_WebbannerTop");
                    if (!Directory.Exists(filepath))
                    {
                        Directory.CreateDirectory(filepath);
                    }

                    if (file.Length > 0)
                    {
                        string fullPath = Path.Combine(filepath, fileName);
                        if (System.IO.File.Exists(fullPath))
                        {
                            System.IO.File.Delete(fullPath);
                        }
                        using (var stream = new FileStream(fullPath, FileMode.Create))
                        {
                            file.CopyTo(stream);
                        }
                    }
                }
                Reply = "Upload Complete";
            }
            return Ok(Reply);
        }

        [HttpPost]
        [Route("uploadTopBannerMobile")]
        public IActionResult UploadTopBannerMobile(IFormFile file, string Code)
        {
            string Reply = "OP";
            if (file != null)
            {
                if (file.Length > 0)
                {
                    var fileName = Path.GetFileName(file.FileName);

                    string webRootPath = _hostingEnvironment.WebRootPath;
                    string filepath = Path.Combine(webRootPath, "DIR/Com/ECO/BannerTop/main_MobilebannerTop");
                    if (!Directory.Exists(filepath))
                    {
                        Directory.CreateDirectory(filepath);
                    }

                    if (file.Length > 0)
                    {
                        string fullPath = Path.Combine(filepath, fileName);
                        if (System.IO.File.Exists(fullPath))
                        {
                            System.IO.File.Delete(fullPath);
                        }
                        using (var stream = new FileStream(fullPath, FileMode.Create))
                        {
                            file.CopyTo(stream);
                        }
                    }
                }
                Reply = "Upload Complete";
            }
            return Ok(Reply);
        }
        #endregion

        //------------------Author Image Upload---------------------------//
        #region Author Image Upload
        [HttpPost]
        [Route("UploadAuthor")]
        public IActionResult UploadAuthor(IFormFile file, string Code)
        {
            string Reply = "OP";
            if (file != null)
            {
                if (file.Length > 0)
                {
                    //Getting FileName
                    var fileName = Path.GetFileName(file.FileName);
                    //Assigning Unique Filename (Guid)
                    var myUniqueFileName = Convert.ToString(Guid.NewGuid());
                    //Getting file Extension
                    var fileExtension = Path.GetExtension(fileName);
                    // concatenating  FileName + FileExtension
                    // var newFileName = String.Concat(myUniqueFileName, fileExtension);
                    var newFileName = String.Concat(Code);
                    // Combines two strings into a path.
                    var filepath =
                    new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "DIR/Com/PBS/Author/Image")).Root + $@"\{fileName}";
                    if (System.IO.File.Exists(filepath))
                    {
                        System.IO.File.Delete(filepath);
                    }
                    using (FileStream fs = System.IO.File.Create(filepath))
                    {
                        file.CopyTo(fs);
                        fs.Flush();
                    }
                }
                Reply = "Upload Complete";
            }
            return Ok(Reply);
        }
        //----------------END -------------------//
        #endregion

        #region Author Image Upload Latest
        [HttpPost]
        [Route("uploadAuthorLatest")]
        public IActionResult uploadAuthorLatest(IFormFile file, string Code)
        {
            string Reply = "OP";
            if (file != null)
            {
                if (file.Length > 0)
                {
                    var fileName = Path.GetFileName(file.FileName);

                    string webRootPath = _hostingEnvironment.WebRootPath;
                    string filepath = Path.Combine(webRootPath, "DIR/Com/PBS/Author/Image");
                    if (!Directory.Exists(filepath))
                    {
                        Directory.CreateDirectory(filepath);
                    }

                    if (file.Length > 0)
                    {
                        string fullPath = Path.Combine(filepath, fileName);
                        if (System.IO.File.Exists(fullPath))
                        {
                            System.IO.File.Delete(fullPath);
                        }
                        using (var stream = new FileStream(fullPath, FileMode.Create))
                        {
                            file.CopyTo(stream);
                        }
                    }
                }
                Reply = "Upload Complete";
            }
            return Ok(Reply);
        }
        //----------------END -------------------//
        #endregion
        //---------------- Publisher Image upload----------------//
        #region Publisher Image Upload
        [HttpPost]
        [Route("UploadPublisher")]
        public IActionResult UploadPublisher(IFormFile file, string Code)
        {
            string Reply = "OP";
            if (file != null)
            {
                if (file.Length > 0)
                {
                    //Getting FileName
                    var fileName = Path.GetFileName(file.FileName);
                    //Assigning Unique Filename (Guid)
                    var myUniqueFileName = Convert.ToString(Guid.NewGuid());
                    //Getting file Extension
                    var fileExtension = Path.GetExtension(fileName);
                    // concatenating  FileName + FileExtension
                    // var newFileName = String.Concat(myUniqueFileName, fileExtension);
                    var newFileName = String.Concat(Code);
                    // Combines two strings into a path.
                    var filepath =
                    new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "DIR/Com/PBS/Publisher/Image")).Root + $@"\{fileName}";
                    if (System.IO.File.Exists(filepath))
                    {
                        System.IO.File.Delete(filepath);
                    }
                    using (FileStream fs = System.IO.File.Create(filepath))
                    {
                        file.CopyTo(fs);
                        fs.Flush();
                    }
                }
                Reply = "Upload Complete";
            }
            return Ok(Reply);
        }
        #endregion
        //----------------END -------------------//

        #region Upload Product PDF
        [HttpPost]
        [Route("uploadProductPDF")]
        public IActionResult uploadProductPDF(IFormFile file, string Code)
        {
            string Reply = "OP";
            if (file != null)
            {
                if (file.Length > 0)
                {
                    var fileName = Path.GetFileName(file.FileName);

                    string webRootPath = _hostingEnvironment.WebRootPath;
                    string filepath = Path.Combine(webRootPath, "DIR/Com/PBS/Product/PDF");
                    if (!Directory.Exists(filepath))
                    {
                        Directory.CreateDirectory(filepath);
                    }

                    if (file.Length > 0)
                    {
                        string fullPath = Path.Combine(filepath, fileName);
                        if (System.IO.File.Exists(fullPath))
                        {
                            System.IO.File.Delete(fullPath);
                        }
                        using (var stream = new FileStream(fullPath, FileMode.Create))
                        {
                            file.CopyTo(stream);
                        }
                    }
                }
                Reply = "Upload Complete";
            }
            return Ok(Reply);
        }
        #endregion

        //---------------- Test Purpose-----------//
        [HttpPost]
        [Route("uploadTest")]
        public IActionResult UploadTest(string Code)
        {
            string Reply = "OP";
            Reply = "Test Complete";
            return Ok(Reply);
        }

        //------------- New Update ---------------//
        //------------ 2024-01-25 ----------------//
        //----- To Transfer One Directory to Other --------------//
        [HttpPost]
        [Route("TransferCoverImage")]
        public IActionResult TrasnsferCoverImage(string Code)
        {
            string Reply = "Start"; 
            var newFileName = String.Concat(Code);
            // Specify the new directory where you want to move the file
            var destinationDirectory = "DIR/Com/PBS/Product/Image";
            var destinationDirectory2 = "DIR/Com/PBS/Product/ImageDetails";
            // Combine the new directory with the file name to create the new path
            var destinationFilePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", destinationDirectory, $"{newFileName}");
            var destinationFilePath2 = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", destinationDirectory2, $"{newFileName}");
            // Combine the original directory with the file name to get the source file path
            var sourceFilePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "DIR/PublisherPanel/cover_images", $"{newFileName}");         
            // Create the destination directory if it doesn't exist
            Directory.CreateDirectory(Path.GetDirectoryName(destinationFilePath));
            Directory.CreateDirectory(Path.GetDirectoryName(destinationFilePath2));
            // Move the file to the destination directory
            if (System.IO.File.Exists(destinationFilePath))
            {
                System.IO.File.Delete(destinationFilePath);
            }
            System.IO.File.Copy(sourceFilePath, destinationFilePath);
            if (System.IO.File.Exists(destinationFilePath2))
            {
                System.IO.File.Delete(destinationFilePath2);
            }
            System.IO.File.Copy(sourceFilePath, destinationFilePath2);
            Reply = "Upload and Transfer Complete";
            return Ok(Reply);
        }
    }
}
