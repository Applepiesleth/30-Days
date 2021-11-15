using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class circleController : MonoBehaviour {

    GameObject p;
    SpriteRenderer sr;
    gameController gc;

    public int circle;
    float size = 1;
    public int speed;

	// Use this for initialization
	void Start () {
        gc = GameObject.Find("gameController").GetComponent<gameController>();
        p = GameObject.Find("Player");
        sr = GetComponent<SpriteRenderer>();

        transform.position = p.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        		
        if (circle == 1)
        {
            if (size < 20)
            {
                size += Time.deltaTime * speed;
                transform.localScale = new Vector3(size, size, 0);
                sr.color += new Color(0, 0, 0, -Time.deltaTime);
            }
            else
            {
                Destroy(gameObject);
            }
        }
        else
        {
            transform.position = p.transform.position;

            if (size < 9)
            {
                size += Time.deltaTime;
            }
            else if (sr.color.a > 0)
            {
                sr.color += new Color(0, 0, 0, -Time.deltaTime);
            }
            else
            {
                gc.specials[2] = 0;
                Destroy(gameObject);
            }
        }
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "dodge")
        {
            if (collision.GetComponent<dodgeController>() != null)
            {
                Destroy(collision.gameObject);
            }
        }
    }
}
