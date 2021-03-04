using Assets.Script.PunPinYin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class CameraIni : MonoBehaviour
{
    public Text myText;


    void Start()
    {
        myText.text = StaticGlobal.SelectDestinationTargetWord;
    }
    /*
     * 
     * 
     * Default incoming policy changed to 'deny'
(be sure to update your rules accordingly)
Firewall reloaded
==================================================================
Congratulations! Installed successfully!
==================================================================
外网面板地址: http://219.235.6.205:8888/f413214f
内网面板地址: http://219.235.6.205:8888/f413214f
username: emw21ggp
password: e750709c
If you cannot access the panel,
release the following panel port [8888] in the security group
若无法访问面板，请检查防火墙/安全组是否有放行面板[8888]端口
==================================
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