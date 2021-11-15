using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireController : MonoBehaviour {

    ParticleSystem ps;
    gameController gc;

    AudioSource audioS;

    // Use this for initialization
    void Start () {
        ps = GetComponent<ParticleSystem>();
        gc = GameObject.Find("gameController").GetComponent<gameController>();
        audioS = GetComponent<AudioSource>();
        audioS.Play();
    }
	
	// Update is called once per frame
	void Update () {
        if (gc.gameState == 2 && gc.fuelLeft < 0)
        {

            audioS.Stop();
            ps.Stop();
        }
        else if (gc.fuelInc == 0)
        {
            audioS.Stop();
            ps.Stop();
        }
        else if (!ps.isEmitting)
        {
            audioS.Play();
            ps.Play();
        }
	}
}
