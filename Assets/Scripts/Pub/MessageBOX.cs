using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace Assets.Script
{
    public class MessageBOX
    {
        [DllImport("User32.dll", SetLastError = true, ThrowOnUnmappableChar = true, CharSet = CharSet.Auto)]
        public static extern int MessageBox(IntPtr handle, String message, String title, int type);//具体方法
    }


    /// <summary>
    /// 9个按钮对应弹框
    /// </summary>
    /// <param name="index"></param>
    //private void Button(int index)
    //{
    //    switch (index)
    //    {
    //        case 0:
    //            returnNumber = ChinarMessage.MessageBox(IntPtr.Zero, "Chinar-0:返回值均：1", "确认", 0);
    //            print(returnNumber);
    //            break;
    //        case 1:
    //            returnNumber = ChinarMessage.MessageBox(IntPtr.Zero, "Chinar-1:确认：1，取消：2", "确认|取消", 1);
    //            print(returnNumber);
    //            break;
    //        case 2:
    //            returnNumber = ChinarMessage.MessageBox(IntPtr.Zero, "Chinar-2:中止：3，重试：4，忽略：5", "中止|重试|忽略", 2);
    //            print(returnNumber);
    //            break;
    //        case 3:
    //            returnNumber = ChinarMessage.MessageBox(IntPtr.Zero, "Chinar-3:是：6，否：7，取消：2", "是 | 否 | 取消", 3);
    //            print(returnNumber);
    //            break;
    //        case 4:
    //            returnNumber = ChinarMessage.MessageBox(IntPtr.Zero, "Chinar-4:是：6，否：7", "是 | 否", 4);
    //            print(returnNumber);
    //            break;
    //        case 5:
    //            returnNumber = ChinarMessage.MessageBox(IntPtr.Zero, "Chinar-5:重试：4，取消：2", "重试 | 取消", 5);
    //            print(returnNumber);
    //            break;
    //        case 6:
    //            returnNumber = ChinarMessage.MessageBox(IntPtr.Zero, "Chinar-6:取消：2，重试：10，继续：11", "取消 | 重试 | 继续", 6);
    //            print(returnNumber);
    //            break;
    //    }
    //}

}
