using Assets.Script.PunPinYin;
using Assets.Scripts.PunPinYin;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class startButton : Assets.Scripts.PunPinYin.pubButton
{


    void Start()
    {
        myButtonSelctList = new ButtonSelect[1];
        myButtonSelctList[0] = new ButtonSelect { buttonName = "Enter", left = 835, top = 469 };
    }


    override
    public void MainSelect(string strWhich)

    {
        Debug.Log(strWhich);
        //StaticGlobalService.getTargetItemListPath();
        switch (strWhich)
        {
            case "Enter":
                // string strPath=  Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);



                SceneManager.LoadScene("Select");
                break;
        }
        // UnityEngine.SceneManagement.SceneManager.LoadScene(strWhich);
    }

}
