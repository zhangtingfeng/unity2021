using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Script.PunPinYin
{
    /// <summary>
    /// 全局通用变量
    /// </summary>
    public class StaticGlobal

    {
        /// <summary>
        /// Choice
        /// </summary>
        public static StaticTrainingobj gStaticTrainingobj = null;
        /// <summary>
        /// 训练的目标词  缺省目录
        /// </summary>
        public static String RootWindowPath = "externalResources/001GameResource";
        /// <summary>
        /// 训练的目标词  缺省目标目录 
        /// </summary>
        public static String SelectDestinationTargetWord = "b";
        /// <summary>
        /// 训练的目标项
        /// </summary>
        public static String SelectDestinationTargetItem = "01OneSyllable";
        /// <summary>
        /// 训练的目标项 顺序
        /// </summary>
        //public static String SelectTargetItemNum = "01";

        /// <summary>
        /// 目标词的路径
        /// </summary>
        public static DirectoryInfo[] TargetItemListPathList = null;
        /// <summary>
        /// debug使用
        /// </summary>
        public static string strRootPathList = "";
        /// <summary>
        /// 训练的用户的当前训练ID，
        /// </summary>
        public static int TrainID = 0;

        /// <summary>
        /// 训练开始时间，
        /// </summary>
        public static DateTime startTime = DateTime.MinValue;

        /// <summary>
        /// 训练持续时间
        /// </summary>
        public static Int64 TimeDuratation = 0;

        /// <summary>
        /// 扫描发现的物体
        /// </summary>
        public static String ScanObjectPngName = "";


        /// <summary>
        /// play video set mp4 path
        /// </summary>
        public static String playVideoSetMp4Path = "";


        /// <summary>
        /// play video set mp4 path
        /// </summary>
        public static int playVideoSetThisOlderNum = -1;

        /// <summary>
        /// nextSceneName
        /// </summary>
        public static String nextSceneName = "SuperScrollView/Demo/Scenes/GridViewSelectItem";
        //public static String nextSceneName = "Scence/Sub/OneWord";


        public static String getLetterPath(int boolwhich = 10)
        {
            string strWindowsHeadPath = "";
            if (Application.platform == RuntimePlatform.Android)
            {
                ///此电脑\vivo S1\SanDisk SD 卡\Android\data\com.shiyi.U001PinYinGame\files\U001PinYinGame
                string stridentifier = Path.Combine("Android/data", Application.identifier);
                strWindowsHeadPath = Path.Combine((new AndoridSD()).getStoragePath(), stridentifier);
                StaticGlobal.RootWindowPath = Path.Combine(strWindowsHeadPath, "files/U001PinYinGame/externalResources/001GameResource");
                //strWindowsHeadPath = (new AndoridSD()).getStoragePath();
                //StaticGlobal.RootWindowPath = Path.Combine(strWindowsHeadPath, "U001PinYinGame/externalResources/001GameResource");
            }
            else if (Application.platform == RuntimePlatform.WindowsEditor || Application.platform == RuntimePlatform.WindowsPlayer)
            {
                StaticGlobal.RootWindowPath = @"C:\001EduPinYin\externalResources\001GameResource";
            }

            String strgetOneLetterPath = Path.Combine(StaticGlobal.RootWindowPath , StaticGlobal.SelectDestinationTargetWord);
            if (boolwhich == 10) {
                strgetOneLetterPath = Path.Combine(strgetOneLetterPath, StaticGlobal.SelectDestinationTargetItem);
            }
            Debug.Log("strgetOneLetterPath=" + strgetOneLetterPath);

            return strgetOneLetterPath;

        }

        public static String getLetterRecordPath()
        {
            string destination = Application.persistentDataPath;
            if (!Directory.Exists((destination)))
            {
                Directory.CreateDirectory(destination);
            }
            string strSelectDestinationTargetWord = Path.Combine(destination, StaticGlobal.SelectDestinationTargetWord);
            if (!Directory.Exists((strSelectDestinationTargetWord)))
            {
                Directory.CreateDirectory(strSelectDestinationTargetWord);
            }
            string strSelectDestinationTargetItem = Path.Combine(strSelectDestinationTargetWord, StaticGlobal.SelectDestinationTargetItem);
            if (!Directory.Exists((strSelectDestinationTargetItem)))
            {
                Directory.CreateDirectory(strSelectDestinationTargetItem);
            }

            return strSelectDestinationTargetItem;
        }

            /*
            public static String getOneLetterPath()
            {
                string strWindowsHeadPath = "C:/Works/unity3dGame/U001PinYinGame";
                if (Application.platform == RuntimePlatform.Android)
                {
                    strWindowsHeadPath = (new AndoridSD()).getStoragePath();
                }

                String strgetOneLetterPath = strWindowsHeadPath + "/" + StaticGlobal.RootWindowPath + "/" + StaticGlobal.SelectDestinationTargetWord + "/" + StaticGlobal.SelectDestinationTargetItem;
                Debug.Log("strgetOneLetterPath=" + strgetOneLetterPath);

                return strgetOneLetterPath;

            }
            */
            public void getTargetItemListPath()
        {

            string TargetItemListPath = getAssetPath();
            Debug_Log.Call_WriteLog(TargetItemListPath, "加载程序列表", "001PinYIn");

            DirectoryInfo root = new DirectoryInfo(TargetItemListPath);
            TargetItemListPathList = root.GetDirectories();

            if (TargetItemListPathList != null)
            {
                String strRootPath = "";
                for (int i = 0; i < TargetItemListPathList.Length; i++)
                {
                    strRootPath += TargetItemListPathList[i] + "；";
                }
                strRootPathList = strRootPath;

            }
            // Debug.Log(TargetItemListPathList.Length);

        }


        private String getAssetPath()
        {
            string strAppPath = "";
            ////那么怎么样把资源包打包进APK包里面呢？其实很简单，只要在项目文件夹里面新建一个StreamingAssets文件夹，
            ///将要打包的各种资源文件放到该目录下面就可以了。这样资源就被打包进Apk包里面的Assets文件夹里面了。
            ///这里面的资源通过什么目录访问呢，其实也挺简单 "jar:file://" + Application.dataPath + "!/assets" 就是访问该目录的路径，
            ///如果实在IOS平台，路径则是 Application.dataPath +"/Raw"，这里面一定要注意文件路径大小写，这里面是区分大小写的，
            ///如果不注意这个问题，可能就会资源加载不了的问题。所以项目的命名规范一开始就要做好。
            if (Application.platform == RuntimePlatform.Android)
            {

                ///Unity\Editor\Data\PlaybackEngines\AndroidPlayer\Apk


                Debug_Log.Call_WriteLog(Application.streamingAssetsPath + Directory.Exists(Application.streamingAssetsPath).toString(), " 1Application.streamingAssetsPath", "001PinYIn");
                Debug_Log.Call_WriteLog(Directory.Exists(Application.streamingAssetsPath + "001GameResource/"), " 2 Application.streamingAssetsPath", "001PinYIn");
                Debug_Log.Call_WriteLog(Directory.Exists(Application.streamingAssetsPath + "!/assets/001GameResource/"), "3 Application.streamingAssetsPath", "001PinYIn");

                strAppPath = "jar:file://" + Application.streamingAssetsPath + "!/assets";
                strAppPath = (new AndoridSD()).getStoragePath();

            }
            else if (Application.platform == RuntimePlatform.WindowsPlayer || Application.platform == RuntimePlatform.WindowsEditor)
            {
                strAppPath = Application.dataPath + "/StreamingAssets/";


            }
            else if (Application.platform == RuntimePlatform.IPhonePlayer)
            {
                strAppPath = Application.dataPath + "/Raw";

            }


            string path = strAppPath + "/externalResources/" + "001GameResource/" + SelectDestinationTargetWord + "/" + SelectDestinationTargetItem;
            Debug_Log.Call_WriteLog(Application.dataPath, "Application.dataPath", "001PinYIn");


            return path;



        }
    }
}
