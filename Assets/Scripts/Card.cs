using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    public int ID;
    public Image image;



    public void SelectCard()
    {
        GameManager.instance.SelectCard(this.gameObject);
        // Flip

    }

    // Start is called before the first frame update
    void Start()
    {
        //image = GetComponentInChildren<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
