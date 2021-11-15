using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class shopItem : MonoBehaviour
    ,IPointerClickHandler
    , IPointerEnterHandler
    , IPointerExitHandler
{

    public int itemID;
    public int price;

    public Sprite spr0;
    public Sprite spr1;
    public Sprite spr2;
    public Sprite spr3;

    Image sr;
    RectTransform rt;
    public float bigSize;
    bool mouseOver = false;

    gameController gc;
    infoController ic;

    AudioSource audioS;
    public AudioClip clickM;
    public AudioClip buyM;

    // Use this for initialization
    void Start () {
        gc = GameObject.Find("gameController").GetComponent<gameController>();
        ic = GameObject.Find("Info").GetComponent<infoController>();
        sr = GetComponent<Image>();
        rt = GetComponent<RectTransform>();
        audioS = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
	    if (gc.shopData[itemID] == 0)
        {
            sr.sprite = spr0;
            sr.color = new Color(1, 1, 1, 0.1f);
        }
        else if (gc.shopData[itemID] == 1)
        {
            sr.sprite = spr1;
            if (gc.gameState == 8)
            {
                if (sr.color.a > 0.7)
                    sr.color += new Color(0, 0, 0, -Time.deltaTime);
            }
            else
            {
                sr.color = new Color(1, 1, 1, 2f);
            }

            if (itemID == 3 || itemID == 4 || itemID == 5 || itemID == 9 || itemID == 10 || itemID == 11 || itemID == 14 || itemID == 17)
            {
                gc.shopData[itemID] = 2;
            }
            else if ((itemID == 1 && gc.shopData[0] == 3) || (itemID == 2 && gc.shopData[1] == 3) || (itemID == 7 && gc.shopData[6] == 3) || (itemID == 8 && gc.shopData[7] == 3) || (itemID == 13 && gc.shopData[12] == 3) ||
                    (itemID == 15 && gc.shopData[9] == 3) || (itemID == 16 && gc.shopData[4] == 3))
            {
                gc.shopData[itemID] = 2;

            }
        }
        else if (gc.shopData[itemID] == 2)
        {
            sr.sprite = spr2;
            if (gc.gameState == 8)
            {
                if (sr.color.a > 0.7)
                    sr.color += new Color(0, 0, 0, -Time.deltaTime);
            }
            else
            {
                sr.color = new Color(1, 1, 1, 2f);
            }
        }
        else if (gc.shopData[itemID] == 3)
        {
            sr.sprite = spr3;
            sr.color = new Color(1, 1, 1, 0.1f);
        }

        if (gc.shopData[itemID] == 6)
        {
            sr.color = new Color(1, 1, 1, 2f);
            if (itemID == 3 || itemID == 4 || itemID == 5 || itemID == 9 || itemID == 10 || itemID == 11 || itemID == 14 || itemID == 17)
            {
                gc.shopData[itemID] = 2;
            }
            else if ((itemID == 1 && gc.shopData[0] == 3) || (itemID == 2 && gc.shopData[1] == 3) || (itemID == 7 && gc.shopData[6] == 3) || (itemID == 8 && gc.shopData[7] == 3) || (itemID == 13 && gc.shopData[12] == 3) ||
                    (itemID == 15 && gc.shopData[9] == 3) || (itemID == 16 && gc.shopData[4] == 3))
            {
                gc.shopData[itemID] = 2;

            }
            else
            {
                gc.shopData[itemID] = 1;
            }
        }

        if (mouseOver && sr.color.a == 2)
        {
            rt.localScale = new Vector3(Mathf.Lerp(rt.localScale.x, bigSize, 0.2f), Mathf.Lerp(rt.localScale.y, bigSize, 0.2f), 0);
        }
        else
        {
            rt.localScale = new Vector3(Mathf.Lerp(rt.localScale.x, 1, 0.2f), Mathf.Lerp(rt.localScale.y, 1, 0.2f), 0);
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (gc.shopData[itemID] == 2 && gc.scraps >= price && gc.shopped == false && (gc.gameState == 3 || gc.gameState == 5))
        {
            gc.shopped = true;

            gc.shopData[itemID] = 4;
            gc.scraps -= price;

            StartCoroutine("flipCard");
        }
    }

    IEnumerator flipCard()
    {
        audioS.clip = buyM;
        audioS.Play();

        while (rt.rotation.y <= Quaternion.Euler(0, 90, 0).y)
        {
            rt.Rotate(0, Time.deltaTime * 350, 0);
            yield return null;
        }

        rt.rotation = Quaternion.Euler(0, -90, 0);
        sr.sprite = spr3;

        while (rt.rotation.y <= Quaternion.Euler(0, 0, 0).y)
        {
            rt.Rotate(0, Time.deltaTime * 350, 0);
            yield return null;
        }

        rt.rotation = Quaternion.Euler(0, 0, 0);

        while (sr.color.a > 0.1f)
        {
            sr.color += new Color(0, 0, 0, -Time.deltaTime * 2);
            yield return null;
        }

        gc.shopData[itemID] = 3;

        if (gc.gameState == 3)
        {
            gc.gameState = 4;
        }
        else
        {
            gc.gameState = 8;
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        mouseOver = true;
        if (gc.shopData[itemID] == 2)
        {
            ic.item = itemID;
            audioS.clip = clickM;
            audioS.Play();
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {

        mouseOver = false;

    }
}
