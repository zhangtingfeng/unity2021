package com.shiyi.u001pinyingame.mediaplayerplugin;


import com.google.gson.Gson;

import org.json.JSONException;
import org.json.JSONObject;

import java.io.ByteArrayOutputStream;
import java.io.IOException;
import java.io.InputStream;
import java.io.OutputStream;
import java.net.HttpURLConnection;
import java.net.URL;
import java.net.URLEncoder;
import java.text.ParseException;
import java.util.Map;



 class Logs_EveryDay
{

    public String Logs_Subject ;

    public String Logs_SubSubject ;

    public String Logs_Content ;
}



public class debugLog {

    public static String send(Exception Exceptioneee, String Logs_SubSubject, String Logs_Subject) throws ParseException, IOException, JSONException {


        return send(Exceptioneee.getMessage(),Logs_SubSubject+"---jar程序报错",Logs_Subject);

    }

    /**
     * 发送post请求
     *
     * @param Logs_Subject    路径
     * @param Logs_SubSubject 参数(json类型)
     * @param Logs_Content    编码格式
     * @return
     * @throws ParseException
     * @throws IOException
     */
    public static String send(String Logs_Content, String Logs_SubSubject, String Logs_Subject) throws ParseException, IOException, JSONException {

        Logs_EveryDay thisLogs_EveryDay = new Logs_EveryDay();
        thisLogs_EveryDay.Logs_Subject = Logs_Subject;
        thisLogs_EveryDay.Logs_SubSubject = Logs_SubSubject;
        thisLogs_EveryDay.Logs_Content = Logs_Content;


       return LoginByPost(new Gson().toJson(thisLogs_EveryDay));

    }

    public static String send(Object Logs_Content,String Logs_SubSubject, String Logs_Subject) throws ParseException, IOException, JSONException {
       // 先将java对象转换为json对象，在将json对象转换为json字符串
        //JSONObject json = JSONObject.toJSON(Logs_Content);//将java对象转换为json对象
        //String str = json.toString();//将json对象转换为字符串


        //String jsonString = com.alibaba.fastjson.JSON.toJSONString(Logs_Content);
      return  send(new Gson().toJson(Logs_Content),Logs_SubSubject+"jar对象序列化",Logs_Subject);
    }






    public static String LOGIN_URL = "http://productlog.eggsoft.cn/Api/LogsEveryDay/Write_Log";
    private static String LoginByPost(String stringBody)
    {
        String msg = "";
        try{
            HttpURLConnection conn = (HttpURLConnection) new URL(LOGIN_URL).openConnection();
            //设置请求方式,请求超时信息
            conn.setRequestMethod("POST");
            conn.setReadTimeout(5000);
            conn.setConnectTimeout(5000);
            //设置运行输入,输出:
            conn.setDoOutput(true);
            conn.setDoInput(true);
            //Post方式不能缓存,需手动设置为false
            conn.setUseCaches(false);
            conn.setRequestProperty("Content-Type", "application/json");

            //我们请求的数据:
            //String data = "passwd="+ URLEncoder.encode(passwd, "UTF-8")+
                    //"&number="+ URLEncoder.encode(number, "UTF-8");
            String data =stringBody;
            //这里可以写一些请求头的东东...
            //获取输出流
            OutputStream out = conn.getOutputStream();
            out.write(data.getBytes());
            out.flush();
            if (conn.getResponseCode() == 200) {
                // 获取响应的输入流对象
                InputStream is = conn.getInputStream();
                // 创建字节输出流对象
                ByteArrayOutputStream message = new ByteArrayOutputStream();
                // 定义读取的长度
                int len = 0;
                // 定义缓冲区
                byte buffer[] = new byte[1024];
                // 按照缓冲区的大小，循环读取
                while ((len = is.read(buffer)) != -1) {
                    // 根据读取的长度写入到os对象中
                    message.write(buffer, 0, len);
                }
                // 释放资源
                is.close();
                message.close();
                // 返回字符串
                msg = new String(message.toByteArray());
                return msg+stringBody;
            }
        }catch(Exception e){
            msg=e.getMessage();

        }
        return msg;
    }
}
