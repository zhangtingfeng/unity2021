/*
http://www.cgsoso.com/forum-211-1.html

CG搜搜 Unity3d 每日Unity3d插件免费更新 更有VIP资源！

CGSOSO 主打游戏开发，影视设计等CG资源素材。

插件如若商用，请务必官网购买！

daily assets update for try.

U should buy the asset from home store if u use it in your project!
*/

using UnityEngine;
using System.Collections;

///Developed by Indie Studio
///https://www.assetstore.unity3d.com/en/#!/publisher/9268
///www.indiestd.com
///info@indiestd.com
namespace IndieStudio.LetterWrite.Utility
{
	[DisallowMultipleComponent]
	public class OSCursorManager : MonoBehaviour
	{
		/// <summary>
		/// The status of the OS cursor.
		/// </summary>
		public CursorStatus status = CursorStatus.ENABLED;

		// Update is called once per frame
		void Start()
		{
#if (!(UNITY_ANDROID || UNITY_IPHONE) || UNITY_EDITOR)
			if (status == CursorStatus.ENABLED)
			{
				Cursor.visible = true;
			}
			else if (status == CursorStatus.DISABLED)
			{
				Cursor.visible = false;
			}
#endif
		}

		public enum CursorStatus
		{
			ENABLED,
			DISABLED
		};
	}
}