﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.IO;

namespace LordOfUltima.Web
{
    class Login
    {
        private static string lastToken = "";
        public string getToken()
        {
            return lastToken;
        }

        private static Login m_ins = null;
        public static Login getInstance()
        {
            if(m_ins == null)
            {
                m_ins = new Login();
            }
            return m_ins;
        }

        public string register(string email, string username, string password)
        {


            var request = (HttpWebRequest)WebRequest.Create("http://api.felixlrc.ca/lou/login/register.php");
            // hash password
            string hashedPass = "";
            using (SHA1Managed sha1 = new SHA1Managed())
            {
                var hash = sha1.ComputeHash(Encoding.UTF8.GetBytes(password));
                var sb = new StringBuilder(hash.Length * 2);

                foreach (byte b in hash)
                {
                    // can be "x2" if you want lowercase
                    sb.Append(b.ToString("X2"));
                }

                hashedPass = sb.ToString();
            }

            try
            {
                var postData = "username=" + username;
                postData += "&email=" + email;
                postData += "&p=" + hashedPass;
                var data = Encoding.ASCII.GetBytes(postData);

                request.Method = "POST";
                request.ContentType = "application/x-www-form-urlencoded";
                request.ContentLength = data.Length;

                using (var stream = request.GetRequestStream())
                {
                    stream.Write(data, 0, data.Length);
                }

                // Envoie de la requete et attente de la reponse
                using (var response = request.GetResponse())
                {
                    // Obtenir le stream de la reponse
                    using (var responseStream = response.GetResponseStream())
                    {
                        StreamReader reader = new StreamReader(responseStream, Encoding.UTF8);
                        String responseString = reader.ReadToEnd();
                        return responseString;
                    }
                }
            }
            catch (WebException ex)
            {
                if (ex.Status == WebExceptionStatus.ProtocolError && ex.Response != null)
                {
                    var resp = (HttpWebResponse)ex.Response;
                    if (resp.StatusCode == HttpStatusCode.NotFound)
                    {
                        Console.WriteLine("404 not found");
                    }
                    else
                    {
                        Console.WriteLine("Other Web Error 1");
                    }
                }
                else
                {
                    Console.WriteLine("Other Web Error 2 (No internet)");
                }
            }
            return "";
        }


        public string login (string email, string password)
        {
            var request = (HttpWebRequest)WebRequest.Create("http://api.felixlrc.ca/lou/login/process_login.php");

            // hash password
            string hashedPass = "";
            using (SHA1Managed sha1 = new SHA1Managed())
            {
                var hash = sha1.ComputeHash(Encoding.UTF8.GetBytes(password));
                var sb = new StringBuilder(hash.Length * 2);

                foreach (byte b in hash)
                {
                    // can be "x2" if you want lowercase
                    sb.Append(b.ToString("X2"));
                }

                hashedPass = sb.ToString();
            }

            try
            {
                var postData = "email=" + email;
                postData += "&p=" + hashedPass;
                var data = Encoding.ASCII.GetBytes(postData);

                request.Method = "POST";
                request.ContentType = "application/x-www-form-urlencoded";
                request.ContentLength = data.Length;

                using (var stream = request.GetRequestStream())
                {
                    stream.Write(data, 0, data.Length);
                }

                // Envoie de la requete et attente de la reponse
                using (var response = request.GetResponse())
                {
                    // Obtenir le stream de la reponse
                    using (var responseStream = response.GetResponseStream())
                    {
                        StreamReader reader = new StreamReader(responseStream, Encoding.UTF8);
                        String[] responseString = reader.ReadToEnd().Split('~');

                        if(responseString.Length > 1)
                        {
                            lastToken = responseString[1];
                            return responseString[0];
                        }
                    }
                }
            }
            catch (WebException ex)
            {
                if (ex.Status == WebExceptionStatus.ProtocolError && ex.Response != null)
                {
                    var resp = (HttpWebResponse)ex.Response;
                    if (resp.StatusCode == HttpStatusCode.NotFound)
                    {
                        Console.WriteLine("404 not found");
                    }
                    else
                    {
                        Console.WriteLine("Other Web Error 1");
                    }
                }
                else
                {
                    Console.WriteLine("Other Web Error 2 (No internet)");
                }
            }

            return "";
        }
    }
}
