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

	public class Group : MonoBehaviour
	{
		public int Index;//the group's Index

		/// <summary>
		/// Create a group.
		/// </summary>
		/// <returns>The group.</returns>
		/// <param name="levelsGroupPrefab">Levels group prefab.</param>
		/// <param name="groupsParent">Groups parent.</param>
		/// <param name="groupIndex">Group index.</param>
		/// <param name="columnsPerGroup">Columns per group.</param>
		public static GameObject CreateGroup(GameObject levelsGroupPrefab, Transform groupsParent, int groupIndex, int columnsPerGroup)
		{
			//Create Levels Group
			GameObject levelsGroup = Instantiate(levelsGroupPrefab, Vector3.zero, Quaternion.identity) as GameObject;
			levelsGroup.transform.SetParent(groupsParent);
			levelsGroup.name = "Group-" + CommonUtilLetter.IntToString(groupIndex + 1);
			levelsGroup.transform.localScale = Vector3.one;
			levelsGroup.GetComponent<RectTransform>().offsetMax = Vector2.zero;
			levelsGroup.GetComponent<RectTransform>().offsetMin = Vector2.zero;
			levelsGroup.GetComponent<Group>().Index = groupIndex;
			levelsGroup.GetComponent<GridLayoutGroup>().constraint = GridLayoutGroup.Constraint.FixedColumnCount;
			levelsGroup.GetComponent<GridLayoutGroup>().constraintCount = columnsPerGroup;
			return levelsGroup;
		}
	}
}