using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IniJumptoStart : MonoBehaviour {

	// Use this for initialization
	void Start()
	{
		if ( Application.platform == RuntimePlatform.WindowsPlayer)
		{

			if (Dog.ReadDog())
			{
				SceneManager.LoadScene("Start");
			}
			else
			{
				
				Debug.Log("no dog");
			}
		}
		else {
			string strResult = "";
			strResult = GetAuthorClicked("android.permission.CAMERA");
			strResult = GetAuthorClicked("android.permission.WRITE_EXTERNAL_STORAGE");
			strResult = GetAuthorClicked("android.permission.INTERNET");
			strResult = GetAuthorClicked("android.permission.READ_EXTERNAL_STORAGE");


			SceneManager.LoadScene("Start");
		}
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
    // Update is called once per frame

}
