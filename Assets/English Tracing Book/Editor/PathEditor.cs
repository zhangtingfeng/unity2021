/*
http://www.cgsoso.com/forum-211-1.html

CG搜搜 Unity3d 每日Unity3d插件免费更新 更有VIP资源！

CGSOSO 主打游戏开发，影视设计等CG资源素材。

插件如若商用，请务必官网购买！

daily assets update for try.

U should buy the asset from home store if u use it in your project!
*/

using UnityEngine;
using UnityEditor;
using System.Collections;
namespace IndieStudio.LetterWrite.Utility
{

	///Developed by Indie Studio
	///https://www.assetstore.unity3d.com/en/#!/publisher/9268
	///www.indiestd.com
	///info@indiestd.com

	[CustomEditor(typeof(EnglishTracingBook.Path))]
	public class PathEditor : Editor
	{

		public override void OnInspectorGUI()
		{
			EnglishTracingBook.Path path = (EnglishTracingBook.Path)target;//get the target

			EditorGUILayout.Separator();
			path.fillMethod = (EnglishTracingBook.Path.FillMethod)EditorGUILayout.EnumPopup("Fill Method", path.fillMethod);
			if (path.fillMethod == EnglishTracingBook.Path.FillMethod.Linear)
			{
				path.type = (EnglishTracingBook.Path.ShapeType)EditorGUILayout.EnumPopup("Type", path.type);
				path.offset = EditorGUILayout.Slider("Angle Offset", path.offset, -360, 360);
				path.flip = EditorGUILayout.Toggle("Flip Direction", path.flip);
			}
			else if (path.fillMethod == EnglishTracingBook.Path.FillMethod.Radial)
			{
				path.quarterRestriction = EditorGUILayout.Toggle("Quarter Restriction", path.quarterRestriction);
				path.radialAngleOffset = EditorGUILayout.Slider("Radial Offset", path.radialAngleOffset, -360, 360);
			}

			path.completeOffset = EditorGUILayout.Slider("Complete Offset", path.completeOffset, 0, 1);
			path.firstNumber = EditorGUILayout.ObjectField("First Number", path.firstNumber, typeof(Transform)) as Transform;
			if (path.fillMethod != EnglishTracingBook.Path.FillMethod.Point)
				path.secondNumber = EditorGUILayout.ObjectField("Second Number", path.secondNumber, typeof(Transform)) as Transform;

		}
	}
}