using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderPos : MonoBehaviour {

	public int num = 0;
	public GameObject produceui;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider collider) {
		if(collider.tag == "Player"){
			Debug.Log(num);
		}
		this.gameObject.SetActive (false);
		produceui.SetActive (true);
		ProduceUI.Instance.num = num;
		ProduceUI.Instance.ischange = true;
	}

	void OnTriggerStay(Collider collider) {
		if(collider.tag == "Player"){
			Debug.Log(num);
		}
		this.gameObject.SetActive (false);
		produceui.SetActive (true);
		ProduceUI.Instance.num = num;
		ProduceUI.Instance.ischange = true;
	}
}
