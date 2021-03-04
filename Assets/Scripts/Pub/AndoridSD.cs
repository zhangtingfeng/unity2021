using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AndoridSD
{

    // Use this for initialization


    public void WriteSD()
    {
        try
        {
            ReadSD();
            AndroidJavaClass jc = new AndroidJavaClass("com.pico.Integration.ThirdActivity");
            //AndroidJavaObject jo = jc.GetStatic<AndroidJavaObject>("currentActivity");

            //            string s1 = jc.CallStatic<string>("WriteSD", "/storage/0000-E33A/Download/mysdcard2.txt");
            string s1 = jc.CallStatic<string>("WriteSD", getStoragePath() + "/mysdcard2.txt");
            Debug_Log.Call_WriteLog(getStoragePath(), "getStoragePath()", "001PinYIn");
            Debug_Log.Call_WriteLog(getStoragePath() + "/mysdcard2.txt", "getStoragePath()mysdcard2", "001PinYIn");
            Debug_Log.Call_WriteLog(s1, "s1", "001PinYIn");

        }
        catch (System.Exception e)
        {
            Debug_Log.Call_WriteLog(e, "s1", "001PinYIn");


        }




    }
    public void ReadSD()
    {
        try
        {
            AndroidJavaClass jc = new AndroidJavaClass("com.pico.Integration.ThirdActivity");
            // AndroidJavaObject jo = jc.GetStatic<AndroidJavaObject>("currentActivity");

            string s01 = jc.CallStatic<string>("ReadSD", getStoragePath() + "/hgignore_global.txt");
            Debug_Log.Call_WriteLog(s01, getStoragePath() + "/hgignore_global.txt", "001PinYIn");


        }
        catch (System.Exception e)
        {
            Debug_Log.Call_WriteLog(e, "ReadSD报错", "001PinYIn");

        }

    }

    public string getStoragePath()
    {
        string s2getStoragePath = "";
        try
        {

            AndroidJavaClass jc = new AndroidJavaClass("com.pico.Integration.ThirdActivity");
            s2getStoragePath = jc.CallStatic<string>("getStoragePath", true);
            Debug_Log.Call_WriteLog(s2getStoragePath, "s2getStoragePath", "001PinYIn");

        }
        catch (System.Exception e)
        {

            s2getStoragePath = Debug_Log.Call_WriteLog(e, "Test333", "001PinYIn");
        }
        return s2getStoragePath;
    }

    public void Restart()
    {
        AndroidJavaClass jc = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
        AndroidJavaObject mainActivity = jc.GetStatic<AndroidJavaObject>("currentActivity");
        mainActivity.Call("doRestart", 1);
        jc.Dispose();
        mainActivity.Dispose();
    }

}
