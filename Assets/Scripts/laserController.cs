using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class laserController : MonoBehaviour {

    public float speed;
    public GameObject ps;

	// Use this for initialization
	void Start () {
        transform.Translate(new Vector3(0, 0.5f, 0));
	}
	
	// Update is called once per frame
	void Update () {
        transform.position += new Vector3(0, speed * Time.deltaTime, 0);

        if (transform.position.y > 7)
        {
            Destroy(gameObject);
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "dodge")
        {
            if (collision.GetComponent<dodgeController>() != null)
            {
                Instantiate(ps, transform.position, transform.rotation);
                Destroy(collision.gameObject);
            }
            Destroy(gameObject);
        }
    }
}
