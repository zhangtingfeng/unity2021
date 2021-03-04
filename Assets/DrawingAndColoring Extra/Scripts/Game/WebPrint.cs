using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.IO;
using System;
using Assets.Script.PunPinYin;
using Assets.Script;

///Developed by Indie Studio
///https://www.assetstore.unity3d.com/en/#!/publisher/9268
///www.indiestd.com
///info@indiestd.com

namespace IndieStudio.DrawingAndColoring.Logic
{
    public class WebPrint : MonoBehaviour
    {
        /// <summary>
        /// Whether process is running or not.
        /// </summary>
        public static bool isRunning;

        /// <summary>
        /// The flash effect fade.
        /// </summary>
        public Animator flashEffect;

        /// <summary>
        /// The flash sound effect.
        /// </summary>
        public AudioClip flashSFX;

        /// <summary>
        /// The objects bet hide/show on screen capturing.
        /// </summary>
        public Transform[] objects;

        /// <summary>
        /// The logo on the bottom of the page.
        /// </summary>
        public Transform bottomLogo;


        void Start()
        {
            isRunning = false;
        }

        /// <summary>
        /// Print the screen.
        /// </summary>
        public void PrintScreen()
        {
#if (UNITY_WEBPLAYER || UNITY_WEBGL || UNITY_EDITOR || UNITY_ANDROID)
            Debug.LogWarning("Print feature works only in the Web platform, check out the Manual.pdf to implement print feature...");
            StartCoroutine("PrintScreenCoroutine");
#endif
        }

        public IEnumerator PrintScreenCoroutine()
        {
            isRunning = true;

            HideObjects();
            if (bottomLogo != null)
                bottomLogo.gameObject.SetActive(true);

            //Capture screen shot
            yield return new WaitForEndOfFrame();
            Texture2D texture = new Texture2D(Screen.width, Screen.height);
            texture.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0);
            texture.Apply();

            flashEffect.SetTrigger("Run");
            if (flashSFX != null)
                AudioSource.PlayClipAtPoint(flashSFX, Vector3.zero, 1);
            yield return new WaitForSeconds(1);
            ShowObjects();
            try
            {
                if (bottomLogo != null)
                    bottomLogo.gameObject.SetActive(false);
                string strToBase64String = System.Convert.ToBase64String(texture.EncodeToJPG());
                string imageName = "DrawingAndColoring-" + System.DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss");
                imageName += ".jpg";
                string strgetLetterRecordPath = StaticGlobal.getLetterRecordPath();

                string strPath = Path.Combine(strgetLetterRecordPath, imageName);
                Assets.Script.oliverImage.SaveBMPContent(strToBase64String, strPath);
                Debug_Log.Call_WriteLog(strPath, "SaveBMPContentOK", "Unity");
#if UNITY_ANDROID
                AndroidJavaClass androidJavaClassUnityPlayerActivity = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
                AndroidJavaObject androidJavaObjectcurrentActivity = androidJavaClassUnityPlayerActivity.GetStatic<AndroidJavaObject>("currentActivity");

                AndroidJavaObject androidJavaObject = new AndroidJavaObject("com.shiyi.u001pinyingame.mediaplayerplugin.UnityPlayerActivity");//这个是androidStudio创建的包名加上自己创建的脚本
                // androidJavaObject.Call("PreservationSPhoto", strPath, androidJavaObjectcurrentActivity);
                string strError = androidJavaObject.Call<String>("PreservationSPhoto", strPath, androidJavaObjectcurrentActivity);
                Debug_Log.Call_WriteLog(strError, "SaveBMPContentOKstrError", "Unity");
                if (strError == "save ok")
                {
                    androidJavaObject = new AndroidJavaObject("com.shiyi.u001pinyingame.mediaplayerplugin.toastDialog");//这个是androidStudio创建的包名加上自己创建的脚本
                    androidJavaObject.Call("ToastMakeText", "已经保存进相册", androidJavaObjectcurrentActivity);
                }

#elif UNITY_EDITOR || UNITY_EDITOR_WIN || UNITY_STANDALONE_WIN
                string strMyPicturesPath = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
                string strMyPicturesPathFile = Path.Combine(strMyPicturesPath, imageName);
                File.Copy(strPath, strMyPicturesPathFile);
                MessageBOX.MessageBox(System.IntPtr.Zero, "已经保存进我的图片", "绘画保存", 0);
#endif

                //Application.ExternalCall("PrintImage", strToBase64String, imageName);


            }
            catch (Exception eeee)
            {
                Debug_Log.Call_WriteLog(eeee, "PrintScreenCoroutine", "unity");
            }
            isRunning = false;

        }


        

        /// <summary>
        /// Hide the objects.
        /// </summary>
        private void HideObjects()
        {
            if (objects == null)
            {
                return;
            }

            foreach (Transform obj in objects)
            {
                if (obj != null)
                    obj.gameObject.SetActive(false);
            }
        }

        /// <summary>
        /// Show the objects.
        /// </summary>
        private void ShowObjects()
        {
            if (objects == null)
            {
                return;
            }

            foreach (Transform obj in objects)
            {
                obj.gameObject.SetActive(true);
            }
        }
    }
}