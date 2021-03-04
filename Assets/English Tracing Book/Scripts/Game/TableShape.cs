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
using System;
namespace IndieStudio.LetterWrite.Utility
{
	///Developed by Indie Studio
	///https://www.assetstore.unity3d.com/en/#!/publisher/9268
	///www.indiestd.com
	///info@indiestd.com

	[DisallowMultipleComponent]
	public class TableShape : MonoBehaviour
	{
		/// <summary>
		/// The selected shape.
		/// </summary>
		public static TableShape selectedShape;

		/// <summary>
		/// Table Shape ID.
		/// </summary>
		public int ID = -1;

		/// <summary>
		/// The stars number(Rating).
		/// </summary>
		public StarsNumber starsNumber = StarsNumber.ZERO;

		/// <summary>
		/// Whether the shape is locked or not.
		/// </summary>
		[HideInInspector]
		public bool isLocked = true;

		// Use this for initialization
		void Start()
		{
			///Setting up the ID for Table Shape
			if (ID == -1)
			{
				string[] tokens = gameObject.name.Split('-');
				if (tokens != null)
				{
					ID = int.Parse(tokens[1]);
				}
			}
		}

		public enum StarsNumber
		{
			ZERO,
			ONE,
			TWO,
			THREE
		}
	}
}