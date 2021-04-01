using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using UnityEngine;

namespace Assets.Script
{



    public class JsonResultImage
    {
        public String base64 { get; set; }
        public String filename { get; set; }
        public String account { get; set; }
    }


    public class JsonResult
    {
        public int code { get; set; }
        public String msg { get; set; }

        public JsonResultImage data { get; set; }
    }

    public class oliverImage
    {



        //写入ini文件
        public static void SaveBMPContent(string Base64Code, string filepath)
        {
            byte[] ddddd = Convert.FromBase64String(Base64Code);
            using (MemoryStream ms2 = new MemoryStream(ddddd))
            {
                Debug.Log(filepath);
                Debug_Log.Call_WriteLog(filepath, "SaveBMPContent", "unity");
                //System.Drawing.Bitmap bmp2 = new System.Drawing.Bitmap(ms2);
                // bmp2.Save(filepath, System.Drawing.Imaging.ImageFormat.Png);
                File.WriteAllBytes(filepath, ddddd);
            }
        }
        /// <summary>
        /// 上传云盘ztf
        /// </summary>
        /// <param name="Base64Code"></param>
        /// <param name="filepath"></param>
        public static JsonResult SaveToCloud(string Base64Code, string filepath)
        {

            JsonResult JsonResultReturn = new JsonResult();
            try
            {
                //System.Text.StringBuilder builder = new System.Text.StringBuilder();
                //int i = 0;
                //builder.Append("");
                //builder.AppendFormat("{\"data\":{\"yyy\":1,\"filename\":\"{0}\",\"base64\":\"(1)\"}}", (filepath), (Base64Code));
                //builder.Append("");
                //string strJsonSerializer = builder.ToString();

                JsonResultImage ddJsonResultImagedd = new JsonResultImage
                {
                    base64 = ("data:image/jpg;base64," +Base64Code),
                    filename = filepath,
                     account= Application.platform.toString()

                };
                JsonResult dddJsonResult = new JsonResult
                {
                    data = ddJsonResultImagedd
                };

              
                string strJsonSerializer = Newtonsoft.Json.JsonConvert.SerializeObject(dddJsonResult);
                Debug_Log.Call_WriteLog(strJsonSerializer, "SaveToCloud", "unity");


                String strPostURL = "http://api.edu.eggsoft.cn";
                //strPostURL = "http://219.235.6.205:48001";
                //strPostURL = "http://localhost:48001";
                String strheadRouter = "tools-service/uploads/upload3";
                String ster = Http___WebRequest_WebRequest_Post_JSON(strPostURL, strheadRouter, strJsonSerializer);
                Debug_Log.Call_WriteLog(ster, "SaveToCloudError", "unity");
                JsonResultReturn = Newtonsoft.Json.JsonConvert.DeserializeObject<JsonResult>(ster);
                return JsonResultReturn;

            }

            catch (Exception eeee)
            {
                Debug_Log.Call_WriteLog(eeee, "SaveToCloud", "unity");
                JsonResultReturn.code = 400;
                JsonResultReturn.msg = eeee.Message;
                return JsonResultReturn;
            }
        }


        public static string CompressString(string str)
        {
            var compressBeforeByte = Encoding.GetEncoding("UTF-8").GetBytes(str);
            var compressAfterByte = Compress(compressBeforeByte);
            string compressString = Convert.ToBase64String(compressAfterByte);
            return compressString;
        }

        public static string DecompressString(string str)
        {
            var compressBeforeByte = Convert.FromBase64String(str);
            var compressAfterByte = Decompress(compressBeforeByte);
            string compressString = Encoding.GetEncoding("UTF-8").GetString(compressAfterByte);
            return compressString;
        }

        /// <summary>
        /// Compress
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        private static byte[] Compress(byte[] data)
        {
            try
            {
                var ms = new MemoryStream();
                var zip = new GZipStream(ms, CompressionMode.Compress, true);
                zip.Write(data, 0, data.Length);
                zip.Close();
                var buffer = new byte[ms.Length];
                ms.Position = 0;
                ms.Read(buffer, 0, buffer.Length);
                ms.Close();
                return buffer;

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Decompress
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        private static byte[] Decompress(byte[] data)
        {
            try
            {
                var ms = new MemoryStream(data);
                var zip = new GZipStream(ms, CompressionMode.Decompress, true);
                var msreader = new MemoryStream();
                var buffer = new byte[0x1000];
                while (true)
                {
                    var reader = zip.Read(buffer, 0, buffer.Length);
                    if (reader <= 0)
                    {
                        break;
                    }
                    msreader.Write(buffer, 0, reader);
                }
                zip.Close();
                ms.Close();
                msreader.Position = 0;
                buffer = msreader.ToArray();
                msreader.Close();
                return buffer;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        private static string Http___WebRequest_WebRequest_Post_JSON(string strURL,string strheadRouter, string strJSON)
        {
            try
            {
                WebRequest httpWebRequest = WebRequest.Create(strURL);

                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "POST";
                httpWebRequest.Headers.Add("headRouter", strheadRouter);
                var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream());

                streamWriter.Write(strJSON);
                streamWriter.Flush();
                streamWriter.Close();

                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                var streamReader = new StreamReader(httpResponse.GetResponseStream());
                string resultstring = streamReader.ReadToEnd();
                streamReader.Close();
                //Eggsoft.Common.JsUtil.ShowMsg(resultstring);
                return resultstring;
            }
            catch (Exception eee)
            {
                Debug_Log.Call_WriteLog(eee, "SaveToCloudHttp___WebRequest_WebRequest_Post_JSON", "unity");
                return eee.Message;
            }

        }


        private static string StringAsJsonString(string str)
        {
            System.Text.StringBuilder builder = null;
            for (int i = 0; i < str.Length; ++i)
            {
                switch (str[i])
                {
                    case '"':
                        if (builder == null)
                            builder = new System.Text.StringBuilder(str.Substring(0, i));
                        builder.Append("\\\"");
                        break;
                    case '\\':
                        if (builder == null)
                            builder = new System.Text.StringBuilder(str.Substring(0, i));
                        builder.Append("\\\\");
                        break;
                    case '/':
                        if (builder == null)
                            builder = new System.Text.StringBuilder(str.Substring(0, i));
                        builder.Append("\\/");
                        break;
                    case '\b':
                        if (builder == null)
                            builder = new System.Text.StringBuilder(str.Substring(0, i));
                        builder.Append("\\b");
                        break;
                    case '\f':
                        if (builder == null)
                            builder = new System.Text.StringBuilder(str.Substring(0, i));
                        builder.Append("\\f");
                        break;
                    case '\n':
                        if (builder == null)
                            builder = new System.Text.StringBuilder(str.Substring(0, i));
                        builder.Append("\\n");
                        break;
                    case '\r':
                        if (builder == null)
                            builder = new System.Text.StringBuilder(str.Substring(0, i));
                        builder.Append("\\r");
                        break;
                    case '\t':
                        if (builder == null)
                            builder = new System.Text.StringBuilder(str.Substring(0, i));
                        builder.Append("\\t");
                        break;
                    default:
                        if (builder != null)
                            builder.Append(str[i]);
                        break;
                }
            }
            if (builder != null)
                return builder.ToString();
            else
                return str;
        }

    }
}
