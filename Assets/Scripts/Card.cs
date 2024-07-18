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
    [HideInInspector]
    public bool isFinishFlip = true;
    [HideInInspector]
    public bool isSelect = false;
    public Button button;

    // Start is called before the first frame update
    void Start()
    {
        card_image = GetComponent<Image>();
        //card_image.sprite = backSprite;
        isFaceUp = true;
        button = GetComponent<Button>();
    }
    public void SelectCard()
    {
        if (isFinishFlip)
        {
            GameManager.instance.SelectCard(this.gameObject);

            // Flip
            if (GameManager.instance.gameStart)
            {
                StartFlip();
                button.enabled = false;
                isFinishFlip = false;
            }
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

        for (int i = 0; i <= 90; i++)
        {
            yield return new WaitForSeconds(0.0001f);
            //transform.Rotate(new Vector3(x, i, z));

            gameObject.GetComponent<RectTransform>().eulerAngles = new Vector3(x, i, z);
            if (i == 90)
            {
                Flip();
            }
        }
        for (int i = 90; i >= 0; i--)
        {
            yield return new WaitForSeconds(0.0001f);
            gameObject.GetComponent<RectTransform>().eulerAngles = new Vector3(x, i, z);
            if (i == 90)
            {
                Flip();
            }

        }
    
        isFaceUp = !isFaceUp;
        isFinishFlip = true;
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
