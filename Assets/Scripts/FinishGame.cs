using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishGame : MonoBehaviour {

	public GameObject exitui;
	public GameObject musicUI;

	public AudioSource[] audios;
	public int musicNum = 0;
	public UILabel musicName;

	public UISlider musicSlider;

	public TweenRotation tweenrotation = null;
	private bool isHide = true;

	// Use this for initialization
	void Start () {
		audios [0].Play ();
		musicName.text = audios[0].name;
	}
	
	// Update is called once per frame
	void Update () {
		audios [musicNum].volume = musicSlider.value;
	}

    public void closeGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

	public void openEndUI(){
		exitui.SetActive (true);
	}

	public void closeEndUI(){
		exitui.SetActive (false);

	}
	public void showSettingUI(){
		if (isHide) {
			tweenrotation.PlayForward ();
			isHide = false;
		} else {
			tweenrotation.PlayReverse ();
			isHide = true;
		}
	}

	public void changeView(){
		if (!MainPlayerController.Instance.isFirstView) {
			MainPlayerController.Instance.isFirstView = true;
		} else {
			MainPlayerController.Instance.isFirstView = false;
		}
	}

	public void LeftChangeMusic(){
		if (musicNum > 0) {
			audios[musicNum].Stop();
			musicNum = musicNum - 1;
			audios[musicNum].Play();
			musicName.text = audios[musicNum].name;
		}
	}

	public void RightChangeMusic(){
		if (musicNum < audios.Length - 1) {
			audios[musicNum].Stop();
			musicNum = musicNum + 1;
			audios[musicNum].Play();
			musicName.text = audios[musicNum].name;
		}
	}

	public void closeMusicPanel(){
		musicUI.SetActive (false);
	}

	public void openMusicPanel(){
		musicUI.SetActive (true);
	}
}
