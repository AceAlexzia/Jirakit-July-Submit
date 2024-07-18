using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    public int ID;
    public Image image;
    [SerializeField]
    private Sprite faceSprite, backSprite;

    private Image card_image;


    private bool isFaceUp = false;
    [SerializeField]
    private float x, y, z;
    float timer = 0.0f;
    [HideInInspector]
    public bool isFinishFlip = true;


    // Start is called before the first frame update
    void Start()
    {
        card_image = GetComponent<Image>();
        //card_image.sprite = backSprite;
        isFaceUp = true;

    }
    public void SelectCard()
    {
        GameManager.instance.SelectCard(this.gameObject);
        // Flip
        if (GameManager.instance.gameStart)
        {
            StartFlip();
        }

    }


    public void SetupCard()
    {
        card_image.sprite = backSprite;
        image.enabled = false;
        isFaceUp = false;

    }

    public void StartFlip()
    {
        StartCoroutine(CalculateFlip());
    }
    private void Flip()
    {
        if (!isFaceUp)
        {
            card_image.sprite = faceSprite;
            image.enabled = true;

        }
        else
        {
            card_image.sprite = backSprite;
            image.enabled = false;
        }
    }

    public IEnumerator CalculateFlip()
    {

        if (isFaceUp)
        {
            for (int i = 180; i >= 0; i--)
            {
                yield return new WaitForSeconds(0.0001f);
                //transform.Rotate(new Vector3(x, y, z));

                gameObject.GetComponent<RectTransform>().eulerAngles = new Vector3(x, i, z);
                timer++;
                if (timer == 90 || timer == -90)
                {
                    Flip();
                }
            }
        }
        else
        {
            for (int i = 0; i <= 180; i++)
            {
                yield return new WaitForSeconds(0.0001f);
                //transform.Rotate(new Vector3(x, y, z));

                gameObject.GetComponent<RectTransform>().eulerAngles = new Vector3(x, i, z);
                timer++;
                if (timer == 90 || timer == -90)
                {
                    Flip();
                }
            }
        }
        timer = 0;
        isFaceUp = !isFaceUp;
        //if (back)
        //{

        //}
        //else
        //{
        //    for (int i = ; i <= 180; i++)
        //    {
        //        yield return new WaitForSeconds(0.001f);
        //        transform.Rotate(new Vector3(x, y, z));

        //        if (i == 90)
        //        {
        //            Flip();
        //        }
        //    }
        //}

    }
}
