using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartButton : MonoBehaviour {

	// Use this for initialization
	void Start () {
		StartCoroutine(Wait(30f));///延时启动   delay time to start it 
	}

	IEnumerator Wait(float t) {
		yield return new WaitForSeconds(t);


		Debug.Log("Start Game");
		UIManager.Instance.HideBox(UIBoxType.MainPageBox);
		UIManager.Instance.ShowBox(UIBoxType.GameBox);
		UIManager.Instance.ShowBox(UIBoxType.GameUIBox);

		BubbleManager.Instance.InitGame();
		BubbleManager.Instance.isCanClick = true;

		AudioManager.Instance.ButtonClick();
	}


	// Update is called once per frame
	void Update () {
		
	}
}
