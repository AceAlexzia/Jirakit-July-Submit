using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
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

    [SerializeField]
    private SoundEffect soundEffect;

    private ScoreCalculation scoreCalculation;

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
        scoreCalculation = GetComponent<ScoreCalculation>();
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


        StartCoroutine(GameStart());

    }

    void Update()
    {

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
                soundEffect.PlayFlipSound();

            }
            if (selectCard.Count % 2 == 0 && selectCard.Count > 1)
            {
                CheckCorrection();

            }
        }
        
    }

    private void CheckCorrection()
    {


        if (selectCard[0].GetComponent<Card>().ID == selectCard[1].GetComponent<Card>().ID)
        {

            Debug.Log("Matching");
            StartCoroutine(CardMatch(0));
        }
        else
        {
            Debug.Log("Not Matching");


            //Flip 2 cards

            //UnAssigned SelectCard
            StartCoroutine(CardUnMatch(0));

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
        soundEffect.PlayWrongSound();
        scoreCalculation.UnMatchCalculation();
        selectCard[i].GetComponent<Card>().StartFlip();
        soundEffect.PlayFlipSound();
        selectCard[i+1].GetComponent<Card>().StartFlip();
        soundEffect.PlayFlipSound();
        selectCard[i].GetComponent<Card>().button.enabled = true;
        selectCard[i + 1].GetComponent<Card>().button.enabled = true;

        yield return new WaitForSeconds(0.05f);
        selectCard.RemoveAt(i);

        selectCard.RemoveAt(i);

    }

    IEnumerator CardMatch(int i)
    {

        yield return new WaitForSeconds(0.4f);
        soundEffect.PlayCorrectSound();
        scoreCalculation.MatchCalculation();

        selectCard[i].GetComponent<Image>().enabled = false;
        selectCard[i].GetComponent<Card>().image.enabled = false;
        selectCard[i+1].GetComponent<Image>().enabled = false;
        selectCard[i+1].GetComponent<Card>().image.enabled = false;


        yield return new WaitForSeconds(0.05f);
        foreach (var card in selectCard)
        {
            cardlist.Remove(card);
        }
        selectCard.RemoveAt(i);
        selectCard.RemoveAt(i);

        if (cardlist.Count == 0)
        {
            Debug.Log("Game End");

            soundEffect.PlayLevelCompleteSound();

            // save data
            if (LevelSelector_Singleton.instance.level == 1)
            {
                PlayerPrefs.SetInt("Passlv1", 1);
                if (scoreCalculation.totalScore > PlayerPrefs.GetFloat("HighScore1"))
                {
                    PlayerPrefs.SetFloat("HighScore1", scoreCalculation.totalScore);
                }
            }
            else if (LevelSelector_Singleton.instance.level == 2)
            {
                PlayerPrefs.SetInt("Passlv2", 1);
                if (scoreCalculation.totalScore > PlayerPrefs.GetFloat("HighScore2"))
                {
                    PlayerPrefs.SetFloat("HighScore2", scoreCalculation.totalScore);
                }
            }
            else if (LevelSelector_Singleton.instance.level == 3)
            {
                PlayerPrefs.SetInt("Passlv3", 1);
                if (scoreCalculation.totalScore > PlayerPrefs.GetFloat("HighScore3"))
                {
                    PlayerPrefs.SetFloat("HighScore3", scoreCalculation.totalScore);
                }
            }
            else if (LevelSelector_Singleton.instance.level == 4)
            {
                PlayerPrefs.SetInt("Passlv4", 1);
                if (scoreCalculation.totalScore > PlayerPrefs.GetFloat("HighScore4"))
                {
                    PlayerPrefs.SetFloat("HighScore4", scoreCalculation.totalScore);
                }
            }
            else if (LevelSelector_Singleton.instance.level == 5)
            {
                PlayerPrefs.SetInt("Passlv5", 1);
                if (scoreCalculation.totalScore > PlayerPrefs.GetFloat("HighScore5"))
                {
                    PlayerPrefs.SetFloat("HighScore5", scoreCalculation.totalScore);
                }
            }

            

            
        }
    }
}
