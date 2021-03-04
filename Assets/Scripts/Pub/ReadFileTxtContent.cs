using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Pub
{
    public class ReadFileTxtContent
    {
        /* public static string ReadLocalFile(string txtPath)
         {
             bool exists = File.Exists(txtPath);
             txtPath = "file:///" + txtPath;
             ///WWW www = new WWW(txtPath,);
            // String strContent = www.toString();
             //String strContent = www.data.;
             return strContent;
         }*/



        public static String ReadText(string txtPath)
        {
            String text = "";
            try
            {

                string pathSource = txtPath;

                using (FileStream fsSource = new FileStream(pathSource,
                            FileMode.Open, FileAccess.Read))
                {
                    // Read the source file into a byte array.
                    byte[] bytes = new byte[fsSource.Length];
                    int numBytesToRead = (int)fsSource.Length;
                    int numBytesRead = 0;
                    while (numBytesToRead > 0)
                    {
                        int n = fsSource.Read(bytes, numBytesRead, numBytesToRead);

                        if (n == 0)
                            break;
                        numBytesRead += n;
                        numBytesToRead -= n;
                    }
                    numBytesToRead = bytes.Length;
                    //text = Encoding.Default.GetString(bytes);
                    text = UTF8Encoding.UTF8.GetString(bytes);
                   
                }
            }
            catch
            {
                //ioEx.Message
            }
            return text;
        }

        public void Write()
        {
            string xml = "C#读写中文";

            try
            {
                string pathSource = "test.txt";
                using (FileStream fsSource = new FileStream(pathSource,
                            FileMode.Create, FileAccess.Write))
                {
                    //byte[] data = Encoding.Default.GetBytes(xml);
                    byte[] data = UTF8Encoding.UTF8.GetBytes(xml);
                    fsSource.Write(data, 0, data.Length);
                }
            }
            catch
            {
                // error
            }
            return;
        }
    }
}
