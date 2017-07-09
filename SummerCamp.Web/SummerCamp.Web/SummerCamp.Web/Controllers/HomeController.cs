
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



        public async Task<ActionResult> Details(int id, string Title, string Description)
        {
            AnnouncementDetails AnnouncementInfo = new AnnouncementDetails();
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

                AnnouncementInfo.Id = id;
                AnnouncementInfo.Title = Title;
                AnnouncementInfo.Description = Description;
                //returning the Announcement list to view  
                return View(AnnouncementInfo);
            }

        }
        //public ActionResult Delete()
        //{
        //    return View();
        //}

        //[HttpPost]
        //public async Task<ActionResult> Delete(int id, string email)
        //{
        //    AnnouncementDelete AnnouncementInfo = new AnnouncementDelete();
        //    string Baseurl = "http://api.summercamp.stage02.netromsoftware.ro";
        //    using (var client = new HttpClient())
        //    {
        //        //Passing service base url  
        //        client.BaseAddress = new Uri(Baseurl);

        //        client.DefaultRequestHeaders.Clear();
        //        //Define request data format  
        //        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        //        //Sending request to find web api REST service resource GetAllAnnouncements using HttpClient  
        //        HttpResponseMessage Res = await client.GetAsync("/api/announcements/CloseAnnouncement?announcementId=4");

        //        AnnouncementInfo.Email = email;
        //        AnnouncementInfo.Id = id;

        //        //returning the Announcement list to view  
        //        return View(AnnouncementInfo);
        //    }

        //}

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



        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        //public ActionResult Delete(int id)
        //{
        //    try
        //    {
        //        Announcement EmpRepo = new Announcement();
        //        if (EmpRepo.DeleteAnnouncement(id))
        //        {
        //            ViewBag.AlertMsg = "Announcement deleted successfully";

        //        }
        //        return RedirectToAction("Index");

        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}



        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
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

        //public async Task<ActionResult> Delete(int id)
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

        ////The DELETE method
        //[HttpPost]
        //public async Task<ActionResult> Delete(int id, EmployeeInfo Emp)
        //{

        //    HttpResponseMessage responseMessage = await client.DeleteAsync(url + "/" + id);
        //    if (responseMessage.IsSuccessStatusCode)
        //    {
        //        return RedirectToAction("Index");
        //    }
        //    return RedirectToAction("Error");
        //}



        public async Task<ActionResult> Delete(int id)
        {

            string Baseurl = "http://api.summercamp.stage02.netromsoftware.ro/api/announcements/CloseAnnouncement?announcementId=";
            using (var client = new HttpClient())
            {
                //Passing service base url  
                client.BaseAddress = new Uri(Baseurl);

                client.DefaultRequestHeaders.Clear();
                //Define request data format  
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage responseMessage = await client.GetAsync(Baseurl + "=" + id);
                if (responseMessage.IsSuccessStatusCode)
                {
                    var responseData = responseMessage.Content.ReadAsStringAsync().Result;

                    var AnnDelete = JsonConvert.DeserializeObject<AnnouncementDelete>(responseData);

                    return View(AnnDelete);
                }
                return View("Error");
            }
        }

        //The DELETE method
        [HttpPost]
        public async Task<ActionResult> Delete(int id, AnnouncementDelete AnnDelete)
        {
            {

                string Baseurl = "http://api.summercamp.stage02.netromsoftware.ro/api/announcements/CloseAnnouncement?announcementId=";
                using (var client = new HttpClient())
                {
                    //Passing service base url  
                    client.BaseAddress = new Uri(Baseurl);

                    client.DefaultRequestHeaders.Clear();
                    //Define request data format  
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    HttpResponseMessage responseMessage = await client.DeleteAsync(Baseurl + "=" + id);
                    if (responseMessage.IsSuccessStatusCode)
                    {
                        return RedirectToAction("Index");
                    }
                    return RedirectToAction("Error");
                }



            }

        }
    }
}