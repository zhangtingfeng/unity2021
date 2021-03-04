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

	public class AudioSourcesLetter : MonoBehaviour
	{

		/// <summary>
		/// This Gameobject defined as a Singleton.
		/// </summary>
		public static AudioSourcesLetter instance;

		/// <summary>
		/// The audio sources references.
		/// First Audio Souce used for the music
		/// Second Audio Souce used for the sound effects
		/// </summary>
		[HideInInspector]
		public AudioSource[] audioSources;

		/// <summary>
		/// The bubble sound effect.
		/// </summary>
		public AudioClip bubbleSFX;

		// Use this for initialization
		void Awake()
		{
			if (instance == null)
			{
				instance = this;
				audioSources = GetComponents<AudioSource>();
				DontDestroyOnLoad(gameObject);
			}
			else
			{
				Destroy(gameObject);
			}
		}

		public void PlayBubbleSFX()
		{
			if (bubbleSFX != null && audioSources[1] != null)
			{
				CommonUtilLetter.PlayOneShotClipAt(bubbleSFX, Vector3.zero, audioSources[1].volume);
			}

		}
	}
}