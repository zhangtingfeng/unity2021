using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
//using UnityEngine.Android;

public class AndroidRuntimePermissionsExample : MonoBehaviour
{
    //常用权限
    //android.permission.CAMERA 相机权限
    //android.permission.RECORD_AUDIO 麦克风权限
    //android.permission.READ_EXTERNAL_STORAGE 读储存卡，直接在设置中勾选write permission为External（SDCard）
    //android.permission.WRITE_EXTERNAL_STORAGE 写储存卡，直接在设置中勾选write permission为External（SDCard）

    void Start()
    {

    }

    public void clickUpdate()
    {
        //if (Input.GetMouseButtonDown(0))
        //{
        string strResult = "";
        strResult = GetAuthorClicked("android.permission.CAMERA");
        strResult = GetAuthorClicked("android.permission.WRITE_EXTERNAL_STORAGE");
        strResult = GetAuthorClicked("android.permission.INTERNET");
        strResult = GetAuthorClicked("android.permission.READ_EXTERNAL_STORAGE");
        //}
    }

    private string GetAuthorClicked(String strpermission)
    {

        string strResult = "";
        try
        {
            AndroidRuntimePermissions.Permission result = AndroidRuntimePermissions.RequestPermission(strpermission);
            switch (result)
            {
                case AndroidRuntimePermissions.Permission.Denied://永久拒绝询问
                    strResult = ("权限被拒绝且不再询问");
                    AndroidRuntimePermissions.OpenSettings();// 打开本程序的设置界面
                    break;
                case AndroidRuntimePermissions.Permission.Granted://允许
                    strResult = ("权限已开启");
                    break;
                case AndroidRuntimePermissions.Permission.ShouldAsk://拒绝权限但不拒绝询问
                    strResult = ("权限被拒绝");
                    break;
            }

        }
        catch (Exception eee)
        {
            strResult = eee.Message;
        }
        return strResult;
    }
}