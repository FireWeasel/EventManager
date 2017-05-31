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

namespace Rent_Items_Test
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
        public void AddData(int id, string name, string description, double fee, int quantity, string type)
        {
            EndPoint = "http://localhost:8080/stands/1/items/create";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(EndPoint);
            request.ContentType = "application/json";
            request.Method = "POST";
            request.CookieContainer = cookieContainer;
            using (StreamWriter streamWriter = new StreamWriter(request.GetRequestStream()))
            {
                string json = new JavaScriptSerializer().Serialize(new
                {
                    name = name,
                    description = description,
                    fee = fee,
                    quantity = quantity,
                    type = type
                });
                streamWriter.Write(json);
            }
            var httpResponse = (HttpWebResponse)request.GetResponse();
            using (StreamReader streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();
            }
        }
        public void UpdateData(int id,string name, string description, double fee, int quantity)
        {
            List<Item> items = RequestItems();
            Type type = Type.OTHER;

            string endPoint = "http://localhost:8080/stands/1/items/" + id;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(endPoint);
            request.Method = "PUT";
            request.ContentType = "application/json";
            request.CookieContainer = cookieContainer;
            foreach(Item item in items)
            {
                if(item.ID == id)
                {
                    type = item.Type;
                    if (name=="")
                    {
                        name = item.Name;
                    }
                    if(description =="")
                    {
                        description = item.Description;
                    }
                    if(fee == 0)
                    {
                        fee = item.Fee;
                    }
                    if(quantity == 0)
                    {
                        quantity = item.Quantity;
                    }
                }
            }

            try
            {
                using (StreamWriter streamWriter = new StreamWriter(request.GetRequestStream()))
                {
                    //Serializing string into json object
                    string json = new JavaScriptSerializer().Serialize(new
                    {
                        id = id,
                        name = name,
                        description = description,
                        fee = fee,
                        quantity = quantity,
                        type = type
                    });

                    streamWriter.Write(json);
                }
                var httpResponse = (HttpWebResponse)request.GetResponse();
                using (StreamReader streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var result = streamReader.ReadToEnd();
                }
            }catch(WebException webExc)
            {
                MessageBox.Show(webExc.Message);
            }
        }
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
        public void BorrowItem(long id,long itemId)
        {
            try
            {
                string endPoint = "http://localhost:8080/tickets/" + id + "/items/" + itemId;
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(endPoint);
                request.ContentType = "application/json";
                request.Method = "POST";
                request.CookieContainer = cookieContainer;
                using (StreamWriter streamWriter = new StreamWriter(request.GetRequestStream()))
                {
                    streamWriter.Write("");
                }
                var httpResponse = (HttpWebResponse)request.GetResponse();
                using (StreamReader streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var result = streamReader.ReadToEnd();
                }
            }
            catch(WebException)
            {
                MessageBox.Show("Something went wrong when trying to loan item!");
            }
        }
    }
}
