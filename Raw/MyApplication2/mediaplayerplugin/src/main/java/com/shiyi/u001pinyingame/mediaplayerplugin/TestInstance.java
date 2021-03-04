package com.shiyi.u001pinyingame.mediaplayerplugin;

import com.unity3d.player.UnityPlayer;

public class TestInstance {
    public void sendMessageToUnity(){
        UnityPlayer.UnitySendMessage("Canvas","AndroidCallBack","测试成功");
    }

    private static TestInstance _____Install;

    public static TestInstance GetInstall(){
        if (_____Install == null){
            _____Install = new TestInstance();
        }
        return _____Install;
    }

    public int testInt(){
        return 13;
    }

    public String testString(){
        return "msg";
    }

    public String testSetString(String string)
    {
        sendMessageToUnity();
        return  string;
    }
}
