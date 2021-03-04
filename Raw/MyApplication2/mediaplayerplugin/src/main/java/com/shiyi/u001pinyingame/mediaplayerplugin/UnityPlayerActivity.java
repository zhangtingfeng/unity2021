package com.shiyi.u001pinyingame.mediaplayerplugin;


import com.unity3d.player.*;

import android.app.Activity;
import android.content.ContentResolver;
import android.content.ContentUris;
import android.content.ContentValues;
import android.content.Context;
import android.content.Intent;
import android.content.res.Configuration;
import android.database.Cursor;
import android.graphics.Bitmap;
import android.graphics.BitmapFactory;
import android.graphics.PixelFormat;
import android.net.Uri;
import android.os.Bundle;
import android.provider.MediaStore;
import android.util.Log;
import android.view.KeyEvent;
import android.view.MotionEvent;
import android.view.View;
import android.view.Window;
import android.view.WindowManager;
import android.widget.Toast;

import org.json.JSONException;

import java.io.File;
import java.io.FileInputStream;
import java.io.FileNotFoundException;
import java.io.IOException;
import java.text.ParseException;

public class UnityPlayerActivity extends Activity {
    private Context mContext;
    protected UnityPlayer mUnityPlayer; // don't change the name of this variable; referenced from native code

    public void CloseUnity(String data) {
        finish();
    }

    public void PreservationSvideotape(String msg) {
        File file1 = new File(msg);
//获取ContentResolve对象，来操作插入视频
        ContentResolver localContentResolver = this.getContentResolver();
//ContentValues：用于储存一些基本类型的键值对
        ContentValues localContentValues = getVideoContentValues(this, file1, System.currentTimeMillis());
//insert语句负责插入一条新的纪录，如果插入成功则会返回这条记录的id，如果插入失败会返回-1。
        Uri localUri = localContentResolver.insert(MediaStore.Video.Media.EXTERNAL_CONTENT_URI, localContentValues);
        //  Log.d(msg, "PreservationSPhoto: .");
    }

    public ContentValues getVideoContentValues(Context paramContext, File paramFile, long paramLong) {
        ContentValues localContentValues = new ContentValues();
        localContentValues.put("title", paramFile.getName());
        localContentValues.put("_display_name", paramFile.getName());
        localContentValues.put("mime_type", "video/3gp");
        localContentValues.put("datetaken", Long.valueOf(paramLong));
        localContentValues.put("date_modified", Long.valueOf(paramLong));
        localContentValues.put("date_added", Long.valueOf(paramLong));
        localContentValues.put("_data", paramFile.getAbsolutePath());
        localContentValues.put("_size", Long.valueOf(paramFile.length()));
        return localContentValues;
    }


    /*"UnityEngine.AndroidJavaException: java.lang.NoSuchMethodError: no non-static method with name=\'PreservationSPhototest\' signature=\'(Ljava/lang/String;)Ljava/lang/String;\' in class Lcom.unity3d.player.UnityPlayerActivity;\njava.lang.NoSuchMethodError: no non-static method with name=\'PreservationSPhototest\' signature=\'(Ljava/lang/String;)Ljava/lang/String;\' in class Lcom.unity3d.player.UnityPlayerActivity;\n\tat com.unity3d.player.ReflectionHelper.getMethodID(Unknown Source:231)\n\tat com.unity3d.player.UnityPlayer.nativeRender(Native Method)\n\tat com.unity3d.player.UnityPlayer.c(Unknown Source:0)\n\tat com.unity3d.player.UnityPlayer$e$2.queueIdle(Unknown Source:72)\n\tat android.os.MessageQueue.next(MessageQueue.java:409)\n\tat android.os.Looper.loop(Looper.java:183)\n\tat com.unity3d.player.UnityPlayer$e.run(Unknown Source:32)\n  at UnityEngine.AndroidJNISafe.CheckException () [0x0008c] in /Users/builduser/buildslave/unity/build/Runtime/Export/AndroidJNISafe.cs:24 \n  at UnityEngine.AndroidJNISafe.CallStaticObjectMethod (IntPtr clazz, IntPtr methodID, UnityEngine.jvalue[] args) [0x00011] in /Users/builduser/buildslave/unity/build/Runtime/Export/AndroidJNISafe.cs:207 \n  at UnityEngine.AndroidReflection.GetMethodMember (IntPtr jclass, System.String methodName, System.String signature, Boolean isStatic) [0x00057] in /Users/builduser/buildslave/unity/build/Runtime/Export/AndroidJavaImpl.cs:703 \n  at UnityEngine._AndroidJNIHelper.GetMethodID (IntPtr jclass, System.String methodName, System.String signature, Boolean isStatic) [0x0000c] in /Users/builduser/buildslave/unity/build/Runtime/Export/AndroidJavaImpl.cs:1167 "*/
    public String PreservationSPhototest(String msg) throws ParseException, IOException, JSONException {
        String ssdebugLogs = debugLog.send(msg, "PreservationSPhoto", "unityjar");
        // Toast.makeText(this, msg, Toast.LENGTH_SHORT).show();
        try {
            saveImage(msg);
            DeleteImage(msg);
        } catch (Exception e) {
            msg = e.getMessage();
        }
        return "ddddd" + msg + ssdebugLogs;
    }

    public String PreservationSPhoto(String msg,Context Contextthis) throws ParseException, IOException, JSONException {
        mContext=Contextthis;
        String strReturn="save error";
        debugLog.send(msg, "PreservationSPhoto", "unityjar");
        try {
            saveImage(msg);
            strReturn="save ok";
            //   DeleteImage(msg);
        } catch (Exception e) {
            //msg = e.getMessage();
            debugLog.send(e, "PreservationSPhoto", "unityjar");
            strReturn=e.getMessage();
        }
        debugLog.send(msg, "PreservationSPhotook", "unityjar");
        return strReturn;
    }

    //保存图片到相册
    private void saveImage(String path) throws ParseException, JSONException, IOException {
        //debugLog.send(path, "jarpath", "unityjar");
       // FileInputStream input = null;
       // try {
        //    input = new FileInputStream(new File(path));
       // } catch (FileNotFoundException e) {
        //    debugLog.send(e.getMessage(), "saveImage", "unityjar");
         //   e.printStackTrace();
       // }

       // Bitmap bitmap = BitmapFactory.decodeStream(input);
        String fileName = System.currentTimeMillis() + ".jpg";
        //ImgUtils.saveBitmap(bitmap, fileName, mContext);

        ImgUtils.saveToSystemGallery(mContext, new File(path), fileName);  //把文件插入到系统图库
        debugLog.send(path, "saveImageok", "unityjar");
    }

    private void DeleteImage(String imgPath) {
        ContentResolver resolver = getContentResolver();
        Cursor cursor = MediaStore.Images.Media.query(resolver, MediaStore.Images.Media.EXTERNAL_CONTENT_URI, new String[]{MediaStore.Images.Media._ID}, MediaStore.Images.Media.DATA + "=?",
                new String[]{imgPath}, null);
        boolean result = false;
        if (cursor.moveToFirst()) {
            long id = cursor.getLong(0);
            Uri contentUri = MediaStore.Images.Media.EXTERNAL_CONTENT_URI;
            Uri uri = ContentUris.withAppendedId(contentUri, id);
            int count = getContentResolver().delete(uri, null, null);
            result = count == 1;
        } else {
            File file = new File(imgPath);
            result = file.delete();
        }

    }

    // Setup activity layout
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        try {
            debugLog.send("onCreate", "jarpathonCreate", "unityjar");
        } catch (ParseException e) {
            e.printStackTrace();
        } catch (IOException e) {
            e.printStackTrace();
        } catch (JSONException e) {
            e.printStackTrace();
        }
        requestWindowFeature(Window.FEATURE_NO_TITLE);
        super.onCreate(savedInstanceState);
        mContext = this;
        mUnityPlayer = new UnityPlayer(this);
        setContentView(mUnityPlayer);
        mUnityPlayer.requestFocus();
    }

    @Override
    protected void onNewIntent(Intent intent) {
        // To support deep linking, we need to make sure that the client can get access to
        // the last sent intent. The clients access this through a JNI api that allows them
        // to get the intent set on launch. To update that after launch we have to manually
        // replace the intent with the one caught here.
        setIntent(intent);
    }

    // Quit Unity
    @Override
    protected void onDestroy() {
        mUnityPlayer.quit();
        super.onDestroy();
    }

    // Pause Unity
    @Override
    protected void onPause() {
        super.onPause();
        mUnityPlayer.pause();
    }

    // Resume Unity
    @Override
    protected void onResume() {
        super.onResume();
        mUnityPlayer.resume();
    }

    @Override
    protected void onStart() {
        super.onStart();
        mUnityPlayer.start();
    }

    @Override
    protected void onStop() {
        super.onStop();
        mUnityPlayer.stop();
    }

    // Low Memory Unity
    @Override
    public void onLowMemory() {
        super.onLowMemory();
        mUnityPlayer.lowMemory();
    }

    // Trim Memory Unity
    @Override
    public void onTrimMemory(int level) {
        super.onTrimMemory(level);
        if (level == TRIM_MEMORY_RUNNING_CRITICAL) {
            mUnityPlayer.lowMemory();
        }
    }

    // This ensures the layout will be correct.
    @Override
    public void onConfigurationChanged(Configuration newConfig) {
        super.onConfigurationChanged(newConfig);
        mUnityPlayer.configurationChanged(newConfig);
    }

    // Notify Unity of the focus change.
    @Override
    public void onWindowFocusChanged(boolean hasFocus) {
        super.onWindowFocusChanged(hasFocus);
        mUnityPlayer.windowFocusChanged(hasFocus);
    }

    // For some reason the multiple keyevent type is not supported by the ndk.
    // Force event injection by overriding dispatchKeyEvent().
    @Override
    public boolean dispatchKeyEvent(KeyEvent event) {
        if (event.getAction() == KeyEvent.ACTION_MULTIPLE)
            return mUnityPlayer.injectEvent(event);
        return super.dispatchKeyEvent(event);
    }

    // Pass any events not handled by (unfocused) views straight to UnityPlayer
    @Override
    public boolean onKeyUp(int keyCode, KeyEvent event) {
        return mUnityPlayer.injectEvent(event);
    }

    @Override
    public boolean onKeyDown(int keyCode, KeyEvent event) {
        return mUnityPlayer.injectEvent(event);
    }

    @Override
    public boolean onTouchEvent(MotionEvent event) {
        return mUnityPlayer.injectEvent(event);
    }

    /*API12*/
    public boolean onGenericMotionEvent(MotionEvent event) {
        return mUnityPlayer.injectEvent(event);
    }
}
