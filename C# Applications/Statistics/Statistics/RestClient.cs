using System;
using System.Collections.Generic;
using System.Net;
using System.IO;
using System.Windows.Forms;
using System.Web.Script.Serialization;

namespace Statistics
{
    #region Enumerator
    public enum httpVerb
    {
        GET,
        POST,
        PUT
    }
    #endregion
    #region RestClient class
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
        #region Camp and Ticket
        public List<Ticket> GetTickets()
        {
            string endPoint = "http://localhost:8080/tickets";
            List<Ticket> LoanedItems = new List<Ticket>();
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
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            var item = serializer.Deserialize<List<Ticket>>(strResponseValue);
            foreach (Ticket i in item)
            {
                LoanedItems.Add(i);
            }
            return LoanedItems;
        }
        public List<Camp> RequestCamps()
        {
            EndPoint = "http://localhost:8080/camps";
            List<Camp> camps = new List<Camp>();
            string strResponseValue = string.Empty;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(EndPoint);
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
            var item = serializer.Deserialize<List<Camp>>(strResponseValue);
            foreach (Camp camp in item)
            {
                camps.Add(camp);
            }
            return camps;
        }
        public List<Camp> RequestFreeCamps()
        {
            EndPoint = "http://localhost:8080/camps/free";
            List<Camp> camps = new List<Camp>();
            string strResponseValue = string.Empty;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(EndPoint);
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
            var item = serializer.Deserialize<List<Camp>>(strResponseValue);
            foreach (Camp camp in item)
            {
                camps.Add(camp);
            }
            return camps;
        }
        #endregion
        #region Shop and stand
        public List<Shop> GetShop()
        {
            List<Shop> shops = new List<Shop>();
            EndPoint = "http://localhost:8080/shops";
            string strResponseValue = string.Empty;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(EndPoint);
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
            var item = serializer.Deserialize<List<Shop>>(strResponseValue);
            foreach (Shop shop in item)
            {
                shops.Add(shop);
            }
            return shops;
        }
        public Loan_Stand GetLoanStand()
        {
            Loan_Stand stand = null;
            EndPoint = "http://localhost:8080/stands/1";
            string strResponseValue = string.Empty;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(EndPoint);
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
            }catch(WebException webExc)
            {
                MessageBox.Show(webExc.Message);
            }
            //Deserializing responce into Loan_Stand object
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            var item = serializer.Deserialize<Loan_Stand>(strResponseValue);
            stand = item;
            return stand;
        }
        public List<Item> LoanedItem()
        {
            string endPoint = "http://localhost:8080/tickets/1/items";
            List<Item> LoanedItems = new List<Item>();
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
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            var item = serializer.Deserialize<List<Item>>(strResponseValue);
            foreach (Item i in item)
            {
                LoanedItems.Add(i);
            }
            return LoanedItems;
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
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            var item = serializer.Deserialize<List<Item>>(strResponseValue);
            foreach (Item i in item)
            {
                Items.Add(i);
            }
            return Items;
        }
        public List<Product> GetSoldProduct()
        {
            string endPoint = "http://localhost:8080/tickets/1/products";
            List<Product> Products = new List<Product>();
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
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            var item = serializer.Deserialize<List<Product>>(strResponseValue);
            foreach (Product i in item)
            {
                Products.Add(i);
            }
            return Products;
        }
        #endregion
        #region LogIn
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
                MessageBox.Show("Error loging in the server!");
                return false;
            }
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
        #endregion
        #region Server methods
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
                MessageBox.Show("You've logged out from the server!");
            }

            return responseValue;
        }
        #endregion
    }
    #endregion
}