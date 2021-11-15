using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LightController : MonoBehaviour {

    Camera cam;
    Image img;
    SpriteRenderer sr;

    public Color day;
    public Color night;

    public Sprite sun;
    public Sprite moon;

    gameController gc;

    AudioSource audioS;

    // Use this for initialization
    void Start () {
        gc = GameObject.Find("gameController").GetComponent<gameController>();

        if (GetComponent<Camera>() != null)
        {
            cam = GetComponent<Camera>();
            cam.backgroundColor = night;
        }
        else if (GetComponent<Image>() != null)
        {
            img = GetComponent<Image>();
            img.color = night;
        }
        else
        {
            sr = GetComponent<SpriteRenderer>();
            sr.sprite = moon;
        }

        StartCoroutine("timeLapse");
	}
	
	// Update is called once per frame
	void Update () {
		
        
    }

    IEnumerator timeLapse ()
    {

        yield return new WaitForSeconds(0.5f);

        if (GetComponent<Camera>() != null)
        {
            yield return new WaitForSeconds(1);

            while (!(cam.backgroundColor == day))
            {
                cam.backgroundColor = Color.Lerp(cam.backgroundColor, day, 0.05f);
                yield return null;
            }


        }
        else if (GetComponent<Image>() != null)
        {
            yield return new WaitForSeconds(1);

            while (!(img.color == day))
            {
                img.color = Color.Lerp(img.color, day, 0.05f);
                yield return null;
            }
        }
        else
        {
            while (transform.position.y > -5)
            {
                transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x, -8, 0), 0.02f);
                yield return null;
            }

            sr.sprite = sun;

            while (transform.position.y < 2)
            {
                transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x, 5, 0), 0.02f);
                yield return null;
            }

            gc.gameState = 9;

            yield return new WaitForSeconds(1.5f);

            audioS = GetComponent<AudioSource>();
            audioS.Play();

            gc.daysLeft--;

            yield return new WaitForSeconds(1.5f);


            if (gc.daysLeft > 0)
            {
                SceneManager.LoadScene("Main");
            }
            else
            {
                SceneManager.LoadScene("Story");
            }
        }
    }
}
