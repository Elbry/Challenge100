using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VideoButtonScript : MonoBehaviour {

	public int boardIndex;
	GameManagerScript gameManager;

	// Use this for initialization
	void Start () {
		gameManager = GameObject.FindObjectOfType<GameManagerScript>();
	}

	public void ShowThisVideo() {
		gameManager.ShowVideo(boardIndex);
		gameManager.recentButton = gameObject;
	}
}
