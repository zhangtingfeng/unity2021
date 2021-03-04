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

	public class Pointer : MonoBehaviour
	{
		public Group group;//the group reference

		/// <summary>
		/// Create a pointer.
		/// </summary>
		/// <param name="groupIndex">Group index.</param>
		/// <param name="levelsGroup">Levels group.</param>
		/// <param name="pointerPrefab">Pointer prefab.</param>
		/// <param name="pointersParent">Pointers parent.</param>
		public static void CreatePointer(int groupIndex, GameObject levelsGroup, GameObject pointerPrefab, Transform pointersParent)
		{
			if (levelsGroup == null || pointerPrefab == null || pointersParent == null)
			{
				return;
			}

			//Create Slider Pointer
			GameObject pointer = Instantiate(pointerPrefab, Vector3.zero, Quaternion.identity) as GameObject;
			pointer.transform.SetParent(pointersParent);
			pointer.name = "Pointer-" + CommonUtilLetter.IntToString(groupIndex + 1);
			pointer.transform.localScale = Vector3.one;
			pointer.GetComponent<RectTransform>().offsetMax = Vector2.zero;
			pointer.GetComponent<RectTransform>().offsetMin = Vector2.zero;
			pointer.GetComponent<Pointer>().group = levelsGroup.GetComponent<Group>();
			pointer.GetComponent<Button>().onClick.AddListener(() => GameObject.FindObjectOfType<UIEvents>().PointerButtonEvent(pointer.GetComponent<Pointer>()));
		}
	}
}