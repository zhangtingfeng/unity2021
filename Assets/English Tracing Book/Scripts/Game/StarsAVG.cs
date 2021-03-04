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

	public class StarsAVG : MonoBehaviour
	{

		/// <summary>
		/// The stars reference.
		/// </summary>
		public Image[] stars;

		/// <summary>
		/// The shapes manager reference as name.
		/// </summary>
		public string shapesManagerReference;

		/// <summary>
		/// The star on,off sprites.
		/// </summary>
		public Sprite starOn, starOff;

		// Use this for initialization
		IEnumerator Start()
		{

			yield return 0;

			//Setting up the stars rating(Average)
			ShapesManagerLetter shapesManager = GameObject.Find(shapesManagerReference).GetComponent<ShapesManagerLetter>();
			int collectedStars = DataManager.GetCollectedStars(shapesManager);
			int starsRate = Mathf.FloorToInt(collectedStars / (shapesManager.shapes.Count * 3.0f) * 3.0f);

			if (starsRate == 0)
			{//Zero Stars
				stars[0].sprite = starOff;
				stars[1].sprite = starOff;
				stars[2].sprite = starOff;
			}
			else if (starsRate == 1)
			{//One Star
				stars[0].sprite = starOn;
				stars[1].sprite = starOff;
				stars[2].sprite = starOff;
			}
			else if (starsRate == 2)
			{//Two Stars
				stars[0].sprite = starOn;
				stars[1].sprite = starOn;
				stars[2].sprite = starOff;
			}
			else
			{//Three Stars
				stars[0].sprite = starOn;
				stars[1].sprite = starOn;
				stars[2].sprite = starOn;
			}
		}
	}
}