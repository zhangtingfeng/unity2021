using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Net;
using UnityEngine;

/// <summary>
///Subscribe 的摘要说明
/// </summary>
public class Debug_Log
{
    /// <summary>
    /// 写日志(用于跟踪)
    /// </summary>
    public static string Call_WriteLog(object errorCall_WriteLog, string strLogs_SubSubject = "", string strTypename = "")
    {
        string strReturn = "";
        try
        {
            string strJsonSerializer = Newtonsoft.Json.JsonConvert.SerializeObject(errorCall_WriteLog);


            Call_WriteLog(strJsonSerializer, strLogs_SubSubject+"对象序列化", strTypename);
        }
        catch
        {
        }
        finally
        {
            //if (sr != null)
            //    sr.Close();
        }
        return strReturn;
    }

    /// <summary>
    /// 写日志(用于跟踪)
    /// </summary>
    public static string Call_WriteLog(Exception error, string strLogs_SubSubject = "", string strTypename = "")
    {
        string strReturn = "";
        try
        {
            DateTime dt = DateTime.Now;
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼");
            sb.AppendLine("Error Msg：" + error.GetBaseException().Message);
            sb.AppendLine("Stack：" + error.GetBaseException().StackTrace);
            sb.AppendLine("Ect：");
            sb.AppendLine(error.Message.ToString());
            sb.AppendLine(error.Source);
            sb.AppendLine(error.StackTrace);
            sb.AppendLine("▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲");
            string strXML = sb.ToString();
            string strMemo = dt.ToString("yyyy-MM-dd HH:mm:ss fff") + ":" + strXML;
            strReturn = strMemo;

            Call_WriteLog(strMemo, strLogs_SubSubject + "程序报错", strTypename);
        }
        catch
        {
        }
        finally
        {
            //if (sr != null)
            //    sr.Close();
        }
        return strReturn;
    }


    /// <summary>
    /// 写日志(用于跟踪)
    /// </summary>
    public static void Call_WriteLog(string strXML, string strLogs_SubSubject = "", string strTypename = "")
    {
        // ClLogHelper.WriteLog(strXML.GetType(), strLogs_SubSubject + strXML);

        try
        {


            //System.Threading.Tasks.Task.Factory.StartNew(() =>
            //{
            string strPostURL = "http://productlog.eggsoft.cn/Api/LogsEveryDay/Write_Log";
            if (!string.IsNullOrEmpty(strPostURL))
            {
                if (string.IsNullOrEmpty(strTypename)) strTypename = "Unity";
                if (string.IsNullOrEmpty(strLogs_SubSubject)) strLogs_SubSubject = "默认";

                Logs_EveryDay thisLogs_EveryDay = new Logs_EveryDay();
                thisLogs_EveryDay.Logs_Subject = strTypename;
                thisLogs_EveryDay.Logs_SubSubject = strLogs_SubSubject;
                thisLogs_EveryDay.Logs_Content = strXML;

                try
                {
                    string strJsonSerializer = Newtonsoft.Json.JsonConvert.SerializeObject(thisLogs_EveryDay);
                    String ster = HttpWebRequest_WebRequest_Post_JSON(strPostURL, strJsonSerializer);

                }
                //catch (Exception eee)
                //{
                //    ///
                //}
                finally
                {
                    //if (sr != null)
                    //    sr.Close();
                }
            }
            //});
        }
        catch
        {
        }
        finally
        {
            //if (sr != null)
            //    sr.Close();
        }
    }

    public static string HttpWebRequest_WebRequest_Post_JSON(string strURL, string strJSON)
    {
        WebRequest httpWebRequest = WebRequest.Create(strURL);
        httpWebRequest.ContentType = "text/json";
        httpWebRequest.Method = "POST";
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
}

public class Logs_EveryDay
{
    /// <summary>
    /// 响应结果信息
    /// </summary>
    //[JsonProperty("Logs_Subject")]
    public string Logs_Subject { get; set; }

    /// <summary>
    /// 响应结果信息 标题次级标题
    /// </summary>
    //[JsonProperty("Logs_SubSubject")]
    public string Logs_SubSubject { get; set; }
    /// <summary>
    /// 生成的签名串
    /// </summary>
    //[JsonProperty("Logs_Content")]
    public string Logs_Content { get; set; }
}




