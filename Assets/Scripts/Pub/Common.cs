using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Net;
using System.Runtime.InteropServices;
using System.Collections;

/// <summary>
///Subscribe 的摘要说明
/// </summary>
public class Common
{
    [DllImport("user32.dll")]
    private static extern int SetCursorPos(int x, int y); //设置光标位置
    [DllImport("user32.dll")]
    static extern void mouse_event(MouseEventFlag flags, int dx, int dy, uint data, UIntPtr extraInfo); //鼠标事件
                                                                                                        //这个枚举同样来自user32.dll
    [Flags]
    enum MouseEventFlag : uint
    {
        Move = 0x0001,
        LeftDown = 0x0002,
        LeftUp = 0x0004,
        RightDown = 0x0008,
        RightUp = 0x0010,
        MiddleDown = 0x0020,
        MiddleUp = 0x0040,
        XDown = 0x0080,
        XUp = 0x0100,
        Wheel = 0x0800,
        VirtualDesk = 0x4000,
        Absolute = 0x8000
    }

    public struct CursorPos
    {
        public float x;
        public float y;
    }

    //计算时间的差值
    public static string DateDiff(DateTime DateTime1, DateTime DateTime2)
    {
        string dateDiff = null;
        TimeSpan ts1 = new TimeSpan(DateTime1.Ticks);
        TimeSpan ts2 = new TimeSpan(DateTime2.Ticks);

        TimeSpan ts = ts1.Subtract(ts2).Duration();
        //ts.Days.ToString() + "天" +
        dateDiff = ts.Hours.ToString() + "小时" + ts.Minutes.ToString() + "分钟" + ts.Seconds.ToString() + "秒";
        return dateDiff;

        #region note
        //C#中使用TimeSpan计算两个时间的差值
        //可以反加两个日期之间任何一个时间单位。
        //TimeSpan ts = Date1 - Date2;
        //double dDays = ts.TotalDays;//带小数的天数，比如1天12小时结果就是1.5
        //int nDays = ts.Days;//整数天数，1天12小时或者1天20小时结果都是1 
        #endregion
    }



    //模拟鼠标左键点击
    public static void MouseClickSimulate(CursorPos ddCursorPosdd)
    {
        SetCursorPos(ddCursorPosdd.x.toInt32(), ddCursorPosdd.y.toInt32());
        mouse_event(MouseEventFlag.LeftDown, 0, 0, 0, UIntPtr.Zero);
        mouse_event(MouseEventFlag.LeftUp, 0, 0, 0, UIntPtr.Zero);

    }

    public static CursorPos getCursorPos(UnityEngine.Camera mycamera, UnityEngine.GameObject kongjian)
    {
        ;//要转化到的目的摄像机，通常canvas在这个摄像机下（即canvas的render mode设置为这个摄像机）
         //Image kongjian;//自己要获取屏幕坐标的控件，可以是image，也可以是button等等


        float x = mycamera.WorldToScreenPoint(kongjian.transform.position).x;
        float y = mycamera.WorldToScreenPoint(kongjian.transform.position).y;

        CursorPos ddCursorPosd = new CursorPos();
        ddCursorPosd.x = x;
        ddCursorPosd.y = y;
        return ddCursorPosd;
        //x,y即为控件在屏幕的坐标camera.WorldToScreenPoint()方法返回的是一个position类型 是vector3类型，camera为要转化到的目标摄像机，传入的参数为控件的世界坐标
        //————————————————
        //版权声明：本文为CSDN博主「然然嘿嘿」的原创文章，遵循CC 4.0 BY-SA版权协议，转载请附上原文出处链接及本声明。
        //原文链接：https://blog.csdn.net/sinat_23079759/java/article/details/53159858

    }


    #region 得到一个随机数组
    public static ArrayList getShiftArrayList(int intMaxNum, ArrayList bContentArrayList)
    {
        ArrayList bReturnArrayList = new ArrayList();
        ArrayList bgetArrayList = getArrayList(intMaxNum, bContentArrayList);
        for (int i = 0; i < intMaxNum; i++)
        {
            System.Random ran = new System.Random();
            int RandKey = ran.Next(0, bgetArrayList.Count);
            String straddkey = bgetArrayList[RandKey].toString();
            bReturnArrayList.Add(straddkey);
            bgetArrayList.RemoveAt(RandKey);
        }



        return bReturnArrayList;
    }
    public static ArrayList getArrayList(int intMaxNum, ArrayList bContentArrayList)
    {
        ArrayList bReturnArrayList = new ArrayList();
        int i = 0;

        while (i < intMaxNum)
        {
            for (int j = 0; j < bContentArrayList.Count; j++)
            {
                if (i < intMaxNum)
                {
                    bReturnArrayList.Add(bContentArrayList[j]);
                    i++;
                }
            }
        }

        return bReturnArrayList;
    }


    #endregion

}

