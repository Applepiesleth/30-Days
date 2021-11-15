using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class secondController : MonoBehaviour {

    gameController gc;

    int hi = 0;

    Image img;
    public Sprite research;
    public Sprite mine;

    RectTransform rt;
    public float rotateSpeed;

    AudioSource audioS;


    // Use this for initialization
    void Start () {
        gc = GameObject.Find("gameController").GetComponent<gameController>();
        img = GetComponent<Image>();
        rt = GetComponent<RectTransform>();
        audioS = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
		
        if (gc.gameState == 6)
        {
            img.sprite = research;
            rt.Rotate(0, -rotateSpeed * Time.deltaTime, 0);
            img.enabled = true;
            hi = 1;
        }
        else if (gc.gameState == 7)
        {
            img.sprite = mine;
            rt.Rotate(0, rotateSpeed * Time.deltaTime, 0);
            img.enabled = true;
            hi = 1;
        }
        else
        {
            rt.rotation = Quaternion.Euler(0, 0, 0);
            img.enabled = false;

            if (hi == 1)
            {
                hi = 0;
                audioS.Play();
            }
        }
	}
}
