using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class MainAutoJump : UIBoxBase {

	public Image SoundImage;

	// Use this for initialization
	void Start () {

		StartCoroutine(OnStartGameClick(1f));///延时启动   delay time to start it 
		//OnStartGameClick();

	}



	IEnumerator OnStartGameClick(float t)
	{

		yield return new WaitForSeconds(t);
		/////测试跳转场景
		//SceneManager.LoadScene("JumpTest");

		//return;
		Debug.Log("Start Game");
		UIManager.Instance.HideBox(UIBoxType.MainPageBox);
		UIManager.Instance.ShowBox(UIBoxType.GameBox);
		UIManager.Instance.ShowBox(UIBoxType.GameUIBox);

		BubbleManager.Instance.InitGame();
		BubbleManager.Instance.isCanClick = true;

		AudioManager.Instance.ButtonClick();
	}

}
