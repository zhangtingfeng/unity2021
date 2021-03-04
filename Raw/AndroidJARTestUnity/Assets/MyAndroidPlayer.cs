using UnityEngine;
using System.Collections;
#if UNITY_ANDROID
public class MyAndroidPlayer : MonoBehaviour
{
	public delegate void ObtainMessageDelegate(string messageType, string message);
	public static ObtainMessageDelegate ObtainMessage;

	private static AndroidJavaClass androidJavaClass;

	private static AndroidJavaObject androidJavaObject;

	private char SEPARATOR = '~';

	void Awake()
	{

		if (Application.platform != RuntimePlatform.Android) return;
		androidJavaClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
		androidJavaObject = androidJavaClass.GetStatic<AndroidJavaObject>("currentActivity");
		//	androidJavaObject = androidJavaObject.Get<AndroidJavaObject>("functionUnity");
		Debug_Log.Call_WriteLog("com.unity3d.player.UnityPlayer", "com.unity3d.player.UnityPlayer", "unity");
	}

	public static void SendMessage(string method, string msgArgs)
	{
		Debug.Log(method);
		androidJavaObject.Call(method, new string[] { msgArgs });
	}
}

#endif
