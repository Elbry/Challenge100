using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;

public class GameManagerScript : MonoBehaviour {

	// TO DO: 테스트

	public VideoClip[] video;
	int[] index;
	public GameObject videoPanel;
	int redScore;
	int blueScore;
	public GameObject recentButton;
	public GameObject redScorePanel;
	public GameObject blueScorePanel;
	public AudioSource audioSource;
	public GameObject boardCanvas;

	// Use this for initialization
	void Start () {
		Initialize();
		Randomize();
	}

	public void Initialize() {
		redScore = 0;
		blueScore = 0;
		redScorePanel.GetComponent<Text>().text = redScore.ToString("N0");
		blueScorePanel.GetComponent<Text>().text = blueScore.ToString("N0");

		index = new int[100];
		for(int i = 0; i < 100; i++) {
			index[i] = i;
		}
	}

	public void Randomize() {
		int[] temp = new int[100];
		for(int i = 0; i < 100; i++) {
			int key;
			do {
				key = Random.Range(0, 100);
			} while(temp[key] != 0);
			temp[key] = index[i];
			//Debug.Log("randomizing, temp[" + key + "]: " + temp[key]);
		}
		for(int j = 0; j < 100; j++) {
			index[j] = temp[j];
			//Debug.Log("randomizing, index[" + j + "]: " + index[j]);
		}
	}

	public void ShowVideo(int i) {
		videoPanel.SetActive(true);
		VideoPlayer videoPlayer = videoPanel.GetComponent<VideoPlayer>();
		boardCanvas.SetActive(false);
		Debug.Log("i: " + i);
		Debug.Log("index[i]: " + index[i]);
		videoPlayer.clip = video[index[i]];
		videoPlayer.SetTargetAudioSource(0, audioSource);
		videoPlayer.Play();
	}

	public void CloseApplication() {
		Application.Quit();
	}
	
	void Update () {
		if(videoPanel.activeInHierarchy) {
			// 스페이스 - 일시정지
			if(Input.GetKeyDown(KeyCode.Space) && videoPanel.GetComponent<VideoPlayer>().isPlaying)
				videoPanel.GetComponent<VideoPlayer>().Pause();
			if(Input.GetKeyDown(KeyCode.Space) && !videoPanel.GetComponent<VideoPlayer>().isPlaying)
				videoPanel.GetComponent<VideoPlayer>().Play();
			// esc - 없던 일
			if(Input.GetKeyDown(KeyCode.Escape)) {
				videoPanel.GetComponent<VideoPlayer>().Stop();
				videoPanel.GetComponent<VideoPlayer>().clip = null;
				videoPanel.SetActive(false);
				boardCanvas.SetActive(true);
			}
			// t - 무승부
			if(Input.GetKeyDown(KeyCode.T)) {
				videoPanel.GetComponent<VideoPlayer>().clip = null;
				videoPanel.SetActive(false);
				boardCanvas.SetActive(true);
				recentButton.GetComponent<Button>().image.color = Color.gray;
				recentButton.GetComponent<Button>().interactable = false;
				recentButton = null;
			}
			// r - 레드팀
			if(Input.GetKeyDown(KeyCode.R)) {
				redScore++;
				videoPanel.GetComponent<VideoPlayer>().clip = null;
				videoPanel.SetActive(false);
				boardCanvas.SetActive(true);
				recentButton.GetComponent<Button>().image.color = Color.red;
				recentButton.GetComponent<Button>().interactable = false;
				recentButton = null;
				redScorePanel.GetComponent<Text>().text = redScore.ToString("N0");
			}
			// b - 블루팀
			if(Input.GetKeyDown(KeyCode.B)) {
				blueScore++;
				videoPanel.GetComponent<VideoPlayer>().clip = null;
				videoPanel.SetActive(false);
				boardCanvas.SetActive(true);
				recentButton.GetComponent<Button>().image.color = Color.blue;
				recentButton.GetComponent<Button>().interactable = false;
				recentButton = null;
				blueScorePanel.GetComponent<Text>().text = blueScore.ToString("N0");
			}	
		}
	}

/*
-처음 시작하면 보드 초기화: 승점 제거, 비디오 인덱스 랜더마이즈
-버튼을 누르면 비디오 플레이어 프리펩 생성
-클릭하면 플레이어에서 비디오 클립 찾기
-플레이어에서 비디오 재생
-재생 후 승리팀 설정 화면 제공
-선택하면 승점 업데이트 / 비디오 플레이어 제거 / 보드 업데이트

 */

}
