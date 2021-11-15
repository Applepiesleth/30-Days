using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class startButton : MonoBehaviour
    , IPointerClickHandler
    , IPointerEnterHandler
    , IPointerExitHandler
{
    gameController gc;
    GameObject tc;

    public int buttonID;
    Image img;
    Text txt;

    public Sprite spr1;
    public Sprite spr2;

    public RectTransform rt;
    public float bigSize;
    bool mouseOver = false;

    AudioSource audioS;
    public AudioClip clickM;

    // Use this for initialization
    void Start () {
        gc = GameObject.Find("gameController").GetComponent<gameController>();
        if (GetComponent<Image>() != null)
            img = GetComponent<Image>();
        if (GetComponent<Text>() != null)
            txt = GetComponent<Text>();
        rt = GetComponent<RectTransform>();
        tc = GameObject.Find("Tutorial");
        audioS = GetComponent<AudioSource>();

        if (buttonID == 8 && gc.daysLeft == 0)
        {
            img.enabled = false;
        }
    }
	
	// Update is called once per frame
	void Update () {
        if (buttonID == 2)
        {
            if (gc.gameState == 2)
            {
                if (GetComponent<Image>() != null)
                    img.enabled = true;
                if (GetComponent<Text>() != null)
                    txt.enabled = true;
            }
            else
            {
                if (GetComponent<Image>() != null)
                    img.enabled = false;
                if (GetComponent<Text>() != null)
                    txt.enabled = false;
            }
        }

        else if (buttonID == 3)
        {
            if (gc.gameState == 8 || gc.gameState == 5)
            {
                img.sprite = spr2;
            }
            else
            {
                img.sprite = spr1;
            }
        }

        else if (buttonID == 4)
        {
            if (gc.gameState == 4 || (gc.gameState == 6 && gc.gameState == 7  && name == "darken"))
            {
                if (GetComponent<Image>() != null)
                {
                    if (name == "Research" && gc.timesResearched == 6)
                        img.enabled = false;
                    else
                        img.enabled = true;
                }
            }
            else
            {
                if (GetComponent<Image>() != null)
                    img.enabled = false;
            }
        }

        else if (buttonID == 5)
        {
            if (gc.gameState == 8)
            {
                    img.enabled = true;
            }
            else
            {
                    img.enabled = false;
            }
        }

        else if (buttonID == 6)
        {
            if (gc.daysLeft == -1)
            {
                img.sprite = spr2;
            }
            else
            {
                img.sprite = spr1;
            }
        }


        if (mouseOver)
        {
            rt.localScale = new Vector3(Mathf.Lerp(rt.localScale.x, bigSize, 0.2f), Mathf.Lerp(rt.localScale.y, bigSize, 0.2f), 0);
        }
        else if (tag == "button")
        {
            rt.localScale = new Vector3(Mathf.Lerp(rt.localScale.x, 1, 0.2f), Mathf.Lerp(rt.localScale.y, 1, 0.2f), 0);
        }

        if (buttonID == 8 && gc.gameState == 20)
        {
            img.enabled = false;
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {

        if (tag == "button")
        {

            if (buttonID == 1)
            {
                SceneManager.LoadScene("Story");
            }

            if (buttonID == 3)
            {
                if (gc.gameState == 3)
                {
                    gc.gameState = 4;
                }
                else if (gc.gameState == 5 || gc.gameState == 8)
                {
                    SceneManager.LoadScene("NextDay");
                }
            }

            if (buttonID == 2)
            {
                if (gc.daysLeft != 0)
                {
                    gc.gameState = 3;
                    gc.shopped = false;
                    SceneManager.LoadScene("Shop");
                }
                else
                {
                    gc.daysLeft = -1;
                    SceneManager.LoadScene("Story");
                }
            }

            if (buttonID == 4)
            {
                if (name == "Upgrade More")
                {
                    gc.gameState = 5;
                    gc.shopped = false;
                }
                if (name == "Research")
                {
                    gc.gameState = 6;
                }
                if (name == "Mine")
                {
                    gc.gameState = 7;
                }
            }


            if (buttonID == 5)
            {
                SceneManager.LoadScene("Shop");
            }

            if (buttonID == 6)
            {
                if (gc.daysLeft != -1) //end stuff
                {

                    SceneManager.LoadScene("Main");
                }
                else
                {
                    gc.daysLeft = 30;
                    gc.scraps = 0;
                    gc.gameState = 0;

                    gc.shopData.Clear();

                    for (var i = 0; i < 18; i++)
                    {
                        if (i == 0 || i == 6 || i == 12)
                        {
                            gc.shopData.Add(2);
                        }
                        else
                        {
                            gc.shopData.Add(0);
                        }
                    }

                    SceneManager.LoadScene("MainMenu");
                }
            }

            if (buttonID == 7)
            {
                tc.GetComponent<Image>().enabled = false;
                gc.StartCoroutine("beginLaunch");
                img.enabled = false;
                gc.gameState = 20;
            }

            if (buttonID == 8)
            {
                gc.daysLeft = 1;
                SceneManager.LoadScene("NextDay");
            }
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (tag == "button")
        {
            mouseOver = true;

            audioS.clip = clickM;
            audioS.Play();
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (tag == "button")
        {
            mouseOver = false;
        }
    }
}