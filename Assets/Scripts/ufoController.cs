using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ufoController : MonoBehaviour {

    public float speed;
    float dir;
    public float cosSpeed;
    float cos;
    float size;

	// Use this for initialization
	void Start () {
        dir = Random.Range(0, 2);
        speed = Random.Range(2.5f, 4.5f);

        if (dir == 0)
        {
            transform.position = new Vector3(-15, Random.Range(-5.0f,5.0f), 0);
        }
        else
        {
            transform.position = new Vector3(15, Random.Range(-5.0f, 5.0f), 0);
        }

        transform.Translate(0, 0, 10);
        size = Random.Range(0.5f, 0.7f);
        transform.localScale = new Vector3(size, size, 0);
    }
	
	// Update is called once per frame
	void Update () {

        cos += cosSpeed * Time.deltaTime;

        if (dir == 0)
        {
            transform.Translate(new Vector3(speed * Time.deltaTime, Mathf.Cos(cos) * Time.deltaTime, 0));

            if (transform.position.x > 15)
            {
                Destroy(gameObject);
            }
        }
        else
        {
            transform.Translate(new Vector3(-speed * Time.deltaTime, Mathf.Cos(cos) * Time.deltaTime, 0)); 

            if (transform.position.x < -15)
            {
                Destroy(gameObject);
            }
        }
	}
}
