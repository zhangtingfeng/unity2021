using System;
using UnityEngine;
using System.Collections;
using System.Runtime.CompilerServices;
using Object = UnityEngine.Object;

public class ClearData : MonoBehaviour
{
//    Default incoming policy changed to 'deny'
//(be sure to update your rules accordingly)
//Firewall reloaded
//==================================================================
//Congratulations! Installed successfully!
//==================================================================
//外网面板地址: http://219.235.6.205:8888/f413214f
//内网面板地址: http://219.235.6.205:8888/f413214f
//username: emw21ggp
//password: e750709c
//If you cannot access the panel,
//release the following panel port [8888] in the security group
//若无法访问面板，请检查防火墙/安全组是否有放行面板[8888]端口
//==================================
    // Use this for initialization
    //异步对象
    private AsyncOperation async;

    //下一个场景的名称
    private static string nextSceneName = "Select";

    void Awake()
    {
        if (GameObject.Find("bpmfShapesManager"))
        {
            GameObject.Destroy(GameObject.Find("AudioSources"));
            GameObject.Destroy(GameObject.Find("LShapesManager"));
            GameObject.Destroy(GameObject.Find("NShapesManager"));
            GameObject.Destroy(GameObject.Find("UShapesManager"));
            GameObject.Destroy(GameObject.Find("SShapesManager"));
            GameObject.Destroy(GameObject.Find("AdsManagerLetter"));
            GameObject.Destroy(GameObject.Find("bpmfShapesManager"));
            GameObject.Destroy(GameObject.Find("AdsManager"));
        }

        if (GameObject.Find("ShapesManagerDraw"))
        {
            if (IndieStudio.DrawingAndColoring.Logic.Area.shapesDrawingContents != null && IndieStudio.DrawingAndColoring.Logic.Area.shapesDrawingContents.Count > 0)
            {
                IndieStudio.DrawingAndColoring.Logic.Area.shapesDrawingContents.Clear();
            }
            GameObject.Destroy(GameObject.Find("backgroundMusic"));
            GameObject.Destroy(GameObject.Find("AudioSources"));
            GameObject.Destroy(GameObject.Find("ShapesCanvas"));
            //GameObject.Find("DrawCanvas").SetActive(false);
            GameObject.Destroy(GameObject.Find("DrawCanvas"));
            GameObject.Destroy(GameObject.Find("ShapesManagerDraw"));
            GameObject.Destroy(GameObject.Find("AdsManagerDraw"));
        }


        Object[] objAry = Resources.FindObjectsOfTypeAll<Material>();

        for (int i = 0; i < objAry.Length; ++i)
        {
            objAry[i] = null;//解除资源的引用
        }

        Object[] objAry2 = Resources.FindObjectsOfTypeAll<Texture>();

        for (int i = 0; i < objAry2.Length; ++i)
        {
            objAry2[i] = null;
        }


        // GameObject.Destroy(GameObject.Find("backgroundMusic"));


        //卸载没有被引用的资源
        Resources.UnloadUnusedAssets();

        //立即进行垃圾回收
        GC.Collect();
        GC.WaitForPendingFinalizers();//挂起当前线程，直到处理终结器队列的线程清空该队列为止
        GC.Collect();

    }

    void Start()
    {
        StartCoroutine("AsyncLoadScene", nextSceneName);
    }

    ///// <summary>
    ///// 静态方法，直接切换到ClearScene，此脚本是挂在ClearScene场景下的，就会实例化，执行资源回收
    ///// </summary>
    ///// <param name="_nextSceneName"></param>
    //public static void LoadLevel(string _nextSceneName)
    //{
    //    nextSceneName = _nextSceneName;
    //    UnityEngine.SceneManagement.SceneManager.LoadScene("ClearScene");
    //}

    /// <summary>
    /// 异步加载下一个场景
    /// </summary>
    /// <param name="sceneName"></param>
    /// <returns></returns>
    IEnumerator AsyncLoadScene(string sceneName)
    {
        //async = Application.LoadLevelAsync(sceneName);
        async = UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(sceneName);
        yield return async;
    }

    void OnDestroy()
    {
        async = null;
    }

}
