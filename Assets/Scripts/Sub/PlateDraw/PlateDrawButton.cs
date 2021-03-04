using Assets.Script.PunPinYin;
using Assets.Scripts.PunPinYin;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlateDrawButton : Assets.Scripts.PunPinYin.pubButton
{


    void Start()
    {
        int intFisrtTop = 100;
        int intStep = 70;



        myButtonSelctList = new ButtonSelect[1];
        myButtonSelctList[0] = new ButtonSelect { buttonName = "Exit", left = 18, top = 479 };
        //myButtonSelctList[1] = new ButtonSelect { buttonName = "Pre", left = 906, top = intFisrtTop + intStep * 1, width = 77, playSound = false };
        //myButtonSelctList[2] = new ButtonSelect { buttonName = "Next", left = 906, top = intFisrtTop + intStep * 2, width = 77, playSound = false };

    }

    override
    public void MainSelect(string strWhich)
    {
        //StaticGlobalService.getTargetItemListPath();
        switch (strWhich)
        {
            case "Exit":
                //StartCoroutine(IndieStudio.LetterWrite.Utility.SceneLoader.LoadSceneAsync("Select"));
                // GameObject.Destroy(GameObject.Find("ShapesManager"));
                //GameObject.Destroy(GameObject.Find("AdsManager"));
                //GameObject.Destroy(GameObject.Find("ShapesCanvas"));
                //GameObject.Destroy(GameObject.Find("DrawCanvas"));
                //GameObject.Destroy(GameObject.Find("Audio SourceDrawshape"));
                if (IndieStudio.DrawingAndColoring.Logic.Area.shapesDrawingContents != null && IndieStudio.DrawingAndColoring.Logic.Area.shapesDrawingContents.Count > 0)
                {
                    IndieStudio.DrawingAndColoring.Logic.Area.shapesDrawingContents.Clear();
                }


                UnityEngine.SceneManagement.SceneManager.LoadScene("Scence/ClearData");
                break;
                //case "Pre":
                //case "Next":
                //    GameObject myCamera = GameObject.Find("Main Camera");

                //    myCamera.SendMessage("ButtonAction", strWhich);
                //    break;

        }
        // UnityEngine.SceneManagement.SceneManager.LoadScene(strWhich);
    }




}
