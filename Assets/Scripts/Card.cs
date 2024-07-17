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

    private Animator animator;
    
    private bool isFaceUp = false;
    private bool canFlip = true;
    [SerializeField]
    private float x, y, z;
    float timer = 0.0f;


    // Start is called before the first frame update
    void Start()
    {
        card_image = GetComponent<Image>();
        //card_image.sprite = backSprite;
        animator = GetComponent<Animator>();
        isFaceUp = true;

    }
    public void SelectCard()
    {
        GameManager.instance.SelectCard(this.gameObject);
        // Flip
        if(canFlip && GameManager.instance.gameStart)
        {
            StartFlip();
        }

    }
    public void BeforeFlipCard()
    {
        canFlip = false;
        if (isFaceUp)
        {
            //animator.SetBool("FlipCardBack", true);
            animator.SetTrigger("FlipCardBack");
        }
        else
        {
            //animator.SetBool("FlipCardFront", true);
            animator.SetTrigger("FlipCardFront");
        }
    }

    public void AfterFlipCard()
    {
        if (isFaceUp)
        {
            //animator.SetBool("FlipCardBack", false);
            animator.SetTrigger("FlipCardBack");
            card_image.sprite = backSprite;
        }
        else
        {
            //animator.SetBool("FlipCardFront", false);
            card_image.sprite = faceSprite;
            animator.SetTrigger("FlipCardFront");
        }
        isFaceUp = !isFaceUp;
        canFlip = true;

        
    }

    public void SetupCard()
    {
        card_image.sprite = backSprite;
        image.enabled = false;
        isFaceUp = false;

    }

    private void StartFlip()
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
        for (int i = 0; i <= 180; i++)
        {
            yield return new WaitForSeconds(0.0001f);
            transform.Rotate(new Vector3(x, y, z));
            timer++;
            if (timer == 90 || timer == -90)
            {
                Flip();
            }
        }
        timer = 0;
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


    // Update is called once per frame
    void Update()
    {
        
    }
}
