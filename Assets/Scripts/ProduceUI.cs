using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProduceUI : MonoBehaviour {

	public UILabel produce;
	public UILabel name;
	public GameObject ui;

	public int num = 0;
	public bool ischange = false;

	public static ProduceUI Instance; //单例模式
	private void Awake()
	{
		Instance = this;
	}


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (ischange == true) {
			ischange = false;
			changeLabel ();
		}
	}
	public void closeProduce(){
		ui.SetActive (false);
	}
	public void changeLabel(){
		switch(num){
		case 1:
			name.text = "永安桥";
			produce.text = "此桥三曲三折孔拱券，桥长85米，宽7,6米，两侧汉白玉望柱48根。";
			ui.SetActive (true);
			break;
		case 2:
			name.text = "白塔";
			produce.text = "位于北海公园琼华岛上。始建于清初顺治八年，几毁几建，是一座藏式喇嘛塔。塔身全部为砖木石混合结构，塔高35.9米，上园下方，富于变化。";
			ui.SetActive (true);
			break;
		default:
			break;
		}

	}
}
