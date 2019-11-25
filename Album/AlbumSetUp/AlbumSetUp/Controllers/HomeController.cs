using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using System.IO;
using AlbumSetUp.Models;
using System.Web.Script.Serialization;


namespace AlbumSetUp.Controllers
{
    [HandleError]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {

            //var abumDetails = GetPhoto("https://jsonplaceholder.typicode.com/photos");

            var userdetails = GetUsers("https://jsonplaceholder.typicode.com/users");
            var abumdetails = GetaAlbum("https://jsonplaceholder.typicode.com/albums");
            List<Album> lstAbum = new List<Album>();
            Album objAlbum;
            int j = 1;
            for (int i = 1; i <= 5; i++)
            {
             
                var photodetais = GetPhoto("https://jsonplaceholder.typicode.com/photos?albumId=" + i + "&id=" +j).FirstOrDefault();
                objAlbum = new Album();
                objAlbum.id = photodetais.albumId;
                objAlbum.AbumthumbnailUrl = photodetais.thumbnailUrl;
                lstAbum.Add(objAlbum);
                j = j + 50;
            }
            
            var query =
               (from abum in abumdetails

                join p in lstAbum on abum.id equals p.id
                join userobj in userdetails on abum.userid equals userobj.id into sr
                from userobj in sr.DefaultIfEmpty()
                //into ps
                //from p in ps.DefaultIfEmpty()
               select new ListingClass()
               {
                   title=abum.title,
                   username=userobj.name==null?sr.FirstOrDefault().name:userobj.name,
                   phone = userobj.phone == null ? sr.FirstOrDefault().phone : userobj.phone,
                   email = userobj.email == null ? sr.FirstOrDefault().email : userobj.email,
                   firstthumpnail = p.AbumthumbnailUrl,
                   abumid=abum.id,
                   userid=userobj.id

               }).ToList();

            return View(query);
        }

        public JsonResult shownextpage(int page)
        {
            var userdetails = GetUsers("https://jsonplaceholder.typicode.com/users");
            var abumdetails = GetaAlbum("https://jsonplaceholder.typicode.com/albums");
            List<Album> lstAbum = new List<Album>();
            Album objAlbum;
            int j = (page * 50)+1-50;
            for (int i = page; i <= page+10; i++)
            {

                var photodetais = GetPhoto("https://jsonplaceholder.typicode.com/photos?albumId=" + i + "&id=" + j).FirstOrDefault();
                objAlbum = new Album();
                objAlbum.id = photodetais.albumId;
                objAlbum.AbumthumbnailUrl = photodetais.thumbnailUrl;
                lstAbum.Add(objAlbum);
                j = j + 50;
            }

            var query =
               (from abum in abumdetails

                join p in lstAbum on abum.id equals p.id
                join userobj in userdetails on abum.userid equals userobj.id into sr
                from userobj in sr.DefaultIfEmpty()
                //into ps
                //from p in ps.DefaultIfEmpty()
                select new ListingClass()
                {
                    title = abum.title,
                    username = userobj.name == null ? sr.FirstOrDefault().name : userobj.name,
                    phone = userobj.phone == null ? sr.FirstOrDefault().phone : userobj.phone,
                    email = userobj.email == null ? sr.FirstOrDefault().email : userobj.email,
                    firstthumpnail = p.AbumthumbnailUrl,
                    abumid = abum.id,
                    userid = userobj.id

                }).ToList();

            return Json(query, JsonRequestBehavior.AllowGet);
        }

        public ActionResult About()
        {
            return View();
        }

        public List<Photo> GetPhoto(string url)
        {
            var request = (HttpWebRequest)WebRequest.Create(url);

            request.Method = "GET";
            request.UserAgent = "User-Agent";
            request.AutomaticDecompression = DecompressionMethods.Deflate | DecompressionMethods.GZip;

            var content = string.Empty;

            using (var response = (HttpWebResponse)request.GetResponse())
            {
                using (var stream = response.GetResponseStream())
                {
                    using (var sr = new StreamReader(stream))
                    {
                        content = sr.ReadToEnd();
                    }
                }
            }
            System.Web.Script.Serialization.JavaScriptSerializer jsSerializer = new System.Web.Script.Serialization.JavaScriptSerializer();

            List<Photo> finalResult = jsSerializer.Deserialize<List<Photo>>(content);
            return finalResult.Take(10).ToList();
            
        }

