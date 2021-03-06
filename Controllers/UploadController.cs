using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCAsyncFileUpload.Controllers
{
    public class UploadController : Controller
    {
        // GET: Upload
        public ActionResult AsyncUpload()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AsyncUpload(IEnumerable<HttpPostedFileBase> files)
        {
            int count = 0;
            if (files != null)
            {
                foreach (var file in files)
                {
                    if (file != null && file.ContentLength > 0)
                    {
                        var fileName = Guid.NewGuid() + Path.GetExtension(file.FileName);
                        var path = Path.Combine(Server.MapPath("~/UploadedFiles"), fileName);
                        file.SaveAs(path);
                        count++;
                    }
                }
            }
            return new JsonResult { Data = "Successfully " + count + " file(s) uploaded" };
        }

    }
}