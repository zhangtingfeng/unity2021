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
using System.Collections.Generic;
namespace IndieStudio.LetterWrite.Utility
{
	///Developed by Indie Studio
	///https://www.assetstore.unity3d.com/en/#!/publisher/9268
	///www.indiestd.com
	///info@indiestd.com

	public class ShapesManagerLetter : MonoBehaviour
	{
		/// <summary>
		/// The shapes list.
		/// </summary>
		public List<Shape> shapes = new List<Shape>();

		/// <summary>
		/// The shape label (example Letter or Number).
		/// </summary>
		public string shapeLabel = "Shape";

		/// <summary>
		/// The shape prefix used for DataManager only (example Lowercase or Uppercase or Number).
		/// </summary>
		public string shapePrefix = "Shape";

		/// <summary>
		/// The name of the scene.
		/// </summary>
		public string sceneName = "";

		/// <summary>
		/// The last selected group.
		/// </summary>
		[HideInInspector]
		public int lastSelectedGroup;

		/// <summary>
		/// The name of the shapes manager.
		/// </summary>
		public static string shapesManagerReference = "";

		/// <summary>
		/// The init shapes managers flags.
		/// </summary>
		public Hashtable initFlags = new Hashtable();

		void Awake()
		{
			if (initFlags.Contains(gameObject.name))
			{
				Destroy(gameObject);
			}
			else
			{
				initFlags.Add(gameObject.name, true);
				DontDestroyOnLoad(gameObject);
				lastSelectedGroup = 0;
			}
		}

		[System.Serializable]
		public class Shape
		{
			public bool showContents = true;
			public GameObject gamePrefab;
			public Sprite picture;
		}
	}
}