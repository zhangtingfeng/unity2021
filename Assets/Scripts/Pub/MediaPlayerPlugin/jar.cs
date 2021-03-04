using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class jar : MonoBehaviour
{
    public Camera mainCamera;
    public Camera uiCamera;


    private static AndroidJavaClass androidJavaClass;

    private static AndroidJavaObject androidJavaObject;



    public void getjarMessage(String ddgetjarMessaged)
    {
        Debug.Log(ddgetjarMessaged);
    }
    // Use this for initialization
    public void clickStart()
    {
        try
        {
            //androidJavaObject = new AndroidJavaObject("com.shiyi.u001pinyingame.mediaplayerplugin.TestInstance");
            // String strReturn113331111 = (androidJavaObject.Call<string>("testString"));


            //  androidJavaObject = new AndroidJavaObject("com.shiyi.u001pinyingame.mediaplayerplugin.UnityPlayerActivity");
            //androidJavaObject = new AndroidJavaObject("com.shiyi.u001pinyingame.mediaplayerplugin.UnityPlayerActivity");
            //  androidJavaObject.Call("sendMessageToUnity");




            //androidJavaObject = new AndroidJavaObject("com.shiyi.u001pinyingame.mediaplayerplugin.UnityPlayerActivity");//这个是androidStudio创建的包名加上自己创建的脚本
            //String strReturn111 = androidJavaObject.Call<String>("PreservationSPhoto", "dddddafsdfas");

            AndroidJavaClass androidJavaClassUnityPlayerActivity = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
            AndroidJavaObject androidJavaObjectcurrentActivity = androidJavaClassUnityPlayerActivity.GetStatic<AndroidJavaObject>("currentActivity");
            // String strReturn = androidJavaObject.Call<String>("PreservationSPhototest", "dddddd");
            /**/
            string strFilename = CaptureCamera(mainCamera, uiCamera, new Rect(0, 0, Screen.width, Screen.height));

            Debug.Log(Application.persistentDataPath);

            if (File.Exists(strFilename))
            {
                androidJavaObject = new AndroidJavaObject("com.shiyi.u001pinyingame.mediaplayerplugin.toastDialog");//这个是androidStudio创建的包名加上自己创建的脚本
                androidJavaObject.Call("AlertDialog", androidJavaObjectcurrentActivity, "Title", "Content", 1, "MainCameragetjarMessageReturn", "", "");


                // androidJavaObject = new AndroidJavaObject("com.shiyi.u001pinyingame.mediaplayerplugin.UnityPlayerActivity");//这个是androidStudio创建的包名加上自己创建的脚本
                // androidJavaObject.Call("PreservationSPhoto", strFilename, androidJavaObjectcurrentActivity);


                //string strWindowsHeadPath = Path.Combine((new AndoridSD()).getStoragePath(), "DCIM/fff.jpg");
                //File.Copy(strFilename, strWindowsHeadPath);

                /// androidJavaObject = new AndroidJavaObject("com.unity3d.player.UnityPlayerActivity");//这个是androidStudio创建的包名加上自己创建的脚本
                // Debug_Log.Call_WriteLog("dddd", "dasdf", "untiy");
                // androidJavaObject.Call<string>("PreservationSvideotape", strFilename);

                // string ddPreservationSPhotoTestd = PreservationSPhotoTest(strFilename);
                // Debug_Log.Call_WriteLog(ddPreservationSPhotoTestd, "ddPreservationSPhotoTestd", "untiy");
                // PreservationSPhoto(strFilename);
            }
        }
        catch (Exception EEEE)
        {
            Debug_Log.Call_WriteLog(EEEE, "clickStart", "untiy");

        }

    }

    public void AndroidCallBack(string msg)
    {
        //text.text += msg;
        Debug.Log("msg");
    }


    /// <summary>  
    /// 对相机截图。   
    /// </summary>  
    /// <returns>The screenshot2.</returns>  
    /// <param name="camera">Camera.要被截屏的相机</param>  
    /// <param name="rect">Rect.截屏的区域</param>  
    string CaptureCamera(Camera camera, Camera camera2, Rect rect)
    {
        // 创建一个RenderTexture对象  
        RenderTexture rt = new RenderTexture((int)rect.width, (int)rect.height, -1);
        // 临时设置相关相机的targetTexture为rt, 并手动渲染相关相机  
        camera.targetTexture = rt;
        camera.Render();
        //ps: --- 如果这样加上第二个相机，可以实现只截图某几个指定的相机一起看到的图像。  
        camera2.targetTexture = rt;
        camera2.Render();
        //ps: -------------------------------------------------------------------  
        // 激活这个rt, 并从中中读取像素。  
        RenderTexture.active = rt;
        Texture2D screenShot = new Texture2D((int)rect.width, (int)rect.height, TextureFormat.RGB24, false);
        screenShot.ReadPixels(rect, 0, 0);// 注：这个时候，它是从RenderTexture.active中读取像素  
        screenShot.Apply();

        // 重置相关参数，以使用camera继续在屏幕上显示  
        camera.targetTexture = null;
        camera2.targetTexture = null;
        RenderTexture.active = null; // JC: added to avoid errors  
        GameObject.Destroy(rt);
        // 最后将这些纹理数据，成一个png图片文件  
        byte[] bytes = screenShot.EncodeToJPG();

        string filename = Application.persistentDataPath + "/Screenshot" + DateTime.Now.ToString("yyyyMMDDHHMMSSfff") + ".jpg";
        //filename = Application.persistentDataPath.Substring(0, Application.persistentDataPath.IndexOf("Android"));
        //filename += "Pictures/" + DateTime.Now.ToString("yyyyMMDDHHMMSSfff") + ".jpg";
        System.IO.File.WriteAllBytes(filename, bytes);
        bool ddddd = File.Exists(filename);
        Debug.Log(string.Format("截屏了一张照片: {0}", filename));
        if (!ddddd) filename = "";
        return filename;
    }



    public void CloseUnity()
    {
        SelectPlatform.SendMessage("CloseUnity", "退出U3D");
    }
    public void PreservationSPhoto(string data)
    {
        SelectPlatform.SendMessage("PreservationSPhoto", data);
    }

    public String PreservationSPhotoTest(string data)
    {
        return SelectPlatform.SendMessage("PreservationSPhototest", data).ToString();
    }

    public void PreservationSvideotape(string data)
    {
        SelectPlatform.SendMessage("PreservationSvideotape", data);
    }


}
