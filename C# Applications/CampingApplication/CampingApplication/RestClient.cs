using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Web.Script.Serialization;

namespace CampingApplication
{
    public class RestClient
    {
        private CookieContainer cookieContainer = new CookieContainer();

        public RestClient() { }

        public string GetRequest(string url)
        {
            string responseValue = "";

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);

            request.ContentType = "application/json";
            request.Method = "GET";
            request.CookieContainer = cookieContainer;


            try
            {
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    using (Stream responseStream = response.GetResponseStream())
                    {
                        if (responseStream != null)
                        {
                            using (StreamReader reader = new StreamReader(responseStream))
                            {
                                responseValue = reader.ReadToEnd();
                            }
                        }
                    }
                }
            }
            catch (WebException we)
            {
                MessageBox.Show(we.Message);
            }

            return responseValue;
        }

        public bool LogIn(string url, string username, string password)
        {
            String result = "";

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.ContentType = "application/x-www-form-urlencoded";
            request.Method = "POST";
            request.CookieContainer = cookieContainer;

            String info = "username=" + username + "&password=" + password;

            try
            {
                using (StreamWriter sw = new StreamWriter(request.GetRequestStream()))
                {
                    sw.Write(info);
                }
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                using (StreamReader sr = new StreamReader(response.GetResponseStream()))
                {
                    result = sr.ReadToEnd();
                }
                return true;
            }
            catch (WebException)
            {
                MessageBox.Show("Login unsuccessful!");
                return false;
            }

        } // works

        public User GetTicket(long id)
        {
            string responseValue = "";
            User userToReturn;
            JavaScriptSerializer serializer;

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://localhost:8080/tickets/"+id+"/owner");

            request.ContentType = "application/json";
            request.Method = "GET";
            request.CookieContainer = cookieContainer;


            try
            {
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    using (Stream responseStream = response.GetResponseStream())
                    {
                        if (responseStream != null)
                        {
                            using (StreamReader reader = new StreamReader(responseStream))
                            {
                                responseValue = reader.ReadToEnd();
                            }
                        }
                    }
                }
                MessageBox.Show(responseValue);
                serializer = new JavaScriptSerializer();
                userToReturn = serializer.Deserialize<User>(responseValue);
                return userToReturn;
            }
            catch (WebException we)
            {
                MessageBox.Show(we.Message);
            }
            return null;
            
        }



    }
}
