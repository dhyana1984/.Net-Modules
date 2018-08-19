public ActionResult Upload()
        {
            string message = "";
            HttpPostedFileBase file = Request.Files["file1"];
            if (System.IO.Path.GetExtension(file.FileName).ToLower() != ".zip")
            {
                message = "只能上传ＺＩＰ格式的压缩文件。";
                return RedirectToAction("Index", new { zipFile = "", message });
            }
            else
            {
                string filePath = System.IO.Path.Combine(HttpContext.Server.MapPath("../Uploads"), System.IO.Path.GetFileName(file.FileName));
                file.SaveAs(filePath);
                message = "上传成功";
                return RedirectToAction("Index", new { zipFile= filePath,message});
            }
        }