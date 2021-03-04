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
namespace IndieStudio.LetterWrite.Utility
{
	///Developed by Indie Studio
	///https://www.assetstore.unity3d.com/en/#!/publisher/9268
	///www.indiestd.com
	///info@indiestd.com

	[DisallowMultipleComponent]
	public class Logo : MonoBehaviour
	{
		/// <summary>
		/// The sleep time.
		/// </summary>
		public float sleepTime = 5;

		/// <summary>
		/// The name of the scene to load.
		/// </summary>
		public string nextSceneName;

		// Use this for initialization
		void Start()
		{
			Invoke("LoadScene", sleepTime);
		}

		private void LoadScene()
		{
			if (string.IsNullOrEmpty(nextSceneName))
			{
				return;
			}
			Application.LoadLevel(nextSceneName);
		}
	}
}