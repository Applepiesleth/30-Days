using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class storyController : MonoBehaviour {

    gameController gc;

    SpriteRenderer sr;

    public Sprite spr1;
    public Sprite spr2;
    public Sprite spr3;
    public Sprite spr4;

    // Use this for initialization
    void Start () {
        gc = GameObject.Find("gameController").GetComponent<gameController>();
        sr = GetComponent<SpriteRenderer>();
        gc.gameState = 14;
    }
	
	// Update is called once per frame
	void Update () {
        if (gc.daysLeft == 30)
        {
            sr.sprite = spr1;
        }
        else if (gc.daysLeft == 0)
        {
            sr.sprite = spr2;
        }
        else
        {
            if (gc.win == true)
            {
                sr.sprite = spr3;
            }
            else
            {
                sr.sprite = spr4;
            }
        }
    }
}