        public List<Users> GetUsers(string url)
        {
            var request = (HttpWebRequest)WebRequest.Create(url);

            request.Method = "GET";
            request.UserAgent = "User-Agent";
            request.AutomaticDecompression = DecompressionMethods.Deflate | DecompressionMethods.GZip;

            var content = string.Empty;

            using (var response = (HttpWebResponse)request.GetResponse())
            {
                using (var stream = response.GetResponseStream())
                {
                    using (var sr = new StreamReader(stream))
                    {
                        content = sr.ReadToEnd();
                    }
                }
            }
            System.Web.Script.Serialization.JavaScriptSerializer jsSerializer = new System.Web.Script.Serialization.JavaScriptSerializer();
           // List<Users> finalResult= JsonConvert.DeserializeObject<List<Users>>(content);

            List<Users> finalResult = jsSerializer.Deserialize<List<Users>>(content);
          
            return finalResult.ToList();

        }

        public List<Posts> GetPosts(string url)
        {
            var request = (HttpWebRequest)WebRequest.Create(url);

            request.Method = "GET";
            request.UserAgent = "User-Agent";
            request.AutomaticDecompression = DecompressionMethods.Deflate | DecompressionMethods.GZip;

            var content = string.Empty;

            using (var response = (HttpWebResponse)request.GetResponse())
            {
                using (var stream = response.GetResponseStream())
                {
                    using (var sr = new StreamReader(stream))
                    {
                        content = sr.ReadToEnd();
                    }
                }
            }
            System.Web.Script.Serialization.JavaScriptSerializer jsSerializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            // List<Users> finalResult= JsonConvert.DeserializeObject<List<Users>>(content);

            List<Posts> finalResult = jsSerializer.Deserialize<List<Posts>>(content);

            return finalResult.ToList();

        }

        public List<Album> GetaAlbum(string url)
        {
            var request = (HttpWebRequest)WebRequest.Create(url);

            request.Method = "GET";
            request.UserAgent = "User-Agent";
            request.AutomaticDecompression = DecompressionMethods.Deflate | DecompressionMethods.GZip;

            var content = string.Empty;

            using (var response = (HttpWebResponse)request.GetResponse())
            {
                using (var stream = response.GetResponseStream())
                {
                    using (var sr = new StreamReader(stream))
                    {
                        content = sr.ReadToEnd();
                    }
                }
            }
            System.Web.Script.Serialization.JavaScriptSerializer jsSerializer = new System.Web.Script.Serialization.JavaScriptSerializer();

            List<Album> finalResult = jsSerializer.Deserialize<List<Album>>(content);
            return finalResult.ToList();

        }

        public JsonResult GetAlbumDetaisById(int AbumId)
        {
             var photodetais = GetPhoto("https://jsonplaceholder.typicode.com/photos?albumId="+AbumId);

             return Json(photodetais, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetUserDetaisById(int userid)
        {
            var photodetais = GetUsers("https://jsonplaceholder.typicode.com/users?id=" + userid).FirstOrDefault();

             return Json(photodetais, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetPostByUserId(int userid)
        {
            var photodetais = GetPosts("https://jsonplaceholder.typicode.com/posts?userId=" + userid);

            return Json(photodetais, JsonRequestBehavior.AllowGet);
        }

        public JsonResult getallalbum(int userid)

        {
            var url = "https://jsonplaceholder.typicode.com/users?id=" + userid;
            var request = (HttpWebRequest)WebRequest.Create(url);

            request.Method = "GET";
            request.UserAgent = "User-Agent";
            request.AutomaticDecompression = DecompressionMethods.Deflate | DecompressionMethods.GZip;

            var content = string.Empty;

            using (var response = (HttpWebResponse)request.GetResponse())
            {
                using (var stream = response.GetResponseStream())
                {
                    using (var sr = new StreamReader(stream))
                    {
                        content = sr.ReadToEnd();
                    }
                }
            }


            return Json(content, JsonRequestBehavior.AllowGet);
        }
    }
}
