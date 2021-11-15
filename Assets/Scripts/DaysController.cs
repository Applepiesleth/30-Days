using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DaysController : MonoBehaviour {

    Text txt;
    Image img;

    gameController gc;

	// Use this for initialization
	void Start () {
        gc = GameObject.Find("gameController").GetComponent<gameController>();
        
        if (GetComponent<Text>() != null)
        {
            txt = GetComponent<Text>();
            txt.color = new Color(1, 1, 1, 0);
        }
        else
        {
            img = GetComponent<Image>();

            if (name != "darken")
            {
                img.color = new Color(1, 1, 1, 0);
            }
        }
	}
	
	// Update is called once per frame
	void Update () {
        if (name == "DaysNum")
        {
            txt.text = "" + gc.daysLeft;
        }

        if (gc.gameState == 9)
        {
            if (GetComponent<Text>() != null && txt.color.a < 1)
            {
                txt.color += new Color(0, 0, 0, Time.deltaTime);
            }
            else if (name == "darken" && img.color.a < 0.8f)
            {
                img.color += new Color(0, 0, 0, Time.deltaTime);
            }
            else if (name == "darken" && img.color.a < 1)
            {
                img.color += new Color(0, 0, 0, Time.deltaTime);
            }
        }
	}
}
