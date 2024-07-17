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
        if(canFlip)
        {
            //BeforeFlipCard();
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

    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
