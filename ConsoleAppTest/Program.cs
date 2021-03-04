using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ConsoleAppTest
{
    class Program
    {
       
        static void Main(string[] args)
        {
            string PathLetter = @"C:\001EduPinYin\externalResources\001GameResource\b\04Story";

            //string strFile = @"C:\001EduPinYin\externalResources\001GameResource\b\01OneSyllable\01.jpg";
            //string strFileSmall = @"C:\001EduPinYin\externalResources\001GameResource\b\01OneSyllable\01_small.jpg";


            IOrderedEnumerable<String> textList = Directory.GetFiles(PathLetter, "*.*", SearchOption.TopDirectoryOnly).Where(s => s.EndsWith(".txt")).OrderBy(s => s.ToString()); ;
            List<string> GloaltextList = textList.ToList();


            for (int i = 0; i < GloaltextList.Count; i++) {
                int ThisOlderNum = i;
                String strPathmyText = GloaltextList[ThisOlderNum].ToString();

       


                String strPathmyPic = (strPathmyText.Substring(0, strPathmyText.Length - 3) + "jpg");
                String strFileSmall = (strPathmyText.Substring(0, strPathmyText.Length - 4) + "_small.jpg");

                ZoomImage.GenerateHighThumbnail(strPathmyPic, strFileSmall, 100, 100);


//                ZoomImage dZoomImagedd = new ZoomImage();
  //              dZoomImagedd.readfile(strPathmyPic, strFileSmall);
            }

        }
    }
}
