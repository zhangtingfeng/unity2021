using Assets.Script.PunPinYin;
using Assets.Scripts.PunPinYin;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlateDrawButtonDel : Assets.Scripts.PunPinYin.pubButton
{


    void Start()
    {
        int intFisrtTop = 100;
        int intStep = 70;



        myButtonSelctList = new ButtonSelect[3];
        myButtonSelctList[0] = new ButtonSelect { buttonName = "Exit", left = 18, top = 479 };
        myButtonSelctList[1] = new ButtonSelect { buttonName = "Pre", left = 906, top = intFisrtTop + intStep * 1, width = 77, playSound = false };
        myButtonSelctList[2] = new ButtonSelect { buttonName = "Next", left = 906, top = intFisrtTop + intStep * 2, width = 77, playSound = false };

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
            case "Pre":
            case "Next":
                GameObject myCamera = GameObject.Find("Main Camera");

                myCamera.SendMessage("ButtonAction", strWhich);
                break;

        }
        // UnityEngine.SceneManagement.SceneManager.LoadScene(strWhich);
    }




}
