using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mufoController : MonoBehaviour {

    public float moveSpeed;
    GameObject p;
    public GameObject beam;

    public float cosSpeed;
    float cos;

    // Use this for initialization
    void Start () {
        p = GameObject.Find("Player");
        transform.position = new Vector3(-15, 4, 0);

        StartCoroutine(path());
    }
	
	// Update is called once per frame
	void Update () {

        cos += cosSpeed * Time.deltaTime;

    }

    IEnumerator path ()
    {
        for (var i = 0f; i < 5; i += Time.deltaTime)
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(p.transform.position.x, 4 + Mathf.Cos(cos), 0), moveSpeed);
            yield return null;
        }

        Instantiate(beam, transform);

        for (var i = 0f; i < 5; i += Time.deltaTime)
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(p.transform.position.x, 4 + Mathf.Cos(cos), 0), moveSpeed);
            yield return null;
        }

        for (var i = 0f; i < 2; i += Time.deltaTime)
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(15, 4 + Mathf.Cos(cos), 0), moveSpeed);
            yield return null;
        }

        Destroy(gameObject);
    }
}
