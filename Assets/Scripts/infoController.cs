using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class infoController : MonoBehaviour {

    public int item = -1;

    Text txt;

	// Use this for initialization
	void Start () {
        txt = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
		if (item == 0)
        {
            txt.text = "Make the ship take less fuel to fly.";
        }
        if (item == 1)
        {
            txt.text = "Make the ship take even less fuel to fly.";
        }
        if (item == 2)
        {
            txt.text = "Make the ship use barely any fuel at all.";
        }
        if (item == 3)
        {
            txt.text = "Press '1' to not use fuel for a short period of time. Once per launch.";
        }
        if (item == 4)
        {
            txt.text = "Make the ship shoot lasers. that's right. lasers.";
        }
        if (item == 5)
        {
            txt.text = "Lose less fuel from hitting obstacles";
        }
        if (item == 6)
        {
            txt.text = "Create 'fuel points' to refuel the ship.";
        }
        if (item == 7)
        {
            txt.text = "Make the fuel points appear more regularly";
        }
        if (item == 8)
        {
            txt.text = "Stregthen the power of the fuel points";
        }
        if (item == 9)
        {
            txt.text = "Increase the amount of scraps found in space.";
        }
        if (item == 10)
        {
            txt.text = "Press '2' to produce a burst that destroys all obstacles in the screen.";
        }
        if (item == 11)
        {
            txt.text = "Press '3' to make the ship invincible for a short period of time.";
        }
        if (item == 12)
        {
            txt.text = "Increase the speed of the ship.";
        }
        if (item == 13)
        {
            txt.text = "Greatly increase the speed of the ship.";
        }
        if (item == 14)
        {
            txt.text = "Make the ship crazy fast!!";
        }
        if (item == 15)
        {
            txt.text = "Get more scraps from each piece.";
        }
        if (item == 16)
        {
            txt.text = "Increase the amount of lasers being fired.";
        }
        if (item == 17)
        {
            txt.text = "Gives the ship an incredible boost at the beginning.";
        }
    }
}
