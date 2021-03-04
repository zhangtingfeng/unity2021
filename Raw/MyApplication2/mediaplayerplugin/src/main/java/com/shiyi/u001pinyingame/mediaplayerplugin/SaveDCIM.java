package com.shiyi.u001pinyingame.mediaplayerplugin;

import com.unity3d.player.*;

import android.Manifest;
import android.app.Activity;
import android.os.Build;
import android.support.annotation.RequiresApi;
import android.support.v4.app.ActivityCompat;

import android.support.v4.content.PermissionChecker;
import android.widget.Toast;

import com.unity3d.player.UnityPlayer;

import org.json.JSONException;

import java.io.FileNotFoundException;
import java.io.IOException;
import java.text.ParseException;

public class SaveDCIM extends  UnityPlayerActivity {


    private static SaveDCIM _SaveDCIM__Instace;

    public static SaveDCIM GetInstall() {
        if (_SaveDCIM__Instace == null) {
            _SaveDCIM__Instace = new SaveDCIM();
        }
        return _SaveDCIM__Instace;
    }

    public void sendMessageToUnity() {
        UnityPlayer.UnitySendMessage("jar", "AndroidCallBack", "测试成功");
    }


    public int testInt() {
        return 13;
    }

    @RequiresApi(api = Build.VERSION_CODES.M)
    public String testString(String msg)  {
        String strErr="";
        //Toast.makeText(this, msg, Toast.LENGTH_SHORT).show();
        try {

            //检查权限避免重复请求相同权限,参数:activity,权限名

           //int inthasWriteContactsPermission =checkSelfPermission(Manifest.permission.INTERNET);
////Attempt to invoke virtual method 'int android.content.Context.checkSelfPermission(java.lang.String)' on a null object reference
            strErr=debugLog.send(msg, "PreservationSPhoto", "unityjar");
            //strErr;
        } catch (Exception e) {
            return e.getMessage();
           // debugLog.send(e.getMessage(), "testString", "unityjar");
        }
        return strErr+msg+"msg";
    }

    public String testSetString(String string) {
        sendMessageToUnity();
        return string;
    }
}
