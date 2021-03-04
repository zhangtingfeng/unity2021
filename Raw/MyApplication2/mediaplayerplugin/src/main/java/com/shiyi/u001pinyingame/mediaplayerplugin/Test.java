package com.shiyi.u001pinyingame.mediaplayerplugin;

import android.app.Activity;
import android.util.Log;
import android.support.v4.content.PermissionChecker;
import android.support.v4.app.ActivityCompat;
import com.unity3d.player.UnityPlayer;
/**
 * Created by Administrator on 2021/1/15.
 */

public class Test extends com.unity3d.player.UnityPlayerActivity{

    public  void logSay(){
        Log.d("Unity","Native Log Message");

    }


    public  String LogNativeAndroidLogcatMessageReturn(String  str){
        return "d:"+str;

    }

    //前面说过了静态方法,android.permission.WRITE_EXTERNAL_STORAGE是外部存储权限,同理其他权限也可以动态请求
    public  void requestExternalStorage() {
        //检查权限避免重复请求相同权限,参数:activity,权限名
        if (PermissionChecker.checkSelfPermission(this, "android.permission.WRITE_EXTERNAL_STORAGE") != 0) {
            ActivityCompat.requestPermissions(this, new String[]{"android.permission.WRITE_EXTERNAL_STORAGE"}, 100);//请求权限,参数:activity,权限名,请求码(不同的权限要求不同的请求码,可以自己定,比如我这个权限是100,另外的可以填102,103...)
        }
    }



}
