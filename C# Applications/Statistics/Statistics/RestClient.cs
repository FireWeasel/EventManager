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

namespace Statistics
{
    public enum httpVerb
    {
        GET,
        POST,
        PUT
        //DELETE
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
            //Deserializing response into Item object
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            var item = serializer.Deserialize<List<Product>>(strResponseValue);
            foreach (Product i in item)
            {
                Products.Add(i);
            }
            return Products;
        }
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
            //Deserializing response into Item object
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            var item = serializer.Deserialize<List<Ticket>>(strResponseValue);
            foreach (Ticket i in item)
            {
                LoanedItems.Add(i);
            }
            return LoanedItems;
        }
        public List<Reservation> RequestReservations()
        {
            EndPoint = "http://localhost:8080/reservations";
            List<Reservation> reservations = new List<Reservation>();
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
            var item = serializer.Deserialize<List<Reservation>>(strResponseValue);
            foreach (Reservation reserv in item)
            {
                reservations.Add(reserv);
            }
            return reservations;
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
            
            //Deserializing responce into Loan_Stand object
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

            //Deserializing responce into Loan_Stand object
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            var item = serializer.Deserialize<List<Camp>>(strResponseValue);
            foreach (Camp camp in item)
            {
                camps.Add(camp);
            }
            return camps;
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
            //Deserializing response into Item object
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
            try { 
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
            //Deserializing response into Item object
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            var item = serializer.Deserialize<List<Item>>(strResponseValue);
            foreach(Item i in item)
            {
                Items.Add(i);
            }
            return Items;
        }

        public Shop GetShop()
        {
            Shop shops = null;
            EndPoint = "http://localhost:8080/stands";
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
                shops = shop;
            }
            return shops;
        }
        public Loan_Stand GetLoanStand()
        {
            Loan_Stand stand = null;
            EndPoint = "http://localhost:8080/stands";
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
            var item = serializer.Deserialize<List<Loan_Stand>>(strResponseValue);
            foreach(Loan_Stand stands in item)
            {
                stand = stands;
            }
            return stand;
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
    }
}
