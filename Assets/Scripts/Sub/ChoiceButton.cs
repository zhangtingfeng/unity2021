using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChoiceButton : MonoBehaviour 
{
    public Button ChoiceBtn;


    // Use this for initialization
    public void ClickChoiceBtn()
    {
        //UnityEngine.SceneManagement.SceneManager.LoadScene("ThreeSyllable");

        //UnityEngine.SceneManagement.SceneManager.LoadScene("SuperScrollView/Demo/Scenes/GridViewSelectItem");
        string strJump = "Scence/Loading";
        Assets.Script.PunPinYin.StaticGlobal.nextSceneName = "SuperScrollView/Demo/Scenes/GridViewSelectItem";
        UnityEngine.SceneManagement.SceneManager.LoadScene(strJump);

        //GameObject myCamera = GameObject.Find("Main Camera");
        //myCamera.SendMessage("ButtonAction", "RecordPlaySound");

    }



}
