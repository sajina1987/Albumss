using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AlbumSetUp.Models
{
    public class Album
{
        public int userid { get; set; }
        public int id { get; set; }
        public string title { get; set; }
        public string AbumthumbnailUrl { get; set; }
}
    public class Photo
    {
        public int albumId { get; set; }
        public int id { get; set; }
        public string title { get; set; }
        public string url { get; set; }
        public string thumbnailUrl { get; set; }
        public string username { get; set; }
        public string email { get; set; }
        public string address { get; set; }
        public string phone { get; set; }

    }

    public class Users
    {
        public int id { get; set; }
        public string name { get; set; }
        public string username { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public string website { get; set; }
        public List<address> address { get; set; }
    }
    [Serializable]
    public class address
    {
        public string street { get; set; }
        public string suite { get; set; }
        public string city { get; set; }
        public string zipcode { get; set; }
        public List<Geo> geo { get; set; }
    }
    public class ListingClass
    {
        public string firstthumpnail { get; set; }
        public string title { get; set; }
        public string username { get; set; }
        public string email { get; set; }
        public string address { get; set; }
        public string phone { get; set; }
        public int abumid { get; set; }
        public int userid { get; set; }
    }
    [Serializable]
    public class Geo
    {
         public string  lat{ get; set; }
         public string lng { get; set; }
    }
    public class Posts
    {
        public int userid { get; set; }
        public int id { get; set; }
        public string title { get; set; }
        public string body { get; set; }
    }
}