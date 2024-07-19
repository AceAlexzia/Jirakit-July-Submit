using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    [SerializeField]
    private GameObject complete1;
    [SerializeField]
    private GameObject complete2;
    [SerializeField]
    private GameObject complete3;
    [SerializeField]
    private GameObject complete4;
    [SerializeField]
    private GameObject complete5;

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);

    }

    public void LoadGameplaySceneAtLevel(int level)
    {
        if (level == 1)
        {
            LevelSelector_Singleton.instance.rowNumber = 2;
            LevelSelector_Singleton.instance.colNumber = 2;
        }
        else if (level == 2)
        {
            LevelSelector_Singleton.instance.rowNumber = 2;
            LevelSelector_Singleton.instance.colNumber = 3;
        }
        else if (level == 3)
        {
            LevelSelector_Singleton.instance.rowNumber = 4;
            LevelSelector_Singleton.instance.colNumber = 5;
        }
        else if (level == 4)
        {
            LevelSelector_Singleton.instance.rowNumber = 6;
            LevelSelector_Singleton.instance.colNumber = 5;
        }
        else if (level == 5)
        {
            LevelSelector_Singleton.instance.rowNumber = 7;
            LevelSelector_Singleton.instance.colNumber = 8;
        }
        else if (level == 6)
        {
            LevelSelector_Singleton.instance.rowNumber = 8;
            LevelSelector_Singleton.instance.colNumber = 8;
        }
        else if (level == 7)
        {
            LevelSelector_Singleton.instance.rowNumber = 10;
            LevelSelector_Singleton.instance.colNumber = 10;
        }
        LevelSelector_Singleton.instance.level = level;

    }


    public void ExitGame()
    {
        Application.Quit();
    }

    // Start is called before the first frame update
    void Start()
    {


        if (!PlayerPrefs.HasKey("Passlv1"))
        {
            PlayerPrefs.SetInt("Passlv1", 0);
        }
        else
        {
            if(PlayerPrefs.GetInt("Passlv1") == 1)
            {
                complete1.SetActive(true);
            }
        }
        if (!PlayerPrefs.HasKey("Passlv2"))
        {
            PlayerPrefs.SetInt("Passlv2", 0);
        }
        else
        {
            if (PlayerPrefs.GetInt("Passlv2") == 1)
            {
                complete2.SetActive(true);
            }
        }
        if (!PlayerPrefs.HasKey("Passlv3"))
        {
            PlayerPrefs.SetInt("Passlv3", 0);
        }
        else
        {
            if (PlayerPrefs.GetInt("Passlv3") == 1)
            {
                complete3.SetActive(true);
            }
        }
        if (!PlayerPrefs.HasKey("Passlv4"))
        {
            PlayerPrefs.SetInt("Passlv4", 0);
        }
        else
        {
            if (PlayerPrefs.GetInt("Passlv4") == 1)
            {
                complete4.SetActive(true);
            }
        }
        if (!PlayerPrefs.HasKey("Passlv5"))
        {
            PlayerPrefs.SetInt("Passlv5", 0);
        }
        else
        {
            if (PlayerPrefs.GetInt("Passlv5") == 1)
            {
                complete5.SetActive(true);
            }
        }
        if (!PlayerPrefs.HasKey("HighScore1"))
        {
            PlayerPrefs.SetFloat("HighScore1", 0);
        }
        if (!PlayerPrefs.HasKey("HighScore2"))
        {
            PlayerPrefs.SetFloat("HighScore2", 0);
        }
        if (!PlayerPrefs.HasKey("HighScore3"))
        {
            PlayerPrefs.SetFloat("HighScore3", 0);
        }
        if (!PlayerPrefs.HasKey("HighScore4"))
        {
            PlayerPrefs.SetFloat("HighScore4", 0);
        }
        if (!PlayerPrefs.HasKey("HighScore5"))
        {
            PlayerPrefs.SetFloat("HighScore5", 0);
        }
    }

    


}
