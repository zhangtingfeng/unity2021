using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class jumpTest : MonoBehaviour {

	// Use this for initialization
	void Start () {
		///测试跳转场景
		///

		DestroyObject(GameObject.Find("[DOTween]"));
		SceneManager.LoadScene("MainScene");

	}

	// Update is called once per frame
	void Update () {
		
	}
}
