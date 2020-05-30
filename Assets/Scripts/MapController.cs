using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapController : MonoBehaviour {

    // Use this for initialization

    public GameObject mainPlayer = null;
    public UISprite jiantou = null;
    public UISprite circle = null;
    private float time = 0;
    
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        jiantou.transform.eulerAngles = new Vector3(0 , 0 , - (mainPlayer.transform.eulerAngles.y - 180));
        if(time < 2)
        {
            time += Time.deltaTime;
            circle.transform.localScale = new Vector3(time * 20, time * 20, time * 20);
            circle.alpha = 1 - time * 0.5f;
        }
        else
        {
            time = 0;
        }
    }
}
