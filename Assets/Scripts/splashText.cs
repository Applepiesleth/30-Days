using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class splashText : MonoBehaviour {

    gameController gc;

    private Text text;
    public string words = "";

    AudioSource audioS;
    public AudioClip beepM;
    public AudioClip launchM;
    public AudioClip evM;

    // Use this for initialization
    void Start () {

        gc = GameObject.Find("gameController").GetComponent<gameController>();
        text = gameObject.GetComponent<Text>();
        audioS = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
        text.text = words;
    }

    public IEnumerator countDown () //countdown before launch
    {

        yield return new WaitForSeconds(1f);

        audioS.clip = beepM;
        audioS.Play();

        words = "3";

        yield return new WaitForSeconds(1f);

        audioS.clip = beepM;
        audioS.Play();

        words = "2";

        yield return new WaitForSeconds(1f);

        audioS.clip = beepM;
        audioS.Play();

        words = "1";

        yield return new WaitForSeconds(1f);

        audioS.clip = launchM;
        audioS.Play();

        words = "BLAST OFF!";
        gc.gameState = 1;

        gc.StartCoroutine("launchEvents");

        yield return new WaitForSeconds(1f);

        words = "";
    }

    public void splash (string text)
    {
        StartCoroutine(splashy(text));
    }

    public IEnumerator splashy (string text)
    {
        audioS.clip = evM;
        audioS.Play();

        words = text;
        yield return new WaitForSeconds(1.5f);
        words = "";
    }
}
