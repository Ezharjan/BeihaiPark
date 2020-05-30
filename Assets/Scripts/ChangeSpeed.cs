using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSpeed : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Plus) || Input.GetKeyDown (KeyCode.Equals)) {
			AddSpeed ();
		} else if (Input.GetKeyDown (KeyCode.Minus)) {
			ReduceSpeed ();
		}
	}

    public void AddSpeed()
    {
        if(MainPlayerController.Instance.navAgent.speed < 5)
        {
            MainPlayerController.Instance.navAgent.speed += 0.5f;
        }

    }

    public void ReduceSpeed()
    {
        if (MainPlayerController.Instance.navAgent.speed > 1)
        {
            MainPlayerController.Instance.navAgent.speed -= 0.5f;
        }
    }
}
