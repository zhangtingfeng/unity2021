using UnityEngine;
using System.Collections;
/// <summary>
/// 方法列表
/// </summary>
public abstract class AbstractClass
{
    /// <summary>
    /// 关闭U3D
    /// </summary>
    /// <param name="data"></param>
    public abstract void CloseUnity(string data);
    /// <summary>
    /// 保存照片
    /// </summary>
    /// <param name="data"></param>
    public abstract void PreservationSPhoto(string data);
    /// <summary>
    /// 保存录像
    /// </summary>
    /// <param name="data"></param>
    public abstract void PreservationSvideotape(string data);
}
