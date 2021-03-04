using Assets.Script.PunPinYin;
using Assets.Scripts.PunPinYin;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SelectButton : Assets.Scripts.PunPinYin.pubButton
{





    void Start()
    {

        int intLeft1 = 534;
        int intLeft2 = 752;

        int topColumn1 = 165;
        int topColumn2 = 136;
        int inttopStep = 56;

        myButtonSelctList = new ButtonSelect[11];
        myButtonSelctList[0] = new ButtonSelect { buttonName = "DrawRed", left = intLeft1, top = topColumn1 };
        myButtonSelctList[1] = new ButtonSelect { buttonName = "PlateDraw", left = intLeft1, top = topColumn1 + inttopStep };
        myButtonSelctList[2] = new ButtonSelect { buttonName = "RenYiRen", left = intLeft1, top = topColumn1 + inttopStep * 2 };
        myButtonSelctList[3] = new ButtonSelect { buttonName = "SoundModel", left = intLeft1, top = topColumn1 + inttopStep * 3 };
        myButtonSelctList[4] = new ButtonSelect { buttonName = "OneWord", left = intLeft2, top = topColumn2 };
        myButtonSelctList[5] = new ButtonSelect { buttonName = "TwoWord", left = intLeft2, top = topColumn2 + inttopStep };
        myButtonSelctList[6] = new ButtonSelect { buttonName = "ThreeWord", left = intLeft2, top = topColumn2 + inttopStep * 2 };
        myButtonSelctList[7] = new ButtonSelect { buttonName = "Story", left = intLeft2, top = topColumn2 + inttopStep * 3 };
        myButtonSelctList[8] = new ButtonSelect { buttonName = "xiaoPaoPao", left = intLeft2, top = topColumn2 + inttopStep * 4 };
        myButtonSelctList[9] = new ButtonSelect { buttonName = "Shoot", left = intLeft2, top = topColumn2 + inttopStep *5 };

        myButtonSelctList[10] = new ButtonSelect { buttonName = "Exit", left = 18, top = 479 };
    }

    override
    public void MainSelect(string strWhich)
    {
        if (Application.platform == RuntimePlatform.WindowsPlayer)
        {

            if (Dog.ReadDog())
            {

            }
            else
            {

                return;
            }
        }
        else
        {
            ///ok
        }

        string strJump = "Scence/Loading";
        //StaticGlobalService.getTargetItemListPath();
        switch (strWhich)
        {
            case "Exit":
                UnityEngine.SceneManagement.SceneManager.LoadScene("Start");
                break;
            case "DrawRed":
                //if (GameObject.Find("AdsManagerLetter"))
                //{
                //    UnityEngine.SceneManagement.SceneManager.LoadScene("English Tracing Book/Scenes/Game");
                //}
                //else
                Assets.Script.PunPinYin.StaticGlobal.nextSceneName=("English Tracing Book/Scenes/LetterMain");
                //}

                UnityEngine.SceneManagement.SceneManager.LoadScene(strJump);
                StaticGlobal.SelectDestinationTargetItem = "02LetterDraw";
                break;
            case "PlateDraw":
                GameObject GameObjectShapesManagerDraw = GameObject.Find("ShapesManagerDraw");
                StaticGlobal.SelectDestinationTargetItem = "06PlainDraw";
                //if (GameObjectShapesManagerDraw==null)
                //{
                Assets.Script.PunPinYin.StaticGlobal.nextSceneName=("DrawingAndColoring Extra/Scenes/DrawAlbum");
                UnityEngine.SceneManagement.SceneManager.LoadScene(strJump);
                //}
                //else {
                //    //GameObject GameObjectDrawCanvas = GameObject.Find("DrawCanvas");
                //    //GameObjectDrawCanvas.SetActive(true);
                //    UnityEngine.SceneManagement.SceneManager.LoadScene("DrawingAndColoring Extra/Scenes/DrawingGame");
                //}
                break;
            case "RenYiRen":
                StaticGlobal.SelectDestinationTargetItem = "10Video";
                Assets.Script.PunPinYin.StaticGlobal.nextSceneName = "Scence/Sub/VideoPlay";
                UnityEngine.SceneManagement.SceneManager.LoadScene(strJump);
                break;
            case "SoundModel":
                StaticGlobal.SelectDestinationTargetItem = "08Pronunce";
                UnityEngine.SceneManagement.SceneManager.LoadScene("SoundModel");
                break;


            case "OneWord":
                Assets.Script.PunPinYin.StaticGlobal.nextSceneName = "Scence/Sub/OneWord";
                UnityEngine.SceneManagement.SceneManager.LoadScene(strJump);
                StaticGlobal.SelectDestinationTargetItem = "01OneSyllable";
                break;
            case "TwoWord":
                Assets.Script.PunPinYin.StaticGlobal.nextSceneName = "Scence/Sub/TwoSyllable";
                UnityEngine.SceneManagement.SceneManager.LoadScene(strJump);
                StaticGlobal.SelectDestinationTargetItem = "02TwoSyllable";
                break;
            case "ThreeWord":
                Assets.Script.PunPinYin.StaticGlobal.nextSceneName = "Scence/Sub/ThreeSyllable";
                UnityEngine.SceneManagement.SceneManager.LoadScene(strJump);
                StaticGlobal.SelectDestinationTargetItem = "03ThreeSyllable";
                break;
            case "Story":
                UnityEngine.SceneManagement.SceneManager.LoadScene("Story");
                StaticGlobal.SelectDestinationTargetItem = "04Story";
                break;
            case "xiaoPaoPao":
                Assets.Script.PunPinYin.StaticGlobal.nextSceneName = "bubble/Scene/MainScene";
                //UnityEngine.SceneManagement.SceneManager.LoadScene("bubble/Scene/MainScene");
                UnityEngine.SceneManagement.SceneManager.LoadScene(strJump);
                break;
            case "Shoot":
                Assets.Script.PunPinYin.StaticGlobal.nextSceneName = "JellyGarden/Scenes/gameJellyGarden";
                //UnityEngine.SceneManagement.SceneManager.LoadScene("BubbleShooterEasterBunny/Scenes/map");
                UnityEngine.SceneManagement.SceneManager.LoadScene(strJump);
                StaticGlobal.SelectDestinationTargetItem = "11Shoot";
                // Application.loadedLevel(strJump);
                break;


        }
        // UnityEngine.SceneManagement.SceneManager.LoadScene(strWhich);
    }

    // Update is called once per frame
    void Update()
    {

    }









}
