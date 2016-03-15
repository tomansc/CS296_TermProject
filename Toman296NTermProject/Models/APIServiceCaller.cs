using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net;
using Newtonsoft.Json.Linq;

namespace Toman296NTermProject.Models
{
    public class APIServiceCaller
    {
        private string groupAccessUri = "https://api.meetup.com/find/groups?&sign=true&photo-host=public&location=Eugene&category=34&page=100&key=";
        private string memberAccessUri = "https://api.meetup.com/2/members?&sign=true&photo-host=public&group_id=";
        private string memberUriSuffix = "&page=2000&key=";
        
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

        public List<MeetupGroup> GetGroups() //Third time's the charm!
        {
            string call = groupAccessUri + key;
            WebClient list = new WebClient();
            string result = list.DownloadString(call);
            var server = JsonConvert.DeserializeObject<List<MeetupGroup>>(result);
            //List<Group> groupResults = server;
            return server;
        }

        public List<MeetupMemberUnparsed> GetMembers(List<MeetupGroup> groups)
        {
            //string call = memberAccessUri + key;
            WebClient list = new WebClient();
            List<MeetupMemberUnparsed> aggregateMemberList = new List<MeetupMemberUnparsed>();

            foreach (MeetupGroup g in groups)
            {
                string call = memberAccessUri + g.id + memberUriSuffix + key;
                string result = list.DownloadString(call);
                JObject jsonResults = JObject.Parse(result);
                JArray test = (JArray)jsonResults["results"];
                var server =  test.ToObject<List<MeetupMemberUnparsed>>();
                //  http://www.newtonsoft.com/json/help/html/ToObjectType.htm
                aggregateMemberList.AddRange(server);
            }
            //string result = list.DownloadString(call);
            //var server = JsonConvert.DeserializeObject<List<MeetupMemberUnparsed>>(result);
            return aggregateMemberList;
        }

    }
}