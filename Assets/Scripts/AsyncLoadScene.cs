using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Globe
{
    public static string nextSceneName;
}

public class AsyncLoadScene : MonoBehaviour
{
    public Text loadingText;
    public Image progressBar;

    private float curProgressValue = 0f;

    private AsyncOperation operation;
    private bool operationed = false;

    private int intShowRNDOM = 100;
    private int dubleStep = 10;
    // Use this for initialization
    void Start()
    {
        //System.Random DDRandomDD = new System.Random();
        //intShowRNDOM = DDRandomDD.Next(62, 79);

        if (SceneManager.GetActiveScene().name == "Loading")
        {
            //GameObject canvasLoadingNotUnlodPanel = GameObject.Find("LoadingNotUnlod");
            //DontDestroyOnLoad("canvasLoadingNotUnlodPanel");
            // 启动协程
            StartCoroutine(AsyncLoading());
        }
    }

    IEnumerator AsyncLoading()
    {
        int displayProgress = 0;
        int toProgress = 0;
        operation = SceneManager.LoadSceneAsync(Assets.Script.PunPinYin.StaticGlobal.nextSceneName);

        operation.completed += Operation_completed;

        //阻止当加载完成自动切换
        operation.allowSceneActivation = false;
        while (operation.progress < 0.9f)
        {
            toProgress = Convert.ToInt32(operation.progress * 100);
            while (displayProgress < toProgress)
            {
                ++displayProgress;
                SetLoadingPercentage(displayProgress);
                Debug.Log("0   " + DateTime.Now.ToString());
                Debug_Log.Call_WriteLog(displayProgress, displayProgress.ToString(), "operation.progress < 0.9f");
                yield return new WaitForEndOfFrame();
            }
        }

        Debug.Log("1   " + DateTime.Now.ToString());



        toProgress = intShowRNDOM;
        while (displayProgress < toProgress)
        {
            displayProgress+= dubleStep;
            SetLoadingPercentage(displayProgress);
            Debug_Log.Call_WriteLog(displayProgress, displayProgress.ToString(), "displayProgress < toProgress");
            yield return new WaitForEndOfFrame();
        }

        operation.allowSceneActivation = true;

        //toProgress = 100;
        //while (displayProgress < toProgress)
        //{
        //    ++displayProgress;
        //    SetLoadingPercentage(displayProgress);
        //    Debug_Log.Call_WriteLog(displayProgress, displayProgress.ToString(), "displayProgress < 100");
        //    yield return new WaitForEndOfFrame();
        //}

        Debug.Log(SceneManager.GetActiveScene().name + curProgressValue.ToString());
    }

    private void Operation_completed(AsyncOperation obj)
    {
        Debug_Log.Call_WriteLog("Operation_completed");
    }

    void SetLoadingPercentage(float floatprogressValue)
    {
        if (floatprogressValue > 100) floatprogressValue = 100;

        loadingText.text = floatprogressValue + "%";//实时更新进度百分比的文本显示  

        progressBar.fillAmount = floatprogressValue / 100f;//实时更新滑动进度图片的fillAmount值  

    }

    // Update is called once per frame
    void Update1111()
    {

        int progressValue = 100;

        if (curProgressValue < progressValue)
        {
            curProgressValue += 0.1f;
        }


        int b = (int)System.Math.Round(curProgressValue * 100); //小数点后两位前移，并四舍五入
        float c = (float)b / 100; //还原小数点后两位 
        if (c > 100) c = 100f;
        loadingText.text = c + "%";//实时更新进度百分比的文本显示  

        progressBar.fillAmount = curProgressValue / 100f;//实时更新滑动进度图片的fillAmount值  

        if (!operationed && curProgressValue > 20)
        {

            operation.allowSceneActivation = true;//启用自动加载场景  

            operationed = true;

            //loadingText.text = "OK";//文本显示完成OK  

        }

        if (curProgressValue >= 100)
        {
            //operation.allowSceneActivation = true;//启用自动加载场景  
            //loadingText.text = "100";//文本显示完成OK  

        }
    }
}