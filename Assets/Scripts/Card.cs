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
        float duration = 0.1f; // Total duration of the flip animation (in seconds)
        float elapsedTime = 0f;
        Quaternion startRotation = gameObject.GetComponent<RectTransform>().rotation;
        Quaternion endRotation = Quaternion.Euler(new Vector3(x, 90, z)); // Rotate to 90 degrees on the y-axis

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            float t = Mathf.Clamp01(elapsedTime / duration); // Calculate interpolation factor
            gameObject.GetComponent<RectTransform>().rotation = Quaternion.Slerp(startRotation, endRotation, t);
            yield return null; // Wait for the end of the frame
        }

        // Ensure we end exactly at 90 degrees
        gameObject.GetComponent<RectTransform>().rotation = endRotation;

        Flip(); // Perform any action needed at the halfway point (if required)

        // Reverse the flip
        elapsedTime = 0f;
        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            float t = Mathf.Clamp01(elapsedTime / duration); // Calculate interpolation factor
            gameObject.GetComponent<RectTransform>().rotation = Quaternion.Slerp(endRotation, startRotation, t);
            yield return null; // Wait for the end of the frame
        }

        // Ensure we end exactly at the start rotation
        gameObject.GetComponent<RectTransform>().rotation = startRotation;

        isFaceUp = !isFaceUp;
        isFinishFlip = true;
    }

}
