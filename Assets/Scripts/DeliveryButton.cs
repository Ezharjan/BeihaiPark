using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeliveryButton : MonoBehaviour {

    // Use this for initialization

    public GameObject MainPlayer = null;
    public Vector3 Pos = new Vector3(0, 0, 0);
	public bool startchange = false;
	public UISprite change;
	public float time = 0f;
    
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (startchange) {
			change.alpha = 1;
			startchange = false;
		}
		if (change.alpha > 0) {
			change.alpha -= 0.01f;
		}
	}

    public void onclick()
    {
		startchange = true;
        //MainPlayer.transform.position = Pos;
        MainPlayerController.Instance.hitInfo.point = Pos;
        MainPlayerController.Instance.isMoving = true;
        //MainPlayer.transform.position = Pos;
		MainPlayerController.Instance.navAgent.Warp(Pos);
    }
}
