package com.shiyi.u001pinyingame.mediaplayerplugin;

import com.unity3d.player.*;
import android.app.Activity;
import android.app.AlertDialog;
import android.content.Context;
import android.content.DialogInterface;
import android.graphics.Color;
import android.view.Gravity;
import android.widget.TextView;
import android.widget.Toast;

import org.json.JSONException;

import java.io.IOException;
import java.text.ParseException;

public class toastDialog extends Activity {
    private Context mContext;

    public void ToastMakeText(String msg, Context Contextthis) throws ParseException, IOException, JSONException {
        mContext = Contextthis;

        Toast toast = Toast.makeText(Contextthis, msg, Toast.LENGTH_LONG);
        toast.setGravity(Gravity.CENTER_VERTICAL | Gravity.CENTER_HORIZONTAL, 0, 0);
        TextView v = (TextView) toast.getView().findViewById(android.R.id.message);
        v.setTextColor(Color.YELLOW);
        toast.show();
    }

    public void AlertDialog(Context Contextthis,String strTitle,String stringContent,int intTypeButton,final String type1Return,final String type2Return,final String type3Return) throws ParseException, IOException, JSONException {

        //    通过AlertDialog.Builder这个类来实例化我们的一个AlertDialog的对象
        AlertDialog.Builder builder = new AlertDialog.Builder(Contextthis);
        //    设置Title的图标
        //builder.setIcon(R.drawable.ic_launcher);
        //    设置Title的内容
        builder.setTitle(strTitle);
        //    设置Content来显示一个信息
        builder.setMessage(stringContent);
        //    设置一个PositiveButton
        builder.setPositiveButton("确定", new DialogInterface.OnClickListener() {
            @Override
            public void onClick(DialogInterface dialog, int which) {
                UnityPlayer.UnitySendMessage("Main Camera","getjarMessage",type1Return);
               // Toast.makeText(Contextthis, "positive: " + which, Toast.LENGTH_SHORT).show();
            }
        });
        if(intTypeButton==2){
            //    设置一个NegativeButton
            builder.setNegativeButton("取消", new DialogInterface.OnClickListener() {
                @Override
                public void onClick(DialogInterface dialog, int which) {
                    UnityPlayer.UnitySendMessage("Main Camera","getjarMessage",type2Return);
                    //Toast.makeText(MainActivity.this, "negative: " + which, Toast.LENGTH_SHORT).show();
                }
            });
        }

        if(intTypeButton==3) {
            //    设置一个NeutralButton
            builder.setNeutralButton("忽略", new DialogInterface.OnClickListener() {
                @Override
                public void onClick(DialogInterface dialog, int which) {
                    UnityPlayer.UnitySendMessage("Main Camera", "getjarMessage", type3Return);
                    //Toast.makeText(MainActivity.this, "neutral: " + which, Toast.LENGTH_SHORT).show();
                }
            });
        }
        //    显示出该对话框
        builder.show();
    }


}
