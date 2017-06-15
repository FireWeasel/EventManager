using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Web.Script.Serialization;

namespace CheckInApplication
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

        }

        public Ticket GetTicket(long id)
        {
            string responseValue = "";
            Ticket ticketToReturn;
            JavaScriptSerializer serializer;

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://localhost:8080/tickets/" + id);

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
                serializer = new JavaScriptSerializer();
                ticketToReturn = serializer.Deserialize<Ticket>(responseValue);
                return ticketToReturn;
            }
            catch (WebException we)
            {
                MessageBox.Show(we.Message);
            }
            return null;

        }

        public void CheckInTicket(long id)
        {
            String result;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://localhost:8080/tickets/checkIn/" + id);
            request.ContentType = "application/json";
            request.Method = "POST";
            request.CookieContainer = cookieContainer;

            using (StreamWriter sw = new StreamWriter(request.GetRequestStream()))
            {
                sw.Write("");
            }

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            using (StreamReader sr = new StreamReader(response.GetResponseStream()))
            {
                result = sr.ReadToEnd();
            }
        }

        public User GetUser(long id)
        {
            string responseValue = "";
            User userToReturn;
            JavaScriptSerializer serializer;

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://localhost:8080/tickets/" + id + "/owner");
            request.ContentType = "application/json";
            request.Method = "GET";
            request.CookieContainer = cookieContainer;

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

            serializer = new JavaScriptSerializer();
            userToReturn = serializer.Deserialize<User>(responseValue);
            return userToReturn;
        }
    }
}
