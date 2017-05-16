using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Windows.Forms;


namespace ShopApplication
{
    public class RestClient
    {
        private CookieContainer cookieContainer = new CookieContainer();

        public CookieContainer CookieContainer
        {
            get
            {
                return cookieContainer;
            }

            set
            {
                cookieContainer = value;
            }
        }

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

        public List<Product> GetAllProducts()
        {
            string json = "";

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://localhost:8080/shops/1/products");

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
                                json = reader.ReadToEnd();
                                MessageBox.Show(json);
                            }
                        }
                    }
                }
            }
            catch (WebException we)
            {
                MessageBox.Show("Error!" + we.Message);
            }
            return null;
            //JavaScriptSerializer serializer = new JavaScriptSerializer();
            //List<String> jsonProducts = serializer.Deserialize<List<String>>(json);

        }


    }
}
