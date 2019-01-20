using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioText : MonoBehaviour {

	// Use this for initialization
	void Start () {

    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.S)) {
            AudioManager.Instace.Play("Magic_Light");
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            AudioManager.Instace.Stop("Magic_Light");
        }
    }
}
