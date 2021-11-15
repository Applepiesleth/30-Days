using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameController : MonoBehaviour {

    public int gameState; // Game States: 0: Before Launch 1: During Launch 2: After Launch 3: Shop 4: Chosing next opt 5: Shop Again 6: Research 7: Mine 8: Second Options Done 9: Done timelapse

    public float distance;
    public float distInc;

    public float fuelMax;
    public float fuelLeft;
    public float fuelInc;

    public GameObject tree;
    public GameObject refuel;
    public GameObject scrap;
    public GameObject ufo;
    public GameObject mufo;
    public GameObject sun;
    public GameObject gamma;
    public GameObject temp;
    public GameObject splashText; 

    public float treeTime;
    public float treeCounter;
    public float refuelTime;
    public float refuelCounter;
    public float scrapTime;
    public float scrapCounter;
    public float ufoTime;
    public float ufoCounter;

    public float laserTime;

    public List<int> specials;

    public int scraps;
    public List<int> shopData;
    public bool shopped = false;

    public float secondTime;
    public float secondCounter;

    public int timesResearched;

    public int daysLeft;
    public bool win;

    AudioSource audioS;

    public AudioClip launchM;
    public AudioClip elseM;

    private static bool exists;

	// Use this for initialization
	void Start () {

        if (!exists) // keeps gamecontroller between scenes
        {
            exists = true;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        daysLeft = 30;
        audioS = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {

        /////////////////////////////// Shop //////////////////////////

        if (gameState == 3)
        {
            audioS.clip = elseM;
            if (!audioS.isPlaying)
                audioS.Play();
        }

        /////////////////////////////// After launch //////////////////////////

        else if (gameState == 1) 
        {

            if (shopData[17] == 3 && distance < 500)
            {
                distance += distInc * Time.deltaTime * 10;
            }
            else
            {
                distance += distInc * Time.deltaTime;
            }

            if (distance < 2200 || distance > 2600)
            {
                fuelLeft -= Time.deltaTime * fuelInc;
            }
            else
            {
                fuelLeft -= Time.deltaTime * 3 * fuelInc;
            }
            treeCounter -= Time.deltaTime;
            refuelCounter -= Time.deltaTime;
            scrapCounter -= Time.deltaTime;
            ufoCounter -= Time.deltaTime;

            if (scrapCounter < 0)
            {
                Instantiate(scrap, gameObject.transform.position, gameObject.transform.rotation);
                if (shopData[9] == 3 && Random.Range(0,3) == 1)
                {
                    Instantiate(scrap, gameObject.transform.position, gameObject.transform.rotation);
                }

                scrapCounter = scrapTime + Random.Range(0f, 0.5f); ;
            }

            if (treeCounter < 0)
            {
                Instantiate(tree, gameObject.transform.position, gameObject.transform.rotation);
                if (distance > 500 && distance < 700)
                {
                    treeCounter = 0.08f + Random.Range(0f, 0.03f);
                }
                else
                {
                    treeCounter = treeTime + Random.Range(0f, 0.5f);
                }
            }

            if (shopData[6] == 3 && refuelCounter < 0)
            {
                Instantiate(refuel, gameObject.transform.position, gameObject.transform.rotation);
                refuelCounter = refuelTime;
            }

            if (ufoCounter < 0 && distance > 1250 && distance < 1650)
            {
                Instantiate(ufo, gameObject.transform.position, gameObject.transform.rotation);
                ufoCounter = ufoTime;
            }

            if (ufoCounter < 0 && distance > 2200 && distance < 2600)
            {
                Instantiate(sun, gameObject.transform.position, gameObject.transform.rotation);
                ufoCounter = ufoTime / 3;
            }

            if (fuelLeft <= 0 || distance > 3000 )
            {
                if (distance > 3000)
                {
                    win = true;
                }
                else
                {
                    win = false;
                }
                StopCoroutine(launchEvents());
                audioS.Stop();
                gameState = 2;
            }

            if (Input.GetKeyDown(KeyCode.Alpha1) && specials[0] == 1)
            {
                StartCoroutine(ion());
                specials[0] = 0;
            }

            if (Input.GetKeyDown(KeyCode.Alpha2) && specials[1] == 1)
            {
                Instantiate(gamma, transform);
                specials[1] = 0;
            }

            if (Input.GetKeyDown(KeyCode.Alpha3) && specials[2] == 1)
            {
                Instantiate(temp, transform);
                specials[2] = 2;
            }
        }

        /////////////////////////////// After Destroyed //////////////////////////

        else if (gameState == 2)
        {
            secondCounter = secondTime;
        }

        /////////////////////////////// Second Thing //////////////////////////

        else if (gameState == 6 || gameState == 7)
        {
            secondCounter -= Time.deltaTime;

            if (secondCounter <= 0)
            {
                if (gameState == 6) // Research Stuff
                {
                    if (timesResearched == 0)
                    {
                        shopData[1] = 6;
                        shopData[4] = 6;
                        shopData[5] = 6;
                    }
                    else if (timesResearched == 1)
                    {
                        shopData[7] = 6;
                        shopData[9] = 6;
                        shopData[10] = 6;
                    }
                    else if (timesResearched == 2)
                    {
                        shopData[11] = 6;
                        shopData[13] = 6;
                    }
                    else if (timesResearched == 3)
                    {
                        shopData[3] = 6;
                        shopData[15] = 6;
                        shopData[8] = 6;
                    }
                    else if (timesResearched == 4)
                    {
                        shopData[2] = 6;
                        shopData[16] = 6;
                    }
                    else if (timesResearched == 5)
                    {
                        shopData[14] = 6;
                        shopData[17] = 6;
                    }

                    timesResearched++;
                }
                else // Mine Stuff
                {
                    scraps += Random.Range(50, 150);
                }

                gameState = 8;
            }
        }

        /////////////////////////////// Second Thing //////////////////////////

        if (gameState == 14)
        {
            audioS.Stop();
        }

    }

    IEnumerator ion ()
    {
        fuelInc = 0;

        yield return new WaitForSeconds(10f);

        fuelInc = 1;
    }

    public IEnumerator beginLaunch() /////////////// Prepare Game ////////////////////
    {
        audioS.Stop();
        gameState = 0;
        distance = 0;

        if (shopData[2] == 3) //setting up fuel efficiency
        {
            fuelMax = 160;
        }
        else if (shopData[1] == 3)
        {
            fuelMax = 120;
        }
        else if (shopData[0] == 3)
        {
            fuelMax = 80;
        }
        else
        {
            fuelMax = 25;
        }

        if (shopData[7] == 3) //setting up refuels
        {
            refuelTime = 7;
        }
        else
        {
            refuelTime = 11;
        }

        if (shopData[14] == 3) //setting speed
        {
            distInc = 17;
        }
        else if (shopData[13] == 3)
        {
            distInc = 14;
        }
        else if (shopData[12] == 3)
        {
            distInc = 11;
        }
        else
        {
            distInc = 8;
        }

        if (shopData[16] == 3) //setting lasers
        {
            laserTime = 0.25f;
        }
        else
        {
            laserTime = 0.5f;
        }

        if (shopData[3] == 3)
        {
            specials[0] = 1;
        }
        if (shopData[10] == 3)
        {
            specials[1] = 1;
        }
        if (shopData[11] == 3)
        {
            specials[2] = 1;
        }

        fuelLeft = fuelMax;
        treeCounter = treeTime;
        refuelCounter = refuelTime;
        scrapCounter = scrapTime;
        ufoCounter = ufoTime;

        yield return new WaitForSeconds(0.5f);

        splashText = GameObject.Find("SplashText");
        splashText.GetComponent<splashText>().StartCoroutine("countDown");   
        
    }

    public IEnumerator launchEvents () // show the words on screen
    {
        audioS.clip = launchM;
        audioS.Play();

        scrapTime = 1;

        while (distance < 500)
        {
            yield return null;
        }

        scrapTime = 0.1f;
        splashText.GetComponent<splashText>().splash("asteroid belt! \r\n destroy em'!");  
        
        while (distance < 800)
        {
            yield return null;
        }

        scrapTime = 0.8f;

        while (distance < 1250)
        {
            yield return null;
        }

        splashText.GetComponent<splashText>().splash("aliens!");

        while (distance < 1400)
        {
            yield return null;
        }

        splashText.GetComponent<splashText>().splash("mothership! \r\n protect yourself!");
        Instantiate(mufo, gameObject.transform.position, gameObject.transform.rotation);
        scrapTime = 0.1f;

        while (distance < 1650)
        {
            yield return null;
        }

        scrapTime = 0.7f;

        while (distance < 2200)
        {
            yield return null;
        }

        scrapTime = 0.3f;

        splashText.GetComponent<splashText>().splash("Solar Flare! \r\n (Increased Fuel Loss)");

        while (distance < 2600)
        {
            yield return null;
        }

        scrapTime = 0.8f;

        
    }

}
