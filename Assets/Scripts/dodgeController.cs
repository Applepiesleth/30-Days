using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dodgeController : MonoBehaviour {
     
    public float speed;
    public float rotate;
    public float move;
    public float size;

    public Sprite spr1;
    public Sprite spr2;
    public Sprite spr3;
    public Sprite spr4;

    SpriteRenderer sr;

    // Use this for initialization
    void Start () {
        transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Random.Range(0, Screen.width), Screen.height, Camera.main.farClipPlane / 2));
        transform.position += new  Vector3(0, 3, 0);
        if (spr1 == spr2)
        {
            speed = Random.Range(8f, 12.0f);
            rotate = Random.Range(-5.0f, 6.0f);
            move = Random.Range(-5f, 5f);
        }
        else
        {
            speed = Random.Range(3.0f, 6.0f);
            rotate = Random.Range(-5.0f, 6.0f);
            move = Random.Range(-2.0f, 3.0f);
        }


        sr = GetComponent<SpriteRenderer>();

        if (gameObject.tag == "scraps")
        {
            size = Random.Range(0.6f, 0.9f);
            transform.localScale = new Vector3(size, size, 0);
        }
        else
        {
            size = Random.Range(0.5f, 0.9f);
            transform.localScale = new Vector3(size, size, 0);
        }

        if (Random.Range(0, 2) == 0)
        {
            if (Random.Range(0, 2) == 0)
            {
                sr.sprite = spr1;
            }
            else
            {
                sr.sprite = spr2;
            }
        }
        else
        {
            if (Random.Range(0, 2) == 0)
            {
                sr.sprite = spr3;
            }
            else
            {
                sr.sprite = spr4;
            }
        }
        
    }
	
	// Update is called once per frame
	void Update () {
        transform.position -= new Vector3(0, speed * Time.deltaTime, 0);

        if (transform.position.y < -7)
        {
            GameObject.Destroy(gameObject);
        }

        transform.Rotate(0, 0, rotate);
        transform.position += new Vector3(move * Time.deltaTime, 0, 0);

        if (Mathf.Abs(transform.position.x) > 9)
        {
            move *= -1;
            transform.position += new Vector3(move * Time.deltaTime * 3, 0, 0);
        }
	}
}