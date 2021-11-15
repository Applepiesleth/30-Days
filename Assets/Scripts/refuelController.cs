using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class refuelController : MonoBehaviour {

    SpriteRenderer sr;

    public float lifeSpan;
    public float life;

	// Use this for initialization
	void Start () {
        sr = gameObject.GetComponent<SpriteRenderer>();
        sr.color = new Color(1, 1, 1, 0);
        transform.localScale = new Vector3(3, 3, 1);
        transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Random.Range(0, Screen.width), Random.Range(0, Screen.height), Camera.main.farClipPlane / 2));

        life = lifeSpan;
	}
	
	// Update is called once per frame
	void Update () {
		if (sr.color.a < 0.8 && life > 0)
        {
            sr.color += new Color(0, 0, 0, Time.deltaTime);
        }
        if (transform.localScale.x > 1)
        {
            transform.localScale -= new Vector3(Time.deltaTime * 3, Time.deltaTime * 3, 0);
        }

        life -= Time.deltaTime;

        if (life <= 0)
        {
            sr.color += new Color(0, 0, 0, -Time.deltaTime);

            if (sr.color.a < 0)
            {
                Destroy(gameObject);
            }
        }

        transform.Rotate(0, 0, 50 * Time.deltaTime);
    }
}
