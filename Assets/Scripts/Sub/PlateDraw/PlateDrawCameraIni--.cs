using Assets.Script.PunPinYin;
using Assets.Scripts.Pub;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class PlateDrawCameraIni : MonoBehaviour
{
    //public Text myText;
    public RawImage myRawImage;
    public RawImage mySmallRawImage;


    private List<string> GloaltextList;
    private int ThisOlderNum = -1;
    private String PathLetter = "";

    private LoadRawImage LoadRawImageService = new LoadRawImage();
    private LoadRawImage LoadRawImageServiceSmall = new LoadRawImage();
    void Start()
    {



        PathLetter = StaticGlobal.getLetterPath();

        if (Directory.Exists(PathLetter))
        {

            //string[] ddddd = System.IO.Directory.GetFiles(bb,);
            IOrderedEnumerable<String> textList = Directory.GetFiles(PathLetter, "*.*", SearchOption.TopDirectoryOnly).Where(s => s.EndsWith(".png")).OrderBy(s => s.ToString()); ;
            GloaltextList = textList.ToList();


            Next();
        }





    }



    void Pre()
    {
        if (ThisOlderNum > 0)
        {
            ThisOlderNum--;
            load_Pic();
        }
    }


    void Next()
    {
        
        if (ThisOlderNum < GloaltextList.Count - 1)
        {
            ThisOlderNum++;
            load_Pic();
        }
    }


    void load_Pic()
    {
        String strPathmyText = GloaltextList[ThisOlderNum].toString();

        GameObject myCanvas_PaintCamera = GameObject.Find("Canvas_Paint");
        myCanvas_PaintCamera.SendMessage("resetData");

        GameObject myRawImageScalePicCamera = GameObject.Find("RawImageScalePic");
        myRawImageScalePicCamera.SendMessage("reset");



        String strPathmyPic = (strPathmyText.Substring(0, strPathmyText.Length - 3) + "png");
        LoadRawImageService.showLocalFile(myRawImage, strPathmyPic);
        String strSmallPathmyPic = (strPathmyText.Substring(0, strPathmyText.Length - 3) + "jpg");
        LoadRawImageServiceSmall.showLocalFile(mySmallRawImage, strSmallPathmyPic);



       
        
    }


    void ButtonAction(String strstrWhichH)
    {
        GameObject myCamera = GameObject.Find("Main Camera");
        //String strH111 = strH;
        //Debug_Log.Call_WriteLog(strH111, "这里是安卓设备ButtonAction");
        switch (strstrWhichH)
        {

            
            case "Pre":
               // myCamera.SendMessage("resetMicrophone");
                Pre(); break;
            case "Next":
                //myCamera.SendMessage("resetMicrophone");
                Next(); break;
           
        }
    }
   
    // Use this for initialization
    void Awake()
    {
        //DontDestroyOnLoad(transform.gameObject);////跨场景播放不销毁
    }


}