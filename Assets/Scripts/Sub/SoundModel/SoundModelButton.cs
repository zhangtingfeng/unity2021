using Assets.Script.PunPinYin;
using Assets.Scripts.PunPinYin;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SoundModelButton : Assets.Scripts.PunPinYin.pubButton
{





    void Start()
    {



        myButtonSelctList = new ButtonSelect[2];
        myButtonSelctList[0] = new ButtonSelect { buttonName = "Exit", left = 18, top = 479 };
        myButtonSelctList[1] = new ButtonSelect { buttonName = "PlaySound", left = 906, top = 470, width = 77, playSound = false };
    }

    override
    public void MainSelect(string strWhich)
    {
        //StaticGlobalService.getTargetItemListPath();
        switch (strWhich)
        {
            case "Exit":
                UnityEngine.SceneManagement.SceneManager.LoadScene("Select");
                break;
            case "PlaySound":
                // GameObject myCamera = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject;
                //GameObject myCamera = GameObject.Find("Main Camera");


                //string strPath = StaticGlobal.getLetterPath();
                //String straudioPath = Path.Combine(strPath, "01.wav");
                //myCamera.SendMessage("PlayLocalFile", straudioPath);
                String PathLetter = StaticGlobal.getLetterPath();


                //String strPathmyText = GloaltextList[ThisOlderNum].toString();
                String strPathmyPic = Path.Combine(PathLetter,"01.mp4");
                StaticGlobal.playVideoSetMp4Path = strPathmyPic;
                UnityEngine.SceneManagement.SceneManager.LoadScene("AVProVideo/Demos/Scenes/03_Demo_VideoControls");

                // UnityEngine.SceneManagement.SceneManager.LoadScene("Select");
                break;
        }
        // UnityEngine.SceneManagement.SceneManager.LoadScene(strWhich);
    }

    // Update is called once per frame
    void Update()
    {

    }









}
