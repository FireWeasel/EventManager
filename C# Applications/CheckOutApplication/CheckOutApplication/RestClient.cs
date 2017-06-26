using System;
using System.Collections.Generic;
using System.Net;
using System.IO;
using System.Windows.Forms;
using System.Web.Script.Serialization;
using Newtonsoft.Json;

namespace CheckOut
{
    public class RestClient
    {
        #region Properties and constructors
        private CookieContainer cookieContainer = new CookieContainer();
        public RestClient()
        {

        }
        #endregion
        #region Get methods
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
            catch (WebException)
            {
                
            }

            return responseValue;
        }
        public User GetLoggedUser(string url)
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
            catch (WebException)
            {
                MessageBox.Show("You've logged out from the server!");
            }
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            var item = serializer.Deserialize<User>(responseValue);
            return item;
        }
        public List<BorrowedItem> GetTicketItems(long id)
        {
            string endPoint = "http://localhost:8080/tickets/"+ id +  "/items";
            List<BorrowedItem> LoanedItems = null;
            string strResponseValue = string.Empty;

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(endPoint);

            request.Method = "GET";
            request.CookieContainer = cookieContainer;
            try
            {
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    if (response.StatusCode != HttpStatusCode.OK)
                    {
                        throw new ApplicationException("Error connecting with the server!");
                    }
                    using (Stream responseStream = response.GetResponseStream())
                    {
                        if (responseStream != null)
                        {
                            using (StreamReader reader = new StreamReader(responseStream))
                            {
                                strResponseValue = reader.ReadLine();
                            }
                        }
                    }
                }
            }
            catch (WebException webExc)
            {
               MessageBox.Show(webExc.Message);
            }
            LoanedItems = JsonConvert.DeserializeObject<List<BorrowedItem>>(strResponseValue);
            if(strResponseValue == "[]")
            {
                return null;
            }
            else
            {
                return LoanedItems;
            }
        }
        public Ticket GetTicket(long id)
        {
            string endPoint = "http://localhost:8080/tickets/" + id;
            Ticket ticket = null;
            string strResponseValue = string.Empty;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(endPoint);
            request.ContentType = "application/json";
            request.Method = "GET";
            request.CookieContainer = cookieContainer;
            try
            {
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    if (response.StatusCode != HttpStatusCode.OK)
                    {
                        throw new ApplicationException("Error connecting with the server!");
                    }
                    using (Stream responseStream = response.GetResponseStream())
                    {
                        if (responseStream != null)
                        {
                            using (StreamReader reader = new StreamReader(responseStream))
                            {
                                strResponseValue = reader.ReadLine();
                            }
                        }
                    }
                }
            }
            catch (WebException webExc)
            {
                MessageBox.Show(webExc.Message);
            }
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            var item = serializer.Deserialize<Ticket>(strResponseValue);
            ticket = item;
            return ticket;
        }
        public User GetUser(long id)
        {
            string endPoint = "http://localhost:8080/tickets/" + id + "/owner";
            User user = null;
            string strResponseValue = string.Empty;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(endPoint);
            request.ContentType = "application/json";
            request.Method = "GET";
            request.CookieContainer = cookieContainer;
            try
            {
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    if (response.StatusCode != HttpStatusCode.OK)
                    {
                        throw new ApplicationException("Error connecting with the server!");
                    }
                    using (Stream responseStream = response.GetResponseStream())
                    {
                        if (responseStream != null)
                        {
                            using (StreamReader reader = new StreamReader(responseStream))
                            {
                                strResponseValue = reader.ReadLine();
                            }
                        }
                    }
                }
            }
            catch (WebException webExc)
            {
                MessageBox.Show(webExc.Message);
            }
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            var item = serializer.Deserialize<User>(strResponseValue);
            user = item;
            return user;
        }
        #endregion
        #region Post methods
        public bool LogIn(string url, string username, string password)
        {
            var result = "";
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
                var response = (HttpWebResponse)request.GetResponse();
                using (StreamReader sr = new StreamReader(response.GetResponseStream()))
                {
                    result = sr.ReadToEnd();
                }
                return true;
            }
            catch (WebException e)
            {
                MessageBox.Show("There was an error loging to the server!");
                return false;
            }
        }
        public void ReturnItems(long id, long itemId)
        {
            string endPoint = "http://localhost:8080/tickets/" + id + "/items/" + itemId + "/return";
            string result = "";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(endPoint);
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

        public void CheckOutTicket(long id)
        {
            String result;
            string endPoint = "http://localhost:8080/tickets/checkOut/" + id;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(endPoint);
            request.ContentType = "application/x-www-form-urlencoded";
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
        #endregion
    }
  }

