using UnityEngine;
using System.Collections;
using System.Runtime.InteropServices;
using System;

public class IOSInterface : AbstractClass
{
    [DllImport("__Internal")]
    private static extern void _CloseUnity(string wenwen);
    public override void CloseUnity(string wenwen)
    {
        _CloseUnity(wenwen);
    }
    [DllImport("__Internal")]
    private static extern void _PreservationSPhoto(string wenwen);
    public override void PreservationSPhoto(string wenwen)
    {
        _PreservationSPhoto(wenwen);
    }
    [DllImport("__Internal")]
    private static extern void _PreservationSvideotape(string wenwen);
    public override void PreservationSvideotape(string wenwen)
    {
        _PreservationSvideotape(wenwen);
    }
}
