using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using UnityEngine;

namespace Assets.Script
{
    public class ReadIniPar

    {
        /// <summary>
        /// 训练内容
        /// </summary>
        public string Content { get; set; }
        /// <summary>
        /// 时间长短 一般0  中等1 难2
        /// </summary>
        public int LengthofTime { get; set; }
        /// <summary>
        /// 速度 一般0 中等1  难2
        /// </summary>
        public int speed { get; set; }
    }


    public class getPar
    {

        public static ReadIniPar getParme()
        {
            ReadIniPar ddReadIniPardd = new ReadIniPar();

            #region 获取参数
            //获取ini文件

            int LengthofTime = 0;
            int speed = 0;
            MyIni ini = new MyIni();
            //获取Ini文件Time类型下的time对应的数值
            LengthofTime = ini.ReadIniContent("GameContent", "LengthofTime").toInt32();///SelectTrainTime
            speed = ini.ReadIniContent("GameContent", "Speed").toInt32();///SelectTrainDifficulty
            string strContent = ini.ReadIniContent("GameContent", "Content");
            #endregion 获取参数
            ddReadIniPardd.LengthofTime = LengthofTime;
            ddReadIniPardd.speed = speed;
            ddReadIniPardd.Content = strContent;
            Debug_Log.Call_WriteLog(ddReadIniPardd, "读取的strpersistentDataPath", "Unity");


            return ddReadIniPardd;
        }

    }

    public class MyIni
    {
        public string path;//ini文件的路径
        public MyIni()
        {///C:/Users/Administrator/AppData/LocalLow/DefaultCompany/Chen2020Test01/oliverData.ini
            string strpersistentDataPath = Application.persistentDataPath + "/oliverData.ini";

            this.path = strpersistentDataPath;
        }
        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string section, string key, string value, string path);
        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key, string deval, StringBuilder stringBuilder, int size, string path);





        //写入ini文件
        public void WriteIniContent(string section, string key, string value)
        {
            WritePrivateProfileString(section, key, value, this.path);
        }

        //读取Ini文件
        public string ReadIniContent(string section, string key)
        {
            StringBuilder temp = new StringBuilder(255);
            int i = GetPrivateProfileString(section, key, "", temp, 255, this.path);
            return temp.ToString();
        }



        //判断路径是否正确
        //public bool IsIniPath()
        //{
        //    return File.Exists(this.path);
        //}
    }
}
