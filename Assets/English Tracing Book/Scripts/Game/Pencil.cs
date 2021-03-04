/*
http://www.cgsoso.com/forum-211-1.html

CG搜搜 Unity3d 每日Unity3d插件免费更新 更有VIP资源！

CGSOSO 主打游戏开发，影视设计等CG资源素材。

插件如若商用，请务必官网购买！

daily assets update for try.

U should buy the asset from home store if u use it in your project!
*/

using UnityEngine;
using UnityEngine.UI;
using System.Collections;
namespace IndieStudio.LetterWrite.Utility
{
	///Developed by Indie Studio
	///https://www.assetstore.unity3d.com/en/#!/publisher/9268
	///www.indiestd.com
	///info@indiestd.com

	public class Pencil : MonoBehaviour
	{
		/// <summary>
		/// The color of the pencil.
		/// </summary>
		public Color value;

		void Start()
		{
			GetComponent<Button>().onClick.AddListener(() => GameObject.FindObjectOfType<UIEvents>().PencilClickEvent(this));
		}

		/// <summary>
		/// Enable pencil selection.
		/// </summary>
		public void EnableSelection()
		{
			GetComponent<Animator>().SetBool("RunScale", true);
		}

		/// <summary>
		/// Disable pencil selection.
		/// </summary>
		public void DisableSelection()
		{
			GetComponent<Animator>().SetBool("RunScale", false);
		}
	}
}