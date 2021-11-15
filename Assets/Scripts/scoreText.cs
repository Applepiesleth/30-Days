using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scoreText : MonoBehaviour {

    gameController gc;

    private Text text;
    public float score;

   public int textID;

	// Use this for initialization
	void Start () {
        text = gameObject.GetComponent<Text>();
        gc = GameObject.Find("gameController").GetComponent<gameController>();
    }
	
	// Update is called once per frame
	void Update () {

        if (textID == 1)
        {
            text.text = "Distance: " + (int)gc.distance + "kly";
        }

        if (textID == 2)
        {
            text.text = "Fuel: " + (int)((gc.fuelLeft / gc.fuelMax) * 100) + "%";
        }

        if (textID == 3)
        {
            text.text = "Scraps: " + gc.scraps;
        }
    }
}
