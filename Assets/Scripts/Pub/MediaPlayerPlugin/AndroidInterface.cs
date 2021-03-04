#if UNITY_ANDROID
using UnityEngine;
using System.Collections;
/// <summary>
/// 安卓方法列表
/// </summary>
public class AndroidInterface : AbstractClass
{
    /// <summary>
    /// 关闭U3D
    /// </summary>
    /// <param name="data"></param>
    public override void CloseUnity(string data)
    {
        Debug.Log("CloseUnity");
        MyAndroidPlayer.SendMessage("CloseUnity", data);
    }
    /// <summary>
    /// 保存照片
    /// </summary>
    /// <param name="data"></param>
    public override void PreservationSPhoto(string data)
    {
        Debug.Log("PreservationSPhoto");
        MyAndroidPlayer.SendMessage("PreservationSPhoto", data);
    }
    /// <summary>
    /// 保存录像
    /// </summary>
    /// <param name="data"></param>
    public override void PreservationSvideotape(string data)
    {
        Debug.Log("PreservationSvideotape");
        MyAndroidPlayer.SendMessage("PreservationSvideotape", data);
    }
}
#endif
