using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    #region Variables
    public static GameManager instance;
    public string mode;
    private InputHandler inputHandler;
    [SerializeField]
    private List<GameObject> cardlist = new List<GameObject>();
    [SerializeField]
    private List<GameObject> selectCard = new List<GameObject>();
    


    #endregion

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        

    }

    void Update()
    {
        
    }



    public void SelectCard(GameObject gameObject)
    {
        Debug.Log("InSelectCard");
        if (!selectCard.Contains(gameObject))
        {
            selectCard.Add(gameObject);
        }
        else
        {
            selectCard.Remove(gameObject);
        }
        if (selectCard.Count == 2)
        {
            CheckCorrection();
        }
    }

    private void CheckCorrection()
    {
        if (selectCard[0].GetComponent<Card>().ID == selectCard[1].GetComponent<Card>().ID)
        {
            Debug.Log("Matching");

            foreach (var card in selectCard)
            {
                cardlist.Remove(card);
            }
            

            foreach (GameObject obj in selectCard)
            {
                //obj.SetActive(false);

                //Destroy(obj);
                obj.GetComponent<Image>().enabled = false;
                obj.GetComponentInChildren<Image>().enabled = false;

            }
        }
        else
        {
            Debug.Log("Not Matching");
        }

        if (cardlist.Count == 0)
        {
            Debug.Log("Game End");
        }


        selectCard.Clear();
    }



}
