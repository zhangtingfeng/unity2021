using UnityEngine;
using System.Collections;
using UnityEngine.Analytics;

public enum AdType
{
	AdmobInterstitial,
	ChartboostInterstitial,
	UnityAdsVideo
}

[System.Serializable]
public class AdEvents
{
	public GameStateGarden gameEvent;
	public AdType adType;
	public int everyLevel;
	//1.6
	public int calls;

}