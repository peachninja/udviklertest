using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Configuration;
using System.Web.Script.Serialization;
using UdviklerTest.Models;

namespace UdviklerTest.Services
{
    public class ProductServices
    {
        public int AddProduct(string productGuid)
        {
            using (var httpClient = new HttpClient())
            {
                ServicePointManager.SecurityProtocol = ServicePointManager.SecurityProtocol | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
                var url = WebConfigurationManager.AppSettings["baseUrl"] + "addproductstocart";
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
                httpWebRequest.ContentType = "application/json";

                httpWebRequest.Method = "POST";
                httpWebRequest.AutomaticDecompression = DecompressionMethods.Deflate | DecompressionMethods.GZip;
                var content = string.Empty;
                PostData postdata = new PostData();

                List<ProductQuantity> productQuantityList = new List<ProductQuantity>();
                ProductQuantity productToAdd = new ProductQuantity();
                productToAdd.ProductId = productGuid;
                productToAdd.Quantity = 1;
                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    postdata.ApiKey = "";
                    postdata.UserName = WebConfigurationManager.AppSettings["UserName"];
                    postdata.Password = WebConfigurationManager.AppSettings["Password"];
                    postdata.ClientCustomerNo = "";
                    postdata.customerGuid = "";
                    postdata.ProductQuantities = productQuantityList;

                    var json = new JavaScriptSerializer().Serialize(postdata);


                    streamWriter.Write(json);
                }

                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var result = streamReader.ReadToEnd();


                }
                return (int)httpResponse.StatusCode;

            }
        }
    }
}