package com.shiyi.u001pinyingame.mediaplayerplugin;

import android.content.Context;
import android.content.Intent;
import android.graphics.Bitmap;
import android.media.MediaScannerConnection;
import android.net.Uri;
import android.os.Build;
import android.os.Environment;
import android.provider.MediaStore;

import com.shiyi.u001pinyingame.mediaplayerplugin.debugLog;

import org.json.JSONException;

import java.io.File;
import java.io.FileNotFoundException;
import java.io.FileOutputStream;
import java.io.IOException;
import java.text.ParseException;

public class ImgUtils {


    /**
     * 保存图片到本地,其次把文件插入到系统图库
     *
     * @param context
     * @param file
     * @param fileName
     */
    public static void saveToSystemGallery(Context context, File file, String fileName) throws ParseException, JSONException, IOException {

        debugLog.send(fileName, "saveToSystemGalleryini", "unityjar");
        try {
            MediaStore.Images.Media.insertImage(context.getContentResolver(),
                    file.getAbsolutePath(), fileName, null);
            debugLog.send(fileName, "saveToSystemGalleryok", "unityjar");
            // 最后通知图库更新
            context.sendBroadcast(new Intent(Intent.ACTION_MEDIA_SCANNER_SCAN_FILE, Uri.parse(file.getAbsolutePath())));
        } catch (FileNotFoundException e) {
            debugLog.send(e, "saveToSystemGalleryExceptionFileNotFoundException", "unityjar");
            e.printStackTrace();

        } catch (IOException e) {
            e.printStackTrace();
            debugLog.send(e, "saveToSystemGalleryExceptionIOException", "unityjar");

        }

    }

    /*
     * 保存文件，文件名为当前日期
     */
    public static void saveBitmap(Bitmap bitmap, String bitName, Context context) throws ParseException, JSONException, IOException {
        String fileName;
        File file;
        debugLog.send(Build.BRAND, "saveBitmapBuild.BRAND", "unityjar");


        if (Build.BRAND.equals("xiaomi")) { // 小米手机
            fileName = Environment.getExternalStorageDirectory().getPath() + "/DCIM/Camera/" + bitName;
        } else if (Build.BRAND.equals("Huawei")) {
            fileName = Environment.getExternalStorageDirectory().getPath() + "/DCIM/Camera/" + bitName;
        } else {  // Meizu 、Oppo
            fileName = Environment.getExternalStorageDirectory().getPath() + "/DCIM/" + bitName;
        }
        file = new File(fileName);

        if (file.exists()) {
            file.delete();
        }
        FileOutputStream out;
        try {
            out = new FileOutputStream(file);
            // 格式为 JPEG，照相机拍出的图片为JPEG格式的，PNG格式的不能显示在相册中
            if (bitmap.compress(Bitmap.CompressFormat.JPEG, 90, out)) {
                out.flush();
                out.close();
// 插入图库
                MediaStore.Images.Media.insertImage(context.getContentResolver(), file.getAbsolutePath(), bitName, null);


            }
        } catch (FileNotFoundException e) {
            e.printStackTrace();
            debugLog.send(fileName, "saveBitmapFileNotFoundExceptionfileName", "unityjar");
            debugLog.send(e.getMessage(), "saveBitmapFileNotFoundException", "unityjar");

        } catch (IOException e) {
            e.printStackTrace();
            debugLog.send(e.getMessage(), "saveBitmapIOException", "unityjar");

        }
        // 发送广播，通知刷新图库的显示
        //context.sendBroadcast(new Intent(Intent.ACTION_MEDIA_SCANNER_SCAN_FILE, Uri.parse("file://" + fileName)));
    }

}
