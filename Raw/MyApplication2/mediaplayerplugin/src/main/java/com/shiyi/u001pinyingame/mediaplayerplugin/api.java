package com.shiyi.u001pinyingame.mediaplayerplugin;

import android.util.Log;

import java.io.BufferedReader;
import java.io.FileReader;
import java.io.IOException;

public class api
{
    private static api _instance;
    public static api instance()
    {
        if(null == _instance)
            _instance = new api();
        return _instance;
    }

    public String GetCpuInfo()
    {
        String str1 = "/proc/cpuinfo";
        String str2 = "";

        try {
            FileReader fr = new FileReader(str1);
            BufferedReader br = new BufferedReader(fr);
            while ((str2=br.readLine()) != null) {
                Log.v("ZP", str2);
                if (str2.contains("Hardware")) {
                    return str2.split(":")[1];
                }
            }
            br.close();
        } catch (IOException e) {
        }
        return null;
    }
}