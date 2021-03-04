using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class SelectPlatform : MonoBehaviour
{

#if UNITY_ANDROID
	/// <summary>
	/// Android平台接口
	/// </summary>
	public static AndroidInterface android = new AndroidInterface();

#elif UNITY_IPHONE

	/// <summary>
	/// IOS平台接口
	/// </summary>
	public static IOSInterface ios=new IOSInterface();

#endif

	/// <summary>
	/// 对Android或IOS接口进行调用
	/// </summary>
	public static System.Object SendMessage(string funName, string data)
	{
#if UNITY_ANDROID
		Type type = typeof(AndroidInterface);
		return type.GetMethod(funName).Invoke(android, new object[] { data });
#elif UNITY_IPHONE
		Type type = typeof(IOSInterface);
		return type.GetMethod(funName).Invoke(ios,new object[]{data});
#elif UNITY_EDITOR || UNITY_EDITOR_WIN || UNITY_STANDALONE_WIN
		return null;
#endif
	}
}
