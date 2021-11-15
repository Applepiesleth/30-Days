using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class fuelController : MonoBehaviour {

    RectTransform rect;
    public float maxHeight;
    public float ratio;

    gameController gc;

	// Use this for initialization
	void Start () {
        rect = gameObject.GetComponent<RectTransform>();
        maxHeight = Screen.height;
        gc = GameObject.Find("gameController").GetComponent<gameController>();

    }
	
	// Update is called once per frame
	void Update () {
        gc = GameObject.Find("gameController").GetComponent<gameController>();
        ratio = gc.fuelLeft / gc.fuelMax;
        rect.offsetMax = new Vector2(0, -maxHeight + maxHeight * ratio);
        maxHeight = Screen.height;
    }
}
