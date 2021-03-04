using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Script.PunPinYin
{

    public class Trainingobj
    {
        public string strFilePicname { get; set; }
        public string strFileSmallPicname { get; set; }
        public string strFileTextname { get; set; }
        public string strRecordFilePath { get; set; }

        public bool mChecked { get; set; }

    }

    public class StaticTrainingobj
    {
        public List<Trainingobj> FileTrainingList = new List<Trainingobj>();
        /// <summary>
        /// 是否录音改变的MD5，用来同步远程声音文件
        /// </summary>
        public string StrMd5 { get; set; }
        public string StrOutRecordPath { get; set; }
        public string StrOutResourcePath { get; set; }

        public List<Sprite> ListSprite { get; set; }
        public List<String> ListSpriteSound { get; set; }

    }


    /// <summary>
    /// 全局通用变量
    /// </summary>
    public class GloaltextList

    {
        /// <summary>
        /// public static List<System.String> GloaltextList = new List<string>();
        /// </summary>
        /// <param name="strpathPathLetter"></param>
        /// <returns></returns>
        public static StaticTrainingobj getGloaltextList(string strpathPathLetter)
        {
            StaticTrainingobj temp__StaticTrainingobj = new StaticTrainingobj();
            if (System.IO.Directory.Exists(strpathPathLetter))
            {
                temp__StaticTrainingobj.StrOutRecordPath = Application.persistentDataPath;
                temp__StaticTrainingobj.StrOutResourcePath = StaticGlobal.RootWindowPath;

                //string[] ddddd = System.IO.Directory.GetFiles(bb,);
                System.Linq.IOrderedEnumerable<System.String> textList = System.IO.Directory.GetFiles(strpathPathLetter, "*.*", System.IO.SearchOption.TopDirectoryOnly).Where(s => s.EndsWith(".txt")).OrderBy(s => s.ToString()); ;
                var tempGloaltextList = textList.ToList();

                List<Trainingobj> FileListTrainingobj = new List<Trainingobj>();
                for (int i = 0; i < tempGloaltextList.Count; i++)
                {
                    string strPath = tempGloaltextList[i].toString();
                    string strAdd = strPath.Substring(temp__StaticTrainingobj.StrOutResourcePath.Length+1, strPath.Length- temp__StaticTrainingobj.StrOutResourcePath.Length-1);

                    String strPathmyWav1 = (strAdd.Substring(0, strAdd.Length - 3) + "wav");
                    string RecordFilename = Path.Combine(temp__StaticTrainingobj.StrOutRecordPath, strPathmyWav1);
                    string strADDrECORDfILE = "";
                    if (File.Exists(RecordFilename))
                    {
                        strADDrECORDfILE = strPathmyWav1;
                    }

                    FileListTrainingobj.Add(new Trainingobj
                    {
                        strFileTextname = strAdd, strRecordFilePath= strADDrECORDfILE

                    });

                   

                }

                temp__StaticTrainingobj.FileTrainingList = FileListTrainingobj;

              


            }
            return temp__StaticTrainingobj;
        }

    }
}
