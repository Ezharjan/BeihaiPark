using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapCamera : MonoBehaviour {

    public GameObject MainPlayer = null;
    public GameObject Mapcamera = null;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Mapcamera.transform.position = new Vector3(MainPlayer.transform.position.x - 0.2f, 91.5f, MainPlayer.transform.position.z - 0.1f);

    }
}
