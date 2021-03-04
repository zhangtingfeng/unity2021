using Assets.Script.PunPinYin;
using Assets.Scripts.PunPinYin;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DrawRedButton : Assets.Scripts.PunPinYin.pubButton
{





    void Start()
    {

      

        myButtonSelctList = new ButtonSelect[1];
        myButtonSelctList[0] = new ButtonSelect { buttonName = "Exit", left = 18, top = 479 };
    }

    override
    public void MainSelect(string strWhich)
    {
        //StaticGlobalService.getTargetItemListPath();
        switch (strWhich)
        {
            case "Exit":
                UnityEngine.SceneManagement.SceneManager.LoadScene("Scence/ClearData");
                //UnityEngine.SceneManagement.SceneManager.LoadScene("Select");
                break;

        }
        // UnityEngine.SceneManagement.SceneManager.LoadScene(strWhich);
    }

    // Update is called once per frame
    void Update()
    {

    }









}
