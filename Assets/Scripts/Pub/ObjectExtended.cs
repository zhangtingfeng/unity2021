using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;


public static class ObjectExtended
{
    private static int[] encryptionKey = new int[] {
                            7,
                            3,
                            2,
                            5,
                            4,
                            2,
                            5,
                            5,
                            3
                        };

    /// <summary> 
    /// 同SubString，但是如果超字符范围，会返回部分
    /// 如：
    /// "123".xSubstring(0,4) => "123";
    /// </summary>
    public static string xSubstring(this Object val, int startIndex, int length)
    {
        if (val == null) return "";
        string input = val.ToString();
        string result = "";
        int index = 0;
        int len = 0;

        foreach (var c in input)
        {
            if (index >= startIndex)
            {
                result += c.ToString();
                len++;
            }
            if (len >= length) break;
            index++;
        }

        return result;
    }

    /// <summary>
    /// md5
    /// </summary>
    public static string md5(this Object val)
    {
        HashAlgorithm hashAlgorithm = MD5.Create();
        Encoding encoding = new UTF8Encoding();
        StringBuilder stringBuilder = new StringBuilder();
        byte[] array = hashAlgorithm.ComputeHash(encoding.GetBytes(val.ToString()));
        for (int i = 0; i < array.Length; i++)
        {
            byte b = array[i];
            stringBuilder.Append(b.ToString("x2"));
        }
        return stringBuilder.ToString();
    }

    /// <summary>
    /// 解密
    /// </summary>
    public static string simpleDecrypt(this Object val)
    {
        char[] array = val.ToString().ToCharArray();
        int num = encryptionKey.Length;
        StringBuilder stringBuilder = new StringBuilder();
        for (int i = 0; i < array.Length; i++)
        {
            stringBuilder.Append((char)((int)array[i] - encryptionKey[i % num]));
        }
        return stringBuilder.ToString();
    }

    /// <summary>
    /// 加密
    /// </summary>
    public static string simpleEncrypt(this Object val)
    {
        char[] array = val.ToString().ToCharArray();
        int num = encryptionKey.Length;
        StringBuilder stringBuilder = new StringBuilder();
        for (int i = 0; i < array.Length; i++)
        {
            stringBuilder.Append((char)((int)array[i] + encryptionKey[i % num]));
        }
        return stringBuilder.ToString();
    }

    /// <summary> 
    /// SQL用，Replace("'", "''")
    /// </summary>
    public static string quote(this Object val)
    {
        try
        {
            if (val == null) return "";
            return val.ToString().Replace("'", "''");
        }
        catch (Exception ex)
        {
            //LogController.writeErrorLog(ex, "ObjectExtended quote");
            return "";
        }
    }

    /// <summary>
    /// SQL用，"'" + val.quote() + "'"
    /// </summary>
    public static string sqlString(this Object val)
    {
        try
        {
            return "'" + val.quote() + "'";
        }
        catch (Exception ex)
        {
            //LogController.writeErrorLog(ex, "ObjectExtended sqlString");
            return "''";
        }
    }

    /// <summary>
    /// object转Int32，空或NUll返回0，转换失败时返回0。
    /// </summary>
    public static int toInt32(this Object val)
    {
        try
        {
            if (val == null) return 0;
            if (string.IsNullOrEmpty(val.toString())) return 0;
            return Convert.ToInt32(val);
        }
        catch (Exception ex)
        {
            ////LogController.writeErrorLog(ex, "ObjectExtended toInt32");
            return 0;
        }
    }

    /// <summary>
    /// object转decimal，空或NUll返回0，转换失败时返回0。
    /// </summary>
    public static decimal toDecimal(this Object val)
    {
        try
        {
            if (val == null) return 0;
            if (string.IsNullOrEmpty(val.toString())) return 0;
            return Convert.ToDecimal(val);
        }
        catch (Exception ex)
        {
            //LogController.writeErrorLog(ex, "ObjectExtended toDecimal");
            return 0;
        }
    }

    /// <summary>
    /// object转double，空或NUll返回0，转换失败时返回0。
    /// </summary>
    public static double toDouble(this Object val)
    {
        try
        {
            if (val == null) return 0;
            if (string.IsNullOrEmpty(val.toString())) return 0;
            return Convert.ToDouble(val);
        }
        catch (Exception ex)
        {
            //LogController.writeErrorLog(ex, "ObjectExtended toDouble");
            return 0;
        }
    }

    /// <summary>
    /// object转string，如果是Null会返回空字符串，转换失败时返回空字符串。
    /// </summary>
    public static string toString(this Object val)
    {
        try
        {
            if (val == null) return "";
            return val.ToString();
        }
        catch (Exception ex)
        {
            //LogController.writeErrorLog(ex, "ObjectExtended toString");
            return "";
        }
    }

    /// <summary>
    /// object转DateTime?。
    /// </summary>
    public static DateTime? toDateTime(this Object val)
    {
        try
        {
            if (val == null) return null;
            if (string.IsNullOrEmpty(val.toString())) return null;
            return DateTime.Parse(val.toString());
        }
        catch (Exception ex)
        {
            //LogController.writeErrorLog(ex, "ObjectExtended toDateTime");
            return null;
        }
    }
    /// <summary>
    /// object转DateTime?。
    /// </summary>
    public static DateTime ttoDateTime(this Object val)
    {
        try
        {
            if (val == null) return DateTime.MinValue;
            if (string.IsNullOrEmpty(val.toString())) return DateTime.MinValue;
            return DateTime.Parse(val.toString());
        }
        catch (Exception ex)
        {
            //LogController.writeErrorLog(ex, "ObjectExtended toDateTime");
            return DateTime.MinValue;
        }
    }
    /// <summary>
    /// 对象为1、true、yes、ok时，返回true
    /// 其余情况返回false，转换失败时返回false。
    /// </summary>
    public static bool toBoolean(this Object val)
    {
        try
        {
            if (val == null) return false;
            switch (val.ToString().ToLower())
            {
                case "1":
                case "true":
                case "yes":
                case "ok":
                    return true;
            }
            return false;
        }
        catch (Exception ex)
        {
            //LogController.writeErrorLog(ex, "ObjectExtended toString");
            return false;
        }
    }

    /// <summary>
    /// 对象转换成字符串
    /// </summary>
    public static string toJsonString(this Object val)
    {
        try
        {
            if (val == null) return "";
            return Newtonsoft.Json.JsonConvert.SerializeObject(val);
        }
        catch (Exception ex)
        {
            //LogController.writeErrorLog(ex, "ObjectExtended toJson");
            return "";
        }
    }


    

    /// <summary>
    /// Json.net实现方便的Json转C#（dynamic动态类型）对象
    /// </summary>
    public static Object toJsonDynamicObject(this String val)
    {
        try
        {
            if (val == "") return "";
            return Newtonsoft.Json.JsonConvert.DeserializeObject<Object>(val);
        }
        catch (Exception ex)
        {
            //LogController.writeErrorLog(ex, "ObjectExtended toJson");
            return "";
        }
    }
}

