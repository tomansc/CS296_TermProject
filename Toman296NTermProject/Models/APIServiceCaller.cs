using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net;

namespace Toman296NTermProject.Models
{
    public class APIServiceCaller
    {
        private string accessUri = "https://api.meetup.com/find/groups?&sign=true&photo-host=public&zip=97405&radius=1&page=20&key=";
        private string key = "5d527d4a5c512e2f35276e5e41b5e1b";

        /*public async Task<List<Group>> GetGroupsAsync() // Someday I will figure out this async stuff. 
        {
            string call = accessUri + key;
            using (HttpClient httpClient = new HttpClient())
                return JsonConvert.DeserializeObject<List<Group>>(
                    await httpClient.GetStringAsync(call)
                );
        }*/

       /* public Task<List<Group>> GetGroups()
        {
            string call = accessUri + key;
            using (HttpClient httpClient = new HttpClient())
            {
                Task<String> response = httpClient.GetStringAsync(call);
                return Task.Factory.StartNew(() => JsonConvert.DeserializeObject<List<Group>>(response.Result));
            }
        } */

        public List<Group> GetGroups() //Third time's the charm!
        {
            string call = accessUri + key;
            WebClient list = new WebClient();
            string result = list.DownloadString(call);
            var server = JsonConvert.DeserializeObject<List<Group>>(result);
            //List<Group> groupResults = server;
            return server;
        }

    }
}