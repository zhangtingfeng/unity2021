using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using UnityEngine;

namespace Assets.Script
{


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

    }
}
