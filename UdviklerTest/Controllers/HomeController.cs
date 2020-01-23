using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json.Linq;
using System.Web.Script.Serialization;
using UdviklerTest.Models;
using System.Web.Configuration;
using UdviklerTest.Services;
using System.Web.Http;

namespace UdviklerTest.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult WebShop()
        {
            using (var httpClient = new HttpClient())
            {
                ServicePointManager.SecurityProtocol = ServicePointManager.SecurityProtocol | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
                var url = WebConfigurationManager.AppSettings["baseUrl"] + "getallproducts";
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
                httpWebRequest.ContentType = "application/json";

                httpWebRequest.Method = "POST";
                httpWebRequest.AutomaticDecompression = DecompressionMethods.Deflate | DecompressionMethods.GZip;
                var content = string.Empty;
                PostData postdata = new PostData();
                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    postdata.ApiKey = "";
                    postdata.UserName = WebConfigurationManager.AppSettings["UserName"];
                    postdata.Password = WebConfigurationManager.AppSettings["Password"];
                    postdata.ClientCustomerNo = "";
                    postdata.customerGuid = "";

                    var json = new JavaScriptSerializer().Serialize(postdata);


                    streamWriter.Write(json);
                }

                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var result = streamReader.ReadToEnd();

                    List<Product> productList = new JavaScriptSerializer().Deserialize<List<Product>>(result);
                    ViewBag.ProductList = productList;

                }

            }
                ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Cart()
        {
            using (var httpClient = new HttpClient())
            {
                ServicePointManager.SecurityProtocol = ServicePointManager.SecurityProtocol | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
                var url = WebConfigurationManager.AppSettings["baseUrl"] + "getcart";
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
                httpWebRequest.ContentType = "application/json";

                httpWebRequest.Method = "POST";
                httpWebRequest.AutomaticDecompression = DecompressionMethods.Deflate | DecompressionMethods.GZip;
                var content = string.Empty;
                PostData postdata = new PostData();
                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    postdata.ApiKey = "";
                    postdata.UserName = WebConfigurationManager.AppSettings["UserName"];
                    postdata.Password = WebConfigurationManager.AppSettings["Password"];
                    postdata.ClientCustomerNo = "";
                    postdata.customerGuid = "";

                    var json = new JavaScriptSerializer().Serialize(postdata);


                    streamWriter.Write(json);
                }

                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var result = streamReader.ReadToEnd();

                    Cart cart = new JavaScriptSerializer().Deserialize<Cart>(result);
                    ViewBag.Cart = cart;

                }

            }
            ViewBag.Message = "Your contact page.";

            return View();
        }

    }
}