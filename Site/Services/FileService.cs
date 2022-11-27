using Models;
using Site.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Site.Services
{
    public class FileService
    {
        //ApplicationContext _context;
        //IWebHostEnvironment _appEnvironment;

        //        public FileService(ApplicationContext context, IWebHostEnvironment appEnvironment)
        //        {
        //            _context = context;
        //            _appEnvironment = appEnvironment;
        //        }

        //        //public IActionResult Index()
        //        //{
        //        //    return View();
        //        //}

        //        [HttpPost]
        //        public async Task<IActionResult> AddFile(IFormFile uploadedFile)
        //        {
        //            if (uploadedFile != null)
        //            {
        //                string path = "/Files/" + uploadedFile.FileName;
        //                using (var fileStream = new FileStream(_appEnvironment.WebRootPath + path, FileMode.Create))
        //                {
        //                    await uploadedFile.CopyToAsync(fileStream);
        //                }

        //                FileModel file = new FileModel { Name = uploadedFile.FileName, Path = path };
        //                _context.Files.Add(file);
        //                _context.SaveChanges();
        //            }

        //            return RedirectToAction("Index");
        //        }
    }
}