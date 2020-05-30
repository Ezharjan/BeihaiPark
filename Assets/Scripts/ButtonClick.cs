using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonClick : MonoBehaviour {

    public TweenPosition Tween = null;
    private bool ishide = false;
    public UISprite HideButton = null;
    public UISprite ShowButton = null;

	// Use this for initialization
	void Start () {

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void hideMenu()
    {
        Tween.PlayForward();
        ishide = true;
    }

    public void showMenu()
    {
        Tween.PlayReverse();
        ishide = false;
    }

    public void finishHide()
    {
        if(HideButton.enabled == true)
        {
            HideButton.enabled = false;
            ShowButton.enabled = true;
        }
        else if(HideButton.enabled == false)
        {
            HideButton.enabled = true;
            ShowButton.enabled = false;
        }
        
    }
}
