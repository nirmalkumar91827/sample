using EAGetMail;
using emailread.Models;
using FlickrNet;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Services;

namespace emailread.Controllers
{
    public class HomeController : Controller
    {
        private static string Secret = "023b4e29684dcf0d";
        private static string ConsumerKey = "c33fc02bd0f619445816bc9279948bb7";
        private static string request_token = "";
        public ActionResult Index()
        {
            
            //MailingDetails objMailingDetails = new MailingDetails();
            //objMailingDetails.FromAddress = "nirmalkumar@expsoltechs.com";
            //objMailingDetails.Password = "Nirmal@123";
            //objMailingDetails.POP3Server = "outlook.office365.com";
            //MailServer oServer = new MailServer(objMailingDetails.POP3Server,
            //               objMailingDetails.FromAddress, objMailingDetails.Password, ServerProtocol.Pop3);

            //MailClient oClient = new MailClient("TryIt");

            //oServer.SSLConnection = objMailingDetails.EnableSSL;

            //// Set 993 IMAP4 SSL port
            //oServer.Port = 995;
            //oServer.SSLConnection = true;
            //oClient.Connect(oServer);
            //var fromaddress = "no-reply-powerbi@azureemail.microsoft.com";
            //MailInfo[] objMailInfo = oClient.GetMailInfos();
            //for(var i=0;i< objMailInfo.Length; i++) { 
            //var information = oClient.GetMail(objMailInfo[i]);
            //    if (information.From.Address== fromaddress)
            //    {
            //        var attachment = information.Attachments;
            //    }
            
            //}
            string requestString = "https://www.flickr.com/services/oauth/request_token";
            Random rand = new Random();
            string nonce = rand.Next(999999).ToString();
            string timestamp = GetTimestamp();
            string parameters = "oauth_callback=" + Models.UrlHelper.Encode("http://localhost:50462/Home/Gettoken/");
            parameters += "&oauth_consumer_key=" + ConsumerKey;
            parameters += "&oauth_nonce=" + nonce;
            parameters += "&oauth_signature_method=HMAC-SHA1";
            parameters += "&oauth_timestamp=" + timestamp;
            parameters += "&oauth_version=1.0";
            string signature = generateSignature("GET", requestString, parameters);
            string url = requestString + "?" + parameters + "&oauth_signature=" + signature;
            WebClient web = new WebClient();
            string result = web.DownloadString(url);

            string[] splitresult = result.Split(new[] { "&oauth_token=" }, StringSplitOptions.None);
            
            string[] splitresult1 = result.Split(new[] { "&oauth_token_secret=" }, StringSplitOptions.None);
            string get_oauth_token = splitresult[1];
            string oauth_token_secret = splitresult1[1];
            string[] splitresult2 = get_oauth_token.Split(new[] { "&" }, StringSplitOptions.None);
            string oauth_token = splitresult2[0];
            HttpCookie myCookie = new HttpCookie("oauth_token_secret");
            myCookie.Value = oauth_token_secret;
            Response.Cookies.Add(myCookie);
            string authorize = "https://www.flickr.com/services/oauth/authorize";
            string authorizeurl = authorize + "?" + "oauth_token="+oauth_token+ "&perms=write";

            Response.Redirect(authorizeurl);
            return View();
        }

        private static string generateSignature(string httpMethod, string ApiEndpoint, string parameters)
        {
            string encodedUrl = Models.UrlHelper.Encode(ApiEndpoint);
            string encodedParameters = Models.UrlHelper.Encode(parameters);
            string basestring = httpMethod + "&" + encodedUrl + "&";
            parameters = Models.UrlHelper.Encode(parameters);
            basestring = basestring + parameters;
            System.Text.ASCIIEncoding encoding = new System.Text.ASCIIEncoding();
            string key = Secret + "&" + request_token;
            byte[] keyByte = encoding.GetBytes(key);
            byte[] messageBytes = encoding.GetBytes(basestring);
            HMACSHA1 hmacsha1 = new HMACSHA1(keyByte);
            byte[] hashmessage = hmacsha1.ComputeHash(messageBytes);
            string signature = System.Convert.ToBase64String(hashmessage);
              return Models.UrlHelper.Encode(signature);
        }
        public static String GetTimestamp()
        {
            int epoch = (int)(DateTime.UtcNow - new DateTime(2017, 7, 7)).TotalSeconds;
            return epoch.ToString();
        }

        [WebMethod]
        public string Gettoken(string oauth_token,  string oauth_verifier)
        {
            HttpCookie cookie = Request.Cookies["oauth_token_secret"];

            request_token = cookie.Value;
            string accessString = "https://www.flickr.com/services/oauth/access_token";
            Random rand = new Random();
            string nonce = rand.Next(999999).ToString();
            string timestamp = GetTimestamp();

            string accesstokenparameters = "oauth_consumer_key=" + ConsumerKey.Trim();
            accesstokenparameters += "&oauth_nonce=" + nonce.Trim();
            accesstokenparameters += "&oauth_signature_method=HMAC-SHA1";
            accesstokenparameters += "&oauth_timestamp=" + timestamp.Trim();
            accesstokenparameters += "&oauth_token=" + oauth_token.Trim();
            accesstokenparameters += "&oauth_verifier=" + oauth_verifier.Trim();
            accesstokenparameters += "&oauth_version=1.0";
            string signature = generateSignature("GET", accessString, accesstokenparameters);

          
            accesstokenparameters = "oauth_nonce=" + nonce.Trim();
            accesstokenparameters += "&oauth_timestamp=" + timestamp.Trim();
            accesstokenparameters += "&oauth_verifier=" + oauth_verifier.Trim();
            accesstokenparameters += "&oauth_consumer_key=" + ConsumerKey.Trim();
            accesstokenparameters += "&oauth_signature_method=HMAC-SHA1";
            accesstokenparameters += "&oauth_version=1.0";
            accesstokenparameters += "&oauth_token=" + oauth_token.Trim();
            accesstokenparameters += "&oauth_signature=" + signature.Trim();
            string accesstokenurl = accessString.Trim() + "?" + accesstokenparameters.Trim();



            //HttpWebRequest request = (HttpWebRequest)WebRequest.Create(accesstokenurl);
            //request.Method = "GET";
            //request.ContentLength = 0;
            //request.AllowAutoRedirect = false;
            //request.Timeout = 60000;
            //HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            //using (StreamReader sr = new StreamReader(response.GetResponseStream()))
            //{
            // string   strResult = sr.ReadToEnd();

            //}

            WebClient web = new WebClient();
            string result = web.DownloadString(accesstokenurl);
            string[] splitresult = result.Split(new[] { "&" }, StringSplitOptions.None);
            string accessoauthtoken = splitresult[1];
            string[] splitaccessoauthtoken = accessoauthtoken.Split(new[] { "oauth_token=" }, StringSplitOptions.None);
            oauth_token = splitaccessoauthtoken[1];
            string accessoauthtokensecrect = splitresult[2];
            string[] splitaccessoauthtokensecrect = accessoauthtokensecrect.Split(new[] { "oauth_token_secret=" }, StringSplitOptions.None);
            string oauth_token_secret = splitaccessoauthtokensecrect[1];
            Flickr flickr = new Flickr();
            flickr.ApiKey = ConsumerKey;
            flickr.ApiSecret = Secret;
            flickr.OAuthAccessTokenSecret = oauth_token_secret;
            flickr.OAuthAccessToken = oauth_token;
            string FileuploadedID = flickr.UploadPicture(@"C:\Users\EST0104\Downloads\download (6).jpg", "TwittingRoom", "TwittingRoom Image", "ClientName", true, false, false);
            PhotoInfo oPhotoInfo = flickr.PhotosGetInfo(FileuploadedID);
            string FileULR = oPhotoInfo.LargeUrl;
            Response.Write(FileULR);
            return string.Empty;
        }
    }

    }
