using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerConbtroller : MonoBehaviour {

    gameController gc;

    public float moveSpeed;
    Vector3 targetPosition;

    public GameObject laser;
    float laserCounter;

    public float refuelNum;

    BoxCollider2D bc;

    public GameObject ps;

    AudioSource audioS;
    public AudioClip scrapM;
    public AudioClip hitM;

    // Use this for initialization
    void Start () {
        transform.position = new Vector3(0, -2, 0);
        bc = GetComponent<BoxCollider2D>();
        gc = GameObject.Find("gameController").GetComponent<gameController>();
        audioS = GetComponent<AudioSource>();

    }
	
	// Update is called once per frame
	void Update () {

        if (gc.gameState == 1) //when ship has been launched...
        {
            if (Input.mousePosition.x > -1 && Input.mousePosition.x < Screen.width + 1 && Input.mousePosition.y > -1 && Input.mousePosition.y < Screen.height + 1) //movement
            {
                targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            }
            targetPosition.z = 0;
            transform.position = Vector3.Lerp(transform.position, targetPosition, moveSpeed);

            if (gc.shopData[4] == 3)
            {
                if (laserCounter <= 0)
                {
                    Instantiate(laser, transform.position, transform.rotation);
                    laserCounter = gc.laserTime;
                }

                laserCounter -= Time.deltaTime;
            }
        }
        if (gc.gameState == 2 && gc.fuelLeft < 0)
        {
            transform.Rotate(0, 0, 20 * Time.deltaTime);
            transform.Translate(Time.deltaTime, Time.deltaTime, 0);
        }
    }

    private void OnTriggerStay2D (Collider2D collision)
    {
        if (collision.gameObject.tag == "refuel" && gc.fuelLeft < gc.fuelMax)
        {
            if (gc.shopData[8] == 3)
            {
                gc.fuelLeft += Time.deltaTime * refuelNum * 1.3f;
            }
            else
            {
                gc.fuelLeft += Time.deltaTime * refuelNum * 1.15f;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (gc.gameState == 1)
        {

            if ((collision.gameObject.tag == "dodge" || collision.gameObject.tag == "mufo") && gc.specials[2] != 2)
            {

                if (collision.GetComponent<beamController>() != null)
                {
                    gc.fuelLeft -= 16;
                }
                else if (gc.shopData[5] == 3)
                {
                    gc.fuelLeft -= 6;
                }
                else
                {
                    gc.fuelLeft -= 10;
                }

                if (collision.GetComponent<mufoController>() == null && collision.GetComponent<beamController>() == null)
                {
                    Instantiate(ps, transform);
                    Destroy(collision.gameObject);
                }

                audioS.clip = hitM;
                audioS.Play();
            }

            if (collision.gameObject.tag == "scraps")
            {
                if (gc.shopData[15] == 3)
                {
                    gc.scraps += Random.Range(8, 12);
                }
                else
                {
                    gc.scraps += Random.Range(4, 8);
                }
                audioS.clip = scrapM;
                audioS.Play();

                Destroy(collision.gameObject);
            }

        }
    }
}
