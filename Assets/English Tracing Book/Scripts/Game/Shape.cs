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

	public class Shape : MonoBehaviour
	{
		/// <summary>
		/// The paths of the shape.
		/// </summary>
		public List<EnglishTracingBook.Path> paths = new List<EnglishTracingBook.Path>();

		/// <summary>
		/// The audio clip of the shape , used for spelling.
		/// </summary>
		public AudioClip clip;

		//0 - 10 seconds : 3 stars
		[Range(0, 500)]
		public int threeStarsTimePeriod = 10;

		//11 -20 seconds : 2 stars
		//more than 20 seconds : one star
		[Range(0, 500)]
		public int twoStarsTimePeriod = 20;

		/// <summary>
		/// Whether the shape is completed or not.
		/// </summary>
		[HideInInspector]
		public bool completed;

		/// <summary>
		/// Whether to enable the priority order or not.
		/// </summary>
		[HideInInspector]
		public bool enablePriorityOrder = true;

		// Use this for initialization
		void Start()
		{
			if (GameManager.compoundShape == null)
			{
				if (paths.Count != 0)
				{
					Invoke("EnableTracingHand", 0.2f);
					ShowPathNumbers(0);
				}
			}
		}

		/// <summary>
		/// Spell the shape.
		/// </summary>
		public void Spell()
		{
			if (clip == null)
			{
				return;
			}

			AudioSourcesLetter.instance.audioSources[1].Stop();
			AudioSourcesLetter.instance.audioSources[1].clip = clip;
			AudioSourcesLetter.instance.audioSources[1].Play();
		}

		/// <summary>
		/// Show the numbers of the path .
		/// </summary>
		/// <param name="index">Index.</param>
		public void ShowPathNumbers(int index)
		{
			for (int i = 0; i < paths.Count; i++)
			{
				if (i != index)
				{
					paths[i].SetNumbersStatus(false);
				}
				else
				{
					paths[i].SetNumbersStatus(true);
				}
			}
		}

		/// <summary>
		/// Get the index of the current path.
		/// </summary>
		/// <returns>The current path index.</returns>
		public int GetCurrentPathIndex()
		{
			int index = -1;
			for (int i = 0; i < paths.Count; i++)
			{

				if (paths[i].completed)
				{
					continue;
				}

				bool isCurrentPath = true;
				for (int j = 0; j < i; j++)
				{
					if (!paths[j].completed)
					{
						isCurrentPath = false;
						break;
					}
				}

				if (isCurrentPath)
				{
					index = i;
					break;
				}
			}

			return index;
		}

		/// <summary>
		/// Determine whether this instance is current path or not.
		/// </summary>
		/// <returns><c>true</c> if this instance is current path; otherwise, <c>false</c>.</returns>
		/// <param name="path">Path.</param>
		public bool IsCurrentPath(EnglishTracingBook.Path path)
		{
			bool isCurrentPath = false;

			if (!enablePriorityOrder)
			{
				return true;
			}

			if (path == null)
			{
				return isCurrentPath;
			}

			isCurrentPath = true;
			for (int i = 0; i < paths.Count; i++)
			{
				if (paths[i].GetInstanceID() == path.GetInstanceID())
				{
					for (int j = 0; j < i; j++)
					{
						if (!paths[j].completed)
						{
							isCurrentPath = false;
							break;
						}
					}
					break;
				}
			}

			return isCurrentPath;
		}

		/// <summary>
		/// Enable the tracing hand.
		/// </summary>
		public void EnableTracingHand()
		{
			int currentPathIndex = GetCurrentPathIndex();
			if (currentPathIndex == -1)
			{
				return;
			}
			Animator animator = GetComponent<Animator>();
			animator.SetTrigger(name);
			animator.SetTrigger(paths[currentPathIndex].name.Replace("Path", name.Split('-')[0]));
		}

		/// <summary>
		/// Disable the tracing hand.
		/// </summary>
		public void DisableTracingHand()
		{
			int currentPathIndex = GetCurrentPathIndex();
			if (currentPathIndex == -1)
			{
				return;
			}
			Animator animator = GetComponent<Animator>();
			//animator.SetBool (name,false);
			animator.SetBool(paths[currentPathIndex].name.Replace("Path", name.Split('-')[0]), false);
		}

		/// <summary>
		/// Get the title of the shape.
		/// </summary>
		/// <returns>The title.</returns>
		public string GetTitle()
		{
			if (GameManager.compoundShape == null)
			{
				return name.Split('-')[0];
			}
			return GameManager.compoundShape.name.Split('-')[0];
		}
	}
}