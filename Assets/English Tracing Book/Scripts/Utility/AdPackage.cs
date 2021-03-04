/*
http://www.cgsoso.com/forum-211-1.html

CG搜搜 Unity3d 每日Unity3d插件免费更新 更有VIP资源！

CGSOSO 主打游戏开发，影视设计等CG资源素材。

插件如若商用，请务必官网购买！

daily assets update for try.

U should buy the asset from home store if u use it in your project!
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
namespace IndieStudio.LetterWrite.Utility
{
	///Developed by Indie Studio
	///https://www.assetstore.unity3d.com/en/#!/publisher/9268
	///www.indiestd.com
	///info@indiestd.com

	[Serializable]
	public class AdPackage
	{
		public bool isEnabled = true;
		public List<AdEvent> adEvents = new List<AdEvent>();
		public Package package;

		[Serializable]
		public class AdEvent
		{
			public Event evt;
			public Type type = Type.BANNER;
			//public GoogleMobileAds.Api.AdPosition adPostion = GoogleMobileAds.Api.AdPosition.Bottom;
			public bool isEnabled = false;

			public enum Event
			{
				ON_LOAD_LOGO_SCENE,
				ON_LOAD_MAIN_SCENE,
				ON_LOAD_LOWERCASE_SCENE,
				ON_LOAD_UPPERCASE_SCENE,
				ON_LOAD_NUMBERS_SCENE,
				ON_LOAD_SCENTENCE_SCENE,
				ON_LOAD_GAME_SCENE,
				ON_SHOW_WIN_DIALOG,
			}

			public enum Type
			{
				BANNER,
				INTERSTITIAL,
				RewardBasedVideo
			}
		}

		public enum Package
		{
			ADMOB,
			CHARTBOOST,
			UNITY
		}

		/// <summary>
		/// Build the ad events.
		/// </summary>
		public void BuildAdEvents()
		{
			Array eventsEnum = Enum.GetValues(typeof(AdEvent.Event));

			if (NeedsToResetAdEventsList(eventsEnum, adEvents))
			{
				adEvents.Clear();
			}

			foreach (AdEvent.Event e in eventsEnum)
			{
				if (!InAdEventsList(adEvents, e))
				{
					adEvents.Add(new AdEvent() { evt = e });
				}
			}
		}

		/// <summary>
		/// Whether the given event in the adEvents list.
		/// </summary>
		/// <returns><c>true</c>, if evt was found, <c>false</c> otherwise.</returns>
		/// <param name="adEvents">Ad events.</param>
		/// <param name="evt">Evt.</param>
		public bool InAdEventsList(List<AdEvent> adEvents, AdEvent.Event evt)
		{
			if (adEvents == null)
			{
				return false;
			}

			foreach (AdEvent adEvent in adEvents)
			{
				if (adEvent.evt == evt)
				{
					return true;
				}
			}
			return false;
		}

		/// <summary>
		/// Whether to reset ad events list or not.
		/// </summary>
		/// <returns><c>true</c>, if reset ad events list was needed, <c>false</c> otherwise.</returns>
		/// <param name="eventsEnum">Events enum.</param>
		/// <param name="adEvents">Ad events.</param>
		public bool NeedsToResetAdEventsList(Array eventsEnum, List<AdEvent> adEvents)
		{
			if (eventsEnum.Length != adEvents.Count)
			{
				return true;
			}

			return false;
		}
	}


}