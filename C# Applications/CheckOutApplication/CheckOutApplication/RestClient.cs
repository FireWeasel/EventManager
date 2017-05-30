using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using System.Windows.Forms;
using System.Web.Script.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Globalization;

namespace CheckOut
{
    public enum httpVerb
    {
        GET,
        POST,
        PUT
    }
    public class RestClient
    {
        #region Properties and constructors (empty, 1 parameter, 2 parameters)
        public string EndPoint { get; set; }
        public httpVerb HttpMethod { get; set; }
        public List<Loan_Stand> Stands { get; set; }
        private CookieContainer cookieContainer = new CookieContainer();
        public RestClient()
        {

        }
        #endregion
       
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
            //Deserializing response into Item object
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
        #region LogIn
        public void LogIn(string url, string username, string password)
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
            }
            catch (WebException e)
            {
                MessageBox.Show(e.Message);
            }

        }
        #endregion
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
            //Deserializing responce into Loan_Stand object
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
            //Deserializing responce into Loan_Stand object
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            var item = serializer.Deserialize<User>(strResponseValue);
            user = item;
            return user;
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
        public List<Item> RequestItems()
        {
            string endPoint = "http://localhost:8080/stands/1/items";
            List<Item> Items = new List<Item>();
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
            //Deserializing response into Item object
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            var item = serializer.Deserialize<List<Item>>(strResponseValue);
            foreach (Item i in item)
            {
                Items.Add(i);
            }
            return Items;
        }
        public Item GetItem(long id)
        {
            string endPoint = "http://localhost:8080/items/" + id;
            Item item = null;
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
            //Deserializing responce into Loan_Stand object
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            var items = serializer.Deserialize<Item>(strResponseValue);
            item = items;
            return item;
        }
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
                MessageBox.Show("You've logged out from the server!");
            }

            return responseValue;
        }
    }
  }

