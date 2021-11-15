using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class specialController : MonoBehaviour {

    gameController gc;

    public int specialID;

    Image img;
    public Sprite on;
    public Sprite off;

	// Use this for initialization
	void Start () {
        gc = GameObject.Find("gameController").GetComponent<gameController>();
        img = GetComponent<Image>();
	}
	
	// Update is called once per frame
	void Update () {
		
        if (specialID == 0)
        {
            if (gc.shopData[3] == 3)
            {
                img.color = new Color(1, 1, 1, 0.2f);
            }
            else
            {
                img.color = new Color(1, 1, 1, 0);
            }

            if (gc.specials[0] == 1)
            {
                img.sprite = on;
            }
            else
            {
                img.sprite = off;
            }
        }

        if (specialID == 1)
        {
            if (gc.shopData[10] == 3)
            {
                img.color = new Color(1, 1, 1, 0.2f);
            }
            else
            {
                img.color = new Color(1, 1, 1, 0);
            }

            if (gc.specials[1] == 1)
            {
                img.sprite = on;
            }
            else
            {
                img.sprite = off;
            }
        }

        if (specialID == 2)
        {
            if (gc.shopData[11] == 3)
            {
                img.color = new Color(1, 1, 1, 0.2f);
            }
            else
            {
                img.color = new Color(1, 1, 1, 0);
            }

            if (gc.specials[2] == 1)
            {
                img.sprite = on;
            }
            else
            {
                img.sprite = off;
            }
        }
    }
}
