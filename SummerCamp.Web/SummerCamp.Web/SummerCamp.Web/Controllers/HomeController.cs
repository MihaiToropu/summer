
using Newtonsoft.Json;
using SummerCamp.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace SummerCamp.Web.Controllers
{
    public class HomeController : Controller
    {
        private Task<HttpResponseMessage> client;


        public string Baseurl { get; private set; }


        //Hosted web API REST Service base url  

        public async Task<ActionResult> Index()
        {
            List<Announcement> AnnouncementInfo = new List<Announcement>();
            string Baseurl = "http://api.summercamp.stage02.netromsoftware.ro";
            using (var client = new HttpClient())
            {
                //Passing service base url  
                client.BaseAddress = new Uri(Baseurl);

                client.DefaultRequestHeaders.Clear();
                //Define request data format  
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //Sending request to find web api REST service resource GetAllAnnouncements using HttpClient  
                HttpResponseMessage Res = await client.GetAsync("api/announcements");

                //Checking the response is successful or not which is sent using HttpClient  
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api   
                    var AnnouncementResp = Res.Content.ReadAsStringAsync().Result;

                    //Deserializing the response recieved from web api and storing into the Announcement list  
                    AnnouncementInfo = JsonConvert.DeserializeObject<List<Announcement>>(AnnouncementResp);

                }
                //returning the Announcement list to view  
                return View(AnnouncementInfo);
            }

        }



        public async Task<ActionResult> Details(int id)
        {
            AnnouncementDetails AnnouncementInfo = new AnnouncementDetails();
            string Baseurl = "http://api.summercamp.stage02.netromsoftware.ro/";
            using (var client = new HttpClient())
            {
                //Passing service base url  
                client.BaseAddress = new Uri(Baseurl);

                client.DefaultRequestHeaders.Clear();
                //Define request data format  
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //Sending request to find web api REST service resource GetAllAnnouncements using HttpClient  
                HttpResponseMessage Res = await client.GetAsync("api/announcements/" + id);

                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api   
                    var AnnouncementResp = Res.Content.ReadAsStringAsync().Result;

                    //Deserializing the response recieved from web api and storing into the Announcement list  
                    AnnouncementInfo = JsonConvert.DeserializeObject<AnnouncementDetails>(AnnouncementResp);

                }

                //AnnouncementInfo.Id = id;
                //AnnouncementInfo.Title = Title;
                //AnnouncementInfo.Description = Description;
                //returning the Announcement list to view  
                return View(AnnouncementInfo);
            }

        }


        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Create(AnnouncementCreate nou)
        {
            string url = "http://api.summercamp.stage02.netromsoftware.ro/api/announcements/NewAnnouncement";
            if (ModelState.IsValid)
            {
                HttpClient client = new HttpClient();
                var result = client.PostAsJsonAsync(url, nou).Result;
                if (result.IsSuccessStatusCode)
                {
                    nou = result.Content.ReadAsAsync<AnnouncementCreate>().Result;
                    ViewBag.Result = "Succesfully saved!";
                    ModelState.Clear();

                    return View(new AnnouncementCreate());
                }
                else
                {
                    ViewBag.Result = "Error!Please try again with valid data";
                }
            }
            return View(nou);
        }

        public ActionResult Close(int id)
        {
            return View();
        }


        [HttpPost]
        public ActionResult Close(int id,AnnouncementClose nou)
        {
            string url = "http://api.summercamp.stage02.netromsoftware.ro/api/announcements/CloseAnnouncement?announcementId="+id;
            if (ModelState.IsValid)
            {
                HttpClient client = new HttpClient();
                var result = client.PostAsJsonAsync(url, nou).Result;       
            }
            return RedirectToAction("Index");
        }




        public ActionResult Review()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Review(AnnouncementNewReview nou)
        {
            string url = "http://api.summercamp.stage02.netromsoftware.ro/api/reviews/NewReview";
            if (ModelState.IsValid)
            {
                HttpClient client = new HttpClient();
                var result = client.PostAsJsonAsync(url, nou).Result;
                if (result.IsSuccessStatusCode)
                {
                    nou = result.Content.ReadAsAsync<AnnouncementNewReview>().Result;
                    ViewBag.Result = "Succesfully saved!";
                    ModelState.Clear();

                    return RedirectToAction("GetReview");
                }
                else
                {
                    ViewBag.Result = "Error!Please try again with valid data";
                }

            }
            return View(nou);

        }


        public async Task<ActionResult> GetReview(int id)
        {
            List<AnnouncementNewReview> AnnouncementInfo = new List<AnnouncementNewReview>();
            string Baseurl = "http://api.summercamp.stage02.netromsoftware.ro/";
            using (var client = new HttpClient())
            {
                //Passing service base url  
                client.BaseAddress = new Uri(Baseurl);

                client.DefaultRequestHeaders.Clear();
                //Define request data format  
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //Sending request to find web api REST service resource GetAllAnnouncements using HttpClient  
                HttpResponseMessage Res = await client.GetAsync("/api/reviews/GetByAnnouncementId?announcementId=" + id);

                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api   
                    var AnnouncementResp = Res.Content.ReadAsStringAsync().Result;

                    //Deserializing the response recieved from web api and storing into the Announcement list  
                    AnnouncementInfo = JsonConvert.DeserializeObject<List<AnnouncementNewReview>>(AnnouncementResp);

                }

                //AnnouncementInfo.Id = id;
                //AnnouncementInfo.Title = Title;
                //AnnouncementInfo.Description = Description;
                //returning the Announcement list to view  
                return View(AnnouncementInfo);
            }

        }

        //public async Task<ActionResult> Edit(int id)
        //{
        //    HttpResponseMessage responseMessage = await client.GetAsync(url + "/" + id);
        //    if (responseMessage.IsSuccessStatusCode)
        //    {
        //        var responseData = responseMessage.Content.ReadAsStringAsync().Result;

        //        var Employee = JsonConvert.DeserializeObject<EmployeeInfo>(responseData);

        //        return View(Employee);
        //    }
        //    return View("Error");
        //}

        ////The PUT Method
        //[HttpPost]
        //public async Task<ActionResult> Edit(int id, EmployeeInfo Emp)
        //{

        //    HttpResponseMessage responseMessage = await client.PutAsJsonAsync(url + "/" + id, Emp);
        //    if (responseMessage.IsSuccessStatusCode)
        //    {
        //        return RedirectToAction("Index");
        //    }
        //    return RedirectToAction("Error");
        //}






    }
}