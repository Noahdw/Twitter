﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Net;
using System.IO;

namespace MaybeSomethingCOOL
{
    class TwitterAuthPostService
    {
        string oauthConsumerKey;
        string oauthConsumerSecret;
        string oauthSignatureMethod;
        string oauthVersion;
        string oauthToken;
        string oauthTokenSecret;
        string _oauthNonce;
        string _oathTimestamp;
        public string url = "https://api.twitter.com/1.1/statuses/update.json";

        public string CreateSignature(string status)
        {

            oauthConsumerKey = "lraInGL0JA4JfvvoFED4CStzG";
            oauthConsumerSecret = "RiPBzFx0GrgQIE5YYNcLyMardJcDHZoyyI6E6y99ZoLlGWAJjI";
            oauthSignatureMethod = "HMAC-SHA1";
            oauthVersion = "1.0";
            oauthToken = "588880830-vBsV151ByUhPHP50NMcna20tkL062BLSS0Nmu6t8";
            oauthTokenSecret = "DRDgvAiAsfr1xZdvIOij5zqNlGOdVREq8NBoacxtIizpp";
            _oauthNonce = Convert.ToBase64String(new ASCIIEncoding().GetBytes(DateTime.Now.Ticks.ToString()));
            TimeSpan ts = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            _oathTimestamp = Convert.ToInt64(ts.TotalSeconds).ToString();
            


            // create oauth signature
            var baseFormat = "oauth_consumer_key={0}&oauth_nonce={1}&oauth_signature_method={2}" +
                        "&oauth_timestamp={3}&oauth_token={4}&oauth_version={5}&status={6}";

            var baseString = string.Format(baseFormat,
                                   oauthConsumerKey,
                                   _oauthNonce,
                                   oauthSignatureMethod,
                                   _oathTimestamp,
                                   oauthToken,
                                   oauthVersion,
                                   Uri.EscapeDataString(status)
                                   );

            baseString = string.Concat("POST&", Uri.EscapeDataString(url), "&", Uri.EscapeDataString(baseString));
            Console.WriteLine(baseString);

            //generation the signature key the hash will use
            string signatureKey =
                Uri.EscapeDataString(oauthConsumerSecret) + "&" + Uri.EscapeDataString(oauthTokenSecret);

            var hmacsha1 = new HMACSHA1(
                new ASCIIEncoding().GetBytes(signatureKey));

            //hash the values
            string signatureString = Convert.ToBase64String(
                hmacsha1.ComputeHash(
                    new ASCIIEncoding().GetBytes(baseString)));

            
            return signatureString;
           
        }

        public string CreateAuthorizationHeaderParameter(string signature)
        {
            string authorizationHeaderParams = String.Empty;
            authorizationHeaderParams += "OAuth ";

            authorizationHeaderParams += "oauth_consumer_key="
                                         + "\"" + Uri.EscapeDataString(oauthConsumerKey) + "\",";

            authorizationHeaderParams += "oauth_nonce=" + "\"" +
                                         Uri.EscapeDataString(_oauthNonce) + "\",";

            authorizationHeaderParams += "oauth_signature=" + "\""
                                         + Uri.EscapeDataString(signature) + "\",";

            authorizationHeaderParams +=
                "oauth_signature_method=" + "\"" +
                Uri.EscapeDataString(oauthSignatureMethod) +
                "\",";

            authorizationHeaderParams += "oauth_timestamp=" + "\"" +
                                         Uri.EscapeDataString(_oathTimestamp) + "\",";
            


            authorizationHeaderParams += "oauth_token=" + "\"" +
                                         Uri.EscapeDataString(oauthToken) + "\",";



            authorizationHeaderParams += "oauth_version=" + "\"" +
                                         Uri.EscapeDataString(oauthVersion) + "\"";
            return authorizationHeaderParams;


        }

        


    }
}


        






