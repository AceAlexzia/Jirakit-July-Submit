using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public bool isDevMode = false;
    [SerializeField]
    private List<GameObject> cardlist = new List<GameObject>();
    [SerializeField]
    private List<GameObject> selectCard = new List<GameObject>();


    [SerializeField]
    private int cardNumber = 0;
    [SerializeField]
    private List<int> randomNumber = new List<int>();
    [SerializeField]
    private GameObject Card;

    [SerializeField]
    private GameObject cardLayout;

    [SerializeField]
    private List<Sprite> cards_image = new List<Sprite>();

    public bool gameStart = false;



    // Shuffle for list
    void Shuffle<T>(List<T> inputList)
    {
        for (int i = 0; i < inputList.Count - 1; i++)
        {
            T temp = inputList[i];
            int rand = Random.Range(i, inputList.Count);
            inputList[i] = inputList[rand];
            inputList[rand] = temp;
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        instance = this;

        CardLayout card_layout = cardLayout.GetComponent<CardLayout>();
        if (LevelSelector_Singleton.instance != null)
        {
            card_layout.row = LevelSelector_Singleton.instance.rowNumber;
            card_layout.col = LevelSelector_Singleton.instance.colNumber;
            cardNumber = card_layout.row * card_layout.col;
        }
        else
        {
            card_layout.row = 3;
            card_layout.col = 2;
        }
        

        Shuffle(cards_image);
        

        CreateCard();
        RandomCardID();

        if(isDevMode)
        {

        }
        StartCoroutine(GameStart());

    }

    void Update()
    {
        if(gameStart)
        {
        }
    }

    private void CreateCard()
    {
        for (int i = 0; i < cardNumber; i++)
        {

            GameObject card = Instantiate(Card);
            card.transform.SetParent(cardLayout.transform);
            cardlist.Add(card);
            
        }

    }

    private void RandomCardID()
    {
        // Put number into the list
        for (int i = 0; i < cardNumber / 2; i++)
        {
            randomNumber.Add(i);
            randomNumber.Add(i);
        }

        // Random Number to the card
        Shuffle(randomNumber);

        // Assign Card id
        for (int i = 0; i < cardlist.Count; i++)
        {
            cardlist[i].GetComponent<Card>().ID = randomNumber[i];
        }

        // Assign Image to cards
        for (int i = 0; i < cardlist.Count; i++)
        {
            cardlist[i].GetComponent<Card>().image.sprite = cards_image[cardlist[i].GetComponent<Card>().ID];
        }

    }

    public void SelectCard(GameObject gameObject)
    {
        if (gameStart)
        {
            if (!selectCard.Contains(gameObject))
            {
                selectCard.Add(gameObject);

            }
            if (selectCard.Count % 2 == 0 && selectCard.Count > 1)
            {
                CheckCorrection();

            }
        }
        
    }

    private void CheckCorrection()
    {

        Debug.Log("selectCard.Count = " + selectCard.Count);
        //for (int i = 0; i < selectCard.Count - 1; i+=2)
        //{

        //}

        if (selectCard[0].GetComponent<Card>().ID == selectCard[1].GetComponent<Card>().ID)
        {

            Debug.Log("Matching");
            StartCoroutine(CardMatch());
            


            

        }
        else
        {
            Debug.Log("Not Matching");


            //Flip 2 cards

            //UnAssigned SelectCard
            StartCoroutine(CardUnMatch(0));

        }


        if (cardlist.Count == 0)
        {
            Debug.Log("Game End");
        }


    }

    IEnumerator GameStart()
    {


        yield return new WaitForSeconds(2.0f);

        foreach (var card in cardlist)
        {
            card.GetComponent<Card>().SetupCard(); 
        }
        gameStart = true;



    }
    IEnumerator CardUnMatch(int i)
    {
        
        // wait for flip
        yield return new WaitForSeconds(0.4f);

        selectCard[i].GetComponent<Card>().StartFlip();
        selectCard[i+1].GetComponent<Card>().StartFlip();

        selectCard[i].GetComponent<Card>().button.enabled = true;
        selectCard[i + 1].GetComponent<Card>().button.enabled = true;

        yield return new WaitForSeconds(0.05f);
        selectCard.RemoveAt(i);
        selectCard.RemoveAt(i);

    }

    IEnumerator CardMatch()
    {

        yield return new WaitForSeconds(0.4f);
        foreach (GameObject obj in selectCard)
        {
            //obj.SetActive(false);

            //Destroy(obj);
            obj.GetComponent<Image>().enabled = false;
            obj.GetComponent<Card>().image.enabled = false;

        }
        yield return new WaitForSeconds(0.05f);
        selectCard.RemoveAt(0);
        selectCard.RemoveAt(0);
        foreach (var card in selectCard)
        {
            cardlist.Remove(card);
        }
    }


}
