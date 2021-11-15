using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class lanchController : MonoBehaviour {

    gameController gc;

    Image img;
    Text txt;

	// Use this for initialization
	void Start () {
        gc = GameObject.Find("gameController").GetComponent<gameController>();
        if (GetComponent<Image>() != null)
        {
            img = GetComponent<Image>();
            img.enabled = false;
        }
        if (GetComponent<Text>() != null)
        {
            txt = GetComponent<Text>();
            txt.enabled = false;
        }
    }
	
	// Update is called once per frame
	void Update () {
		if (gc.gameState == 1)
        {
            if (GetComponent<SpriteRenderer>() != null)
            {
                transform.position = Vector3.Lerp(transform.position, new Vector3(2.3f, -93.5f, 0), 0.005f);
            }
            else
            {
                if (GetComponent<Image>() != null)
                {
                    img.enabled = true;
                }
                if (GetComponent<Text>() != null)
                {
                    txt.enabled = true;
                }
            }
        }
	}
}