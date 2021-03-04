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
	public class Dialog : MonoBehaviour
	{
		/// <summary>
		/// The animator of Dialog.
		/// </summary>
		public Animator animator;

		/// <summary>
		/// Wheter the Dialog is visible or not.
		/// </summary>
		[HideInInspector]
		public bool visible;

		/// <summary>
		/// The White Area animator.
		/// </summary>
		public Animator whiteAreaAnimator;

		void Start()
		{
			if (animator == null)
			{
				animator = GetComponent<Animator>();
			}

			if (whiteAreaAnimator == null)
			{
				whiteAreaAnimator = GameObject.Find("WhiteArea").GetComponent<Animator>();
			}
		}

		/// <summary>
		/// Show the dialog.
		/// </summary>
		public void Show()
		{
			visible = true;
			whiteAreaAnimator.SetTrigger("Running");
			animator.SetBool("Off", false);
			animator.SetTrigger("On");
		}

		/// <summary>
		/// Hide the dialog.
		/// </summary>
		public void Hide()
		{
			visible = false;
			whiteAreaAnimator.SetBool("Running", false);
			animator.SetBool("On", false);
			animator.SetTrigger("Off");
		}
	}
}