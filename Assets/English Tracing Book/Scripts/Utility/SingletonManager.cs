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

	public class SingletonManager : MonoBehaviour
	{

		public GameObject[] values;

		// Use this for initialization
		void Awake()
		{
			InitManagers();
		}

		private void InitManagers()
		{
			if (values == null)
			{
				return;
			}

			foreach (GameObject value in values)
			{
				if (GameObject.Find(value.name) == null)
				{
					GameObject temp = Instantiate(value, Vector3.zero, Quaternion.identity) as GameObject;
					temp.name = value.name;
				}
			}
		}
	}
}