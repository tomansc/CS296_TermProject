using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Toman296NTermProject.Models;
using Toman296NTermProject.DAL;
using System.Text;
using System.Reflection; // Obtains type information in real time by examining objects' data. 
using System.Text.RegularExpressions;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Toman296NTermProject.Controllers
{
    //[Authorize(Roles = "User")]
    [AllowAnonymous]
    public class DataController : Controller
    {
        public APIServiceCaller caller = new APIServiceCaller();
        public Toman296NTermProjectContext db = new Toman296NTermProjectContext();
        
        // GET: Data
        public ActionResult Index()
        {
            List<MeetupGroup> groupResults = caller.GetGroups();
            return View("index", groupResults);
        }

        public ActionResult Groups()
        {
            List<MeetupGroup> groupResults = caller.GetGroups();
            return View("Groups", groupResults);
        }

        public ActionResult GroupToMemberEngine()
        {
            List<MeetupGroup> groupResults = caller.GetGroups();
            List<MeetupMemberUnparsed> memberResults = caller.GetMembers(groupResults);

            ViewBag.totalProcessed = memberResults.Count;


            string csvListToWrite = GenerateMembersCSVString(memberResults);
            if (WriteMembersCSVFile(csvListToWrite))
                return View("Index");
            else
                return View("Index");
        }

        public ActionResult RegenerateMemberDatabase()
        {
            List<MeetupMemberParsed> memberListWithGender = ReadMembersCSVFile();
            memberListWithGender.RemoveAt((memberListWithGender.Count - 1)); //remove null entry
            try
            {
                foreach (MeetupMemberParsed m in db.MeetupMembersParsed) //Near-equivalent of DROP DATABASE since we want to populate the DB with a fresh set of data each time we run this function.
                    db.MeetupMembersParsed.Remove(m);
                db.MeetupMembersParsed.AddRange(memberListWithGender); // Add the new records.
                db.SaveChanges();
                ViewBag.totalWritten = memberListWithGender.Count;
            }
            catch (Exception ex)
            {
                ViewBag.totalWritten = ex.Message;
                throw new Exception();
            }

            return View("Index");
        }
        
        public string GenerateMembersCSVString(List<MeetupMemberUnparsed> memberList)
        {
            string memberString = "";
            foreach (MeetupMemberUnparsed m in memberList)
            {
                memberString += ObjectToCsvData(m) + "\n";
            }
            return memberString;
        }

        public ActionResult VisualizeData() // I would like to improve the efficiency of this. Need to look up some nifty sorting algorithms.
        {
            List<MeetupMemberParsed> currentList = db.MeetupMembersParsed.ToList();
            List<MeetupMemberParsed> femaleList = new List<MeetupMemberParsed>();
            List<MeetupMemberParsed> maleList = new List<MeetupMemberParsed>();
            List<MeetupMemberParsed> otherList = new List<MeetupMemberParsed>();
            
            foreach (MeetupMemberParsed m in currentList)
            {
                if (m.gender == "Female")
                    femaleList.Add(m);
                else if (m.gender == "Male")
                    maleList.Add(m);
                else
                    otherList.Add(m);
            }
            femaleList.AddRange(maleList);
            femaleList.AddRange(otherList);
             
            return View("Visualize", femaleList);
        }

        public bool WriteMembersCSVFile(string csvToWrite)
        {
            var writeFile = Server.MapPath(@"~\Content\memberlistUnparsed.csv");
            System.IO.File.WriteAllText(writeFile, csvToWrite);
            return true;

        }

        public List<MeetupMemberParsed> ReadMembersCSVFile()
        {
            var readFile = Server.MapPath(@"~\Content\memberListParsed.csv");
            string memberString = System.IO.File.ReadAllText(readFile);
            memberString = memberString.Replace("\"",string.Empty);
            memberString = memberString.Replace("\r", string.Empty);

            string[] memberArray = Regex.Split(memberString,"\n");
            List<MeetupMemberParsed> parsedList = new List<MeetupMemberParsed>();

            int lastIndex = memberArray.Length - 1;
            memberArray[lastIndex] = "null,null,null,null,null,null,null,null,null,null"; //last element is empty string. This avoids an exception
            
            foreach (string m in memberArray)
            {
                string[] memberRow = m.Split(',');
                MeetupMemberParsed n = new MeetupMemberParsed();
                try
                {
                    n.country = memberRow[0];
                    n.city = memberRow[1];
                    n.link = memberRow[2];
                    n.lat = memberRow[3];
                    n.name = memberRow[4];
                    n.id = memberRow[5];
                    n.status = memberRow[7];
                    n.lon = memberRow[8];
                    n.gender = memberRow[9];
                }
                catch (Exception ex)
                {
                    n = null; // Think of a better error-handling strategy. This is to catch malformed records. 
                    continue;
                }
                parsedList.Add(n);   
            }
            return parsedList;
        }
        /// <summary>
        ///
        /// Creates a comma-delimited string of all an object's property values names.
        /// Courtesy of Leniel Macaferi: http://stackoverflow.com/questions/3199604/is-there-a-quick-way-to-convert-an-entity-to-csv-file
        /// </summary>
        /// <param name="obj">object.</param>
        /// <returns>string.</returns>
        public static string ObjectToCsvData(object obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException("obj", "Value can not be null or nothing.");
            }

            StringBuilder sb = new StringBuilder();
            Type t = obj.GetType();
            PropertyInfo[] pi = t.GetProperties();

            for (int index = 0; index < pi.Length; index++)
            {
                sb.Append(pi[index].GetValue(obj, null));

                if (index < pi.Length - 1)
                {
                    sb.Append(",");
                }
            }

            return sb.ToString();
        }
    }
}