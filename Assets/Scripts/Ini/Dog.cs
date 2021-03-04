

using Assets.Script;
using System.Runtime.InteropServices;
using UnityEngine;

public class Dog
{
    


    // Use this for initialization
    public static bool ReadDog()
    {
        return true;
        WindowsApplicationDog.SoftKeyYT88 ytsoftkey;
        string KeyPath="";
        //初始化我们的操作加密锁的类
        ytsoftkey = new WindowsApplicationDog.SoftKeyYT88();
        //这个用于判断系统中是否存在着加密锁。不需要是指定的加密锁,
        if (ytsoftkey.FindPort(0, ref KeyPath) != 0)
        {
            MessageBOX.MessageBox(System.IntPtr.Zero, "未找到加密锁,请插入加密锁后，再进行操作！", "加密锁", 0);
            Debug.Log("未找到加密锁,请插入加密锁后，再进行操作。");
          
            //("未找到加密锁,请插入加密锁后，再进行操作。");
            return false;
          
            // Application.Exit();
        }


        //使用普通算法一来查找指定的加密锁
        /*查找是否存在指定的加密狗,如果找到，则返回0,DevicePath为锁所在的返回设备所在的路径。
        注意！！！！！！！！！这里的参数“1”及参数“134226688”，随每个软件开发商的不同而不同，因为每个开发商的加密锁的加密算法都不一样，
        1、运行我们的开发工具，
        2、在“算法设置及测试页”-》“加密”-》“请输入要加密的数据”那里随意输入一个数
        3、然后单击“加密数据(使用普通算法一)”
        4、然后就会返回对应的数据(即“加密后的数据”)，
        然后将输入的数和返回的数替换这里的参数“1”及参数“1265770935”   testdog 1265770935*/
        //if (ytsoftkey.FindPort_2(0, 19750222, 467932137, ref KeyPath) != 0)///19750222  原触动音乐
        if (ytsoftkey.FindPort_2(0, 20210125, 627581780, ref KeyPath) != 0)///1970223  这个是实验山东减肥项目用的
        {
            MessageBOX.MessageBox(System.IntPtr.Zero, "未找到指定的加密锁" + "  请你调整后继续！", "加密锁", 0);
            Debug.Log("未找到指定的加密锁" + "  请你调整后继续！");
            return false;
            //20210125 - 627581780
           // MessageBox.Show("未找到指定的加密锁" + "  请你调整后继续！");

            // return false;
        }
        else
        {
            //label1.Content = "软件授权环境正确";
            return true;
        }

    }


}
