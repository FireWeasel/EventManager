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
            List<Product> products = new List<Product>();
            JavaScriptSerializer serializer = new JavaScriptSerializer();

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
                                products = serializer.Deserialize<List<Product>>(json);

                            }
                        }
                    }
                }
            }
            catch (WebException we)
            {
                MessageBox.Show("Error!" + we.Message);
                return null;
            }

            return products;
        }

        public Shop GetShop()
        {
            string json = "";

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://localhost:8080/shops/1");

            request.ContentType = "application/json";
            request.Method = "GET";
            request.CookieContainer = cookieContainer;
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            Shop returnValue;

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
                                returnValue = serializer.Deserialize<Shop>(json);
                                return returnValue;
                            }
                        }
                    }
                }
            }
            catch (WebException we)
            {
                MessageBox.Show(we.Message);
            }
            return null;
        }

        public bool AddProduct(Product p, Shop shop)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://localhost:8080/shops/1/products/create");

            request.ContentType = "application/json";
            request.Method = "POST";
            request.CookieContainer = cookieContainer;
            JavaScriptSerializer serializer = new JavaScriptSerializer();

            string jsonOfProduct = serializer.Serialize(new {
                name = p.Name,
                description = p.Description,
                price = p.Price,
                quantity = p.Quantity,
                type = p.Type,
                shop= shop.Id
            });

            try
            {
                using (StreamWriter sw = new StreamWriter(request.GetRequestStream()))
                {
                    sw.Write(jsonOfProduct);
                }
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                using (StreamReader sr = new StreamReader(response.GetResponseStream()))
                {
                    String responseString = sr.ReadToEnd();
                }
                shop.Products = GetAllProducts();
                return true;
            }
            catch (WebException)
            {
                return false;
            }
            
        }

        public bool UpdateProduct(Product p, Shop shop)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://localhost:8080/shops/1/products/"+p.Id);
            request.ContentType = "application/json";
            request.Method = "PUT";
            request.CookieContainer = cookieContainer;

            JavaScriptSerializer serializer = new JavaScriptSerializer();
            string jsonOfProduct = serializer.Serialize(new
            {
                name = p.Name,
                description = p.Description,
                price = p.Price,
                quantity = p.Quantity,
                type = p.Type,
            });
            MessageBox.Show(jsonOfProduct);

            try
            {
                using (StreamWriter sw = new StreamWriter(request.GetRequestStream()))
                {
                    sw.Write(jsonOfProduct);
                }
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                using (StreamReader sr = new StreamReader(response.GetResponseStream()))
                {
                    String responseString = sr.ReadToEnd();
                }
                shop.Products = this.GetAllProducts();
                return true;
            }
            catch (WebException)
            {
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

        public void BuyProduct(long ticketId, long productId)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://localhost:8080/tickets/"+ticketId+"/products/"+productId);

            request.ContentType = "application/json";
            request.Method = "POST";
            request.CookieContainer = cookieContainer;
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            


            try
            {
                using (StreamWriter sw = new StreamWriter(request.GetRequestStream()))
                {
                    sw.Write("");
                }
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                using (StreamReader sr = new StreamReader(response.GetResponseStream()))
                {
                    String responseString = sr.ReadToEnd();
                }
            }
            catch (WebException we)
            {
                MessageBox.Show("Error! Could not add this product." + we.Message);
            }
        }
    }
}
