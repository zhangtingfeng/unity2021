using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startUICamera : MonoBehaviour {

    // Use this for initialization
    void Start()
    {
        //Screen.SetResolution(1280, 720, true);

        //	Screen.fullScreen = true;  //设置成全屏,
        // string strPath = Path.Combine(StaticGlobal.getLetterPath(), "01.txt");
        //strPath += "/01.txt";


        // string StrContent = Assets.Scripts.Pub.ReadFileTxtContent.ReadText(strPath);
        //Resolution[] resolutions = Screen.resolutions;//获取设置当前屏幕分辩率
        //Debug.Log("resolutions " + resolutions);
        //Screen.SetResolution(resolutions[resolutions.Length - 1].width, resolutions[resolutions.Length - 1].height, true);//设置当前分辨率
        //Screen.fullScreen = true;  //

    }
    // Use this for initialization
    void Awake()
    {
        /*
        if (nguiCamera != null)
        {

            //Debug.Log("dddffff  "+nguiCamera.aspect);

            //nguiCamera.aspect = Screen.width*1.0f / Screen.height;
            //Debug.Log("nguiCamera.aspect =  " + nguiCamera.aspect);
            //myText.text = "Screen.width=" + Screen.width + ",   Screen.height" + Screen.height;
            //Debug.Log("dddffff dddfffff "+nguiCamera.aspect+"   "+Screen.width+"   "+Screen.height);

        }

        if (myText != null)
        {

            //Debug.Log("dddffff  "+nguiCamera.aspect);

            //nguiCamera.aspect = 1280f / 720f;
            myText.text = "Screen.width=" + Screen.width + ",   Screen.height" + Screen.height;
            ///D:\Program Files\Unity20170416\Editor\Data\Mono\lib\mono\unity
            Debug.Log(myText.text);
            try
            {
                //StaticGlobal.getTargetItemListPath();
            }
            catch (System.Exception weee)
            {
                Debug_Log.Call_WriteLog(weee, "加载程序列表报错", "001PinYIn");
            }
            myText.text = Assets.Script.PunPinYin.StaticGlobal.strRootPathList;

            AndoridSD dddd = new AndoridSD();
            //dddd.ReadSD();
            dddd.WriteSD();
            // dddd.getStoragePath();

            //private string getStoragePath()
            //Debug.Log("dddffff dddfffff "+nguiCamera.aspect+"   "+Screen.width+"   "+Screen.height);

        }*/
    }
}
