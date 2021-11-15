using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class tutorialController : MonoBehaviour {

    Image sr;
    gameController gc;

    // Use this for initialization
    void Start () {
        gc = GameObject.Find("gameController").GetComponent<gameController>();
        sr = GetComponent<Image>();

        if (gc.daysLeft == 30)
        {
            sr.enabled = true;
        }
        else
        {
            sr.enabled = false;
        }
    }
	
	// Update is called once per frame
	void Update () {

	}
}
