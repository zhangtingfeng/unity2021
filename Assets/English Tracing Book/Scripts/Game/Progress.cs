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
using UnityEngine.UI;
namespace IndieStudio.LetterWrite.Utility
{
	///Developed by Indie Studio
	///https://www.assetstore.unity3d.com/en/#!/publisher/9268
	///www.indiestd.com
	///info@indiestd.com

	public class Progress : MonoBehaviour
	{
		/// <summary>
		/// The star off sprite.
		/// </summary>
		public Sprite starOff;

		/// <summary>
		/// The star on sprite.
		/// </summary>
		public Sprite starOn;

		/// <summary>
		/// The level stars.
		/// </summary>
		public Image[] levelStars;

		/// <summary>
		/// The game manager reference.
		/// </summary>
		public GameManager gameManager;

		/// <summary>
		/// The progress image.
		/// </summary>
		public Image progressImage;

		/// <summary>
		/// The stars number.
		/// </summary>
		[HideInInspector]
		public WinDialog.StarsNumber starsNumber;

		// Use this for initialization
		void Start()
		{
			if (progressImage == null)
			{
				progressImage = GetComponent<Image>();
			}

			if (gameManager == null)
			{
				gameManager = GameObject.FindObjectOfType<GameManager>();
			}
		}

		/// <summary>
		/// Set the value of the progress.
		/// </summary>
		/// <param name="currentTime">Current time.</param>
		public void SetProgress(float currentTime)
		{
			if (gameManager == null)
			{
				return;
			}

			if (gameManager.shape == null)
			{
				return;
			}

			if (progressImage != null)
				progressImage.fillAmount = 1 - (currentTime / (gameManager.shape.twoStarsTimePeriod * 1.0f + 1));

			if (currentTime >= 0 && currentTime <= gameManager.shape.threeStarsTimePeriod)
			{
				if (levelStars[0] != null)
				{
					levelStars[0].sprite = starOn;
				}
				if (levelStars[1] != null)
				{
					levelStars[1].sprite = starOn;
				}
				if (levelStars[2] != null)
				{
					levelStars[2].sprite = starOn;
				}
				if (progressImage != null)
					progressImage.color = Colors.greenColor;

				starsNumber = WinDialog.StarsNumber.THREE;
			}
			else if (currentTime > gameManager.shape.threeStarsTimePeriod && currentTime <= gameManager.shape.twoStarsTimePeriod)
			{
				if (levelStars[2] != null)
				{
					levelStars[2].sprite = starOff;
				}
				if (progressImage != null)
					progressImage.color = Colors.yellowColor;
				starsNumber = WinDialog.StarsNumber.TWO;

			}
			else
			{
				if (levelStars[1] != null)
				{
					levelStars[1].sprite = starOff;
				}
				if (levelStars[2] != null)
				{
					levelStars[2].sprite = starOff;
				}
				if (progressImage != null)
					progressImage.color = Colors.redColor;
				starsNumber = WinDialog.StarsNumber.ONE;
			}
		}

	}
}