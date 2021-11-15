using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class beamController : MonoBehaviour {

    GameObject mufo;

	// Use this for initialization
	void Start () {
        mufo = GameObject.FindGameObjectWithTag("mufo");
        transform.localScale = new Vector3(0, 1, 1);

        StartCoroutine(beam());
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = mufo.transform.position;
	}

    IEnumerator beam ()
    {
        while (transform.localScale.x < 1)
        {
            transform.localScale += new Vector3(Time.deltaTime * 2, 0, 0);
            yield return null;
        }

        yield return new WaitForSeconds(1f);

        while (transform.localScale.x > 0)
        {
            transform.localScale += new Vector3(-Time.deltaTime * 2, 0, 0);
            yield return null;
        }

        Destroy(gameObject);
    }
}
