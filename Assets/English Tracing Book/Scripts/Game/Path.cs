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
using System.Collections.Generic;
namespace IndieStudio.LetterWrite.Utility
{
	///Developed by Indie Studio
	///https://www.assetstore.unity3d.com/en/#!/publisher/9268
	///www.indiestd.com
	///info@indiestd.com

	namespace EnglishTracingBook
	{
		public class Path : MonoBehaviour
		{
			/// <summary>
			/// Whether to flip the direction of the path or not.
			/// </summary>
			public bool flip;

			/// <summary>
			/// Whether the path is completed or not.
			/// </summary>
			[HideInInspector]
			public bool completed;

			/// <summary>
			/// The fill method (Radial or Linear or Point).
			/// </summary>
			public FillMethod fillMethod;

			/// <summary>
			/// The type of the shape (Used for Vertical Fill method).
			/// </summary>
			public ShapeType type = ShapeType.Vertical;

			/// <summary>
			/// The angle offset in degree(For Linear Fill).
			/// </summary>
			public float offset = 90;

			/// <summary>
			/// The complete offset (The fill amount offset).
			/// </summary>
			public float completeOffset = 0.85f;

			/// <summary>
			/// The first number reference.
			/// </summary>
			public Transform firstNumber;

			/// <summary>
			/// The second number reference.
			/// </summary>
			public Transform secondNumber;

			/// <summary>
			/// Whether to run the auto fill or not.
			/// </summary>
			private bool autoFill;

			/// <summary>
			/// Whether to enable the quarter's restriction on the current angle or not.
			/// </summary>
			public bool quarterRestriction = true;

			/// <summary>
			/// The offset of the current radial angle(For Radial Fill) .
			/// </summary>
			public float radialAngleOffset = 0;

			/// <summary>
			/// The shape reference.
			/// </summary>
			[HideInInspector]
			public Shape shape;

			// Use this for initialization
			void Awake()
			{
				shape = GetComponentInParent<Shape>();
			}

			/// <summary>
			/// Auto fill.
			/// </summary>
			public void AutoFill()
			{
				StartCoroutine("AutoFillCoroutine");
			}

			/// <summary>
			/// Set the numbers status.
			/// </summary>
			/// <param name="status">the status value.</param>
			public void SetNumbersStatus(bool status)
			{
				Color tempColor = Color.white;
				List<Transform> numbers = CommonUtilLetter.FindChildrenByTag(transform.Find("Numbers"), "Number");
				foreach (Transform number in numbers)
				{
					if (number == null)
						continue;

					if (status)
					{
						EnableStartCollider();
						number.GetComponent<Animator>().SetBool("Select", true);
						tempColor.a = 1;
					}
					else
					{

						if (shape.enablePriorityOrder || completed)
						{
							DisableStartCollider();
						}

						if (shape.enablePriorityOrder)
						{
							number.GetComponent<Animator>().SetBool("Select", false);
							tempColor.a = 0.3f;
						}
					}

					number.GetComponent<Image>().color = tempColor;
				}
			}

			/// <summary>
			/// Set the numbers visibility.
			/// </summary>
			/// <param name="visible">visibility value.</param>
			public void SetNumbersVisibility(bool visible)
			{
				List<Transform> numbers = CommonUtilLetter.FindChildrenByTag(transform.Find("Numbers").transform, "Number");
				foreach (Transform number in numbers)
				{
					if (number != null)
						number.gameObject.SetActive(visible);
				}
			}

			/// <summary>
			/// Enable the start collider.
			/// </summary>
			public void EnableStartCollider()
			{
				transform.Find("Start").GetComponent<Collider2D>().enabled = true;
			}

			/// <summary>
			/// Disable the start collider.
			/// </summary>
			public void DisableStartCollider()
			{
				transform.Find("Start").GetComponent<Collider2D>().enabled = false;
			}

			/// <summary>
			/// Reset the path.
			/// </summary>
			public void Reset()
			{
				SetNumbersVisibility(true);
				completed = false;
				if (!shape.enablePriorityOrder)
				{
					SetNumbersStatus(true);
				}
				StartCoroutine("ReleaseCoroutine");
			}


			/// <summary>
			/// Auto fill coroutine.
			/// </summary>
			/// <returns>The fill coroutine.</returns>
			private IEnumerator AutoFillCoroutine()
			{
				Image image = CommonUtilLetter.FindChildByTag(transform, "Fill").GetComponent<Image>();
				while (image.fillAmount < 1)
				{
					image.fillAmount += 0.02f;
					yield return new WaitForSeconds(0.001f);
				}
			}

			/// <summary>
			/// Release the coroutine.
			/// </summary>
			/// <returns>The coroutine.</returns>
			private IEnumerator ReleaseCoroutine()
			{
				Image image = CommonUtilLetter.FindChildByTag(transform, "Fill").GetComponent<Image>();
				while (image.fillAmount > 0)
				{
					image.fillAmount -= 0.02f;
					yield return new WaitForSeconds(0.005f);
				}
			}

			public enum ShapeType
			{

				Horizontal,
				Vertical
			}

			public enum FillMethod
			{
				Radial,
				Linear,
				Point
			}

			public enum CenterReference
			{
				PATH_GAMEOBJECT,
				FILL_GAMEOBJECT
			}
		}
	}
}