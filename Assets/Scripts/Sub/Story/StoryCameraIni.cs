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

public class StoryCameraIni : MonoBehaviour
{
    public Text myText;
    public RawImage myRawImage;
    private List<string> GloaltextList;
    private int ThisOlderNum = 0;
    private String PathLetter = "";

    private LoadRawImage LoadRawImageService = new LoadRawImage();

    void Start()
    {



        PathLetter = StaticGlobal.getLetterPath();

        if (Directory.Exists(PathLetter))
        {

            //string[] ddddd = System.IO.Directory.GetFiles(bb,);
            IOrderedEnumerable<String> textList = Directory.GetFiles(PathLetter, "*.*", SearchOption.TopDirectoryOnly).Where(s => s.EndsWith(".txt")).OrderBy(s => s.ToString()); ;
            GloaltextList = textList.ToList();


            Next();
        }





    }



    void Pre()
    {
        if (ThisOlderNum > 0)
        {
            ThisOlderNum--;
            loadTextAndPic();
        }
    }


    void Next()
    {
        loadTextAndPic();
        if (ThisOlderNum < GloaltextList.Count - 1)
        {
            ThisOlderNum++;
          
        }
        
    }


    void loadTextAndPic()
    {
        String strPathmyText = GloaltextList[ThisOlderNum].toString();
        

        string sssContent = File.ReadAllText(strPathmyText);
        myText.text = sssContent;


        String strPathmyPic = (strPathmyText.Substring(0, strPathmyText.Length - 3) + "jpg");
        LoadRawImageService.showLocalFile(myRawImage, strPathmyPic);


        StartCoroutine(checkRecordSoundButtonStatus(0.2f));



        GameObject myCamera = GameObject.Find("Main Camera");
        myCamera.SendMessage("stopPlayLocalFile");


    }

    IEnumerator checkRecordSoundButtonStatus(float waitSoundSecod)
    {
        yield return new WaitForSeconds(waitSoundSecod);//等待一秒后异步加载
        GameObject gameObjectRecordPlayButton = GameObject.Find("RecordPlayButton");
        if (File.Exists(GetRecordname()))
        {
            gameObjectRecordPlayButton.SendMessage("SetRecordPlayStatus", true);
        }
        else
        {
            gameObjectRecordPlayButton.SendMessage("SetRecordPlayStatus", false);
        }
    }
    String GetRecordname()
    {
        string strgetLetterRecordPath = StaticGlobal.getLetterRecordPath();
        String strPathmyText1 = GloaltextList[ThisOlderNum].toString();
        String strPathmyWav1 = (strPathmyText1.Substring(0, strPathmyText1.Length - 3) + "wav");
        String FileName = System.IO.Path.GetFileNameWithoutExtension(strPathmyWav1);

        String strRecordName = Path.Combine(strgetLetterRecordPath, FileName + ".wav");

        return strRecordName;
    }

    void ButtonAction(String strstrWhichH)
    {
        GameObject myCamera = GameObject.Find("Main Camera");
        //String strH111 = strH;
        //Debug_Log.Call_WriteLog(strH111, "这里是安卓设备ButtonAction");
        switch (strstrWhichH)
        {

            case "PlaySound":
                myCamera.SendMessage("resetMicrophone");
                String strPathmyText = GloaltextList[ThisOlderNum].toString();
                String strPathmyWav = (strPathmyText.Substring(0, strPathmyText.Length - 3) + "wav");





                // string strPath = StaticGlobal.getLetterPath();
                // String straudioPath = Path.Combine(strPathmyWav, "01.wav");
                myCamera.SendMessage("PlayLocalFile", strPathmyWav);
                break;
            case "Pre":
                myCamera.SendMessage("resetMicrophone");
                Pre(); break;
            case "Next":
                myCamera.SendMessage("resetMicrophone");
                Next(); break;
            case "RecordStart":
                myCamera.SendMessage("resetMicrophone");
                myCamera.SendMessage("StartMicrophone", GetRecordname());



                break;

            case "RecordStop":
                myCamera.SendMessage("StopMicrophone");
                StartCoroutine(checkRecordSoundButtonStatus(1.5f));
                StartCoroutine(checkRecordSoundButtonStatus(3.5f));
                break;

            case "RecordPlaySound":
                //GameObject myCamera = GameObject.Find("Main Camera");
                if (File.Exists(GetRecordname()))
                {
                    myCamera.SendMessage("PlayLocalFile", GetRecordname());
                }
                break;
        }
    }
    /*
    private int intwidth;
    private int intheight;
    public Text TextWH;
    void Start()
    {
        intwidth = Screen.width;
        intheight = Screen.height;
        print("intwidth="+ intwidth + "  intheight="+ intheight);
        Debug.Log("intwidth=" + intwidth + "  intheight=" + intheight);

        TextWH.text = "intwidth=" + intwidth + "  intheight=" + intheight;

    }*/
    // Use this for initialization
    void Awake()
    {
        //DontDestroyOnLoad(transform.gameObject);////跨场景播放不销毁
    }


}