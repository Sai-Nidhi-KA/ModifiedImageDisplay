using ImageUpload.Models;
using ImageUpload.Respository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ImageUpload.Controllers
{
    public class UploadimageController : Controller
    {
        private EmployeeRepository StudentRep;

        public UploadimageController()
        {
            StudentRep = new EmployeeRepository();
        }

        // GET: Uploadimage
        public ActionResult Index()
        {

            EmployeeRepository StudentRep = new EmployeeRepository();
            return View(StudentRep.GetStudents());
        }

        private bool IsImage(HttpPostedFileBase Photo)
        {
            if (Photo != null && Photo.ContentLength > 0)
            {
                string[] allowedImageTypes = { "image/jpeg", "image/png", "image/gif" };
                string contentType = Photo.ContentType;

                return allowedImageTypes.Contains(contentType);
            }
            return false;
        }

        public ActionResult Details()
        {
            return View();
        }
        public ActionResult Insert()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Insert(ImageModel imageModel, HttpPostedFileBase image)
        {
            EmployeeRepository StudentRepo=new EmployeeRepository();
            StudentRepo.Insert(imageModel, image);
            return RedirectToAction("Index");
        }



    }
}