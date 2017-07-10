using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;

namespace SummerCamp.Web.Models
{
    public class AnnouncementClient
    {
        private string BASE_URL = "http://api.summercamp.stage02.netromsoftware.ro";

        public IEnumerable<AnnouncementDetails> findAll()
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(BASE_URL);
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("aplication/json"));
                HttpResponseMessage response = client.GetAsync("api/announcements").Result;
                if (response.IsSuccessStatusCode)
                    return response.Content.ReadAsAsync<IEnumerable<AnnouncementDetails>>().Result;
                return null;
            }
            catch
            {
                return null;
            }
        }


        public bool Edit(AnnouncementDetails announcement)
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(BASE_URL);
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.PutAsJsonAsync("announcement/" + announcement.Id
                    , announcement).Result;
                return response.IsSuccessStatusCode;
            }
            catch
            {
                return false;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(BASE_URL);
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.DeleteAsync("announcement/" + 
                    id).Result;
                return response.IsSuccessStatusCode;
            }
            catch
            {
                return false;
            }
        }
    }
}