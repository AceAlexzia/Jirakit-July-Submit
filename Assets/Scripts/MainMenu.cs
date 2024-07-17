using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);

    }

    public void LoadGameplaySceneAtLevel(int level)
    {
        if (level == 0)
        {
            LevelSelector_Singleton.instance.rowNumber = 2;
            LevelSelector_Singleton.instance.colNumber = 2;
        }
        else if (level == 1)
        {
            LevelSelector_Singleton.instance.rowNumber = 2;
            LevelSelector_Singleton.instance.colNumber = 3;
        }
        else if (level == 2)
        {
            LevelSelector_Singleton.instance.rowNumber = 4;
            LevelSelector_Singleton.instance.colNumber = 5;
        }
        else if (level == 3)
        {
            LevelSelector_Singleton.instance.rowNumber = 6;
            LevelSelector_Singleton.instance.colNumber = 5;
        }
        else if (level == 4)
        {
            LevelSelector_Singleton.instance.rowNumber = 7;
            LevelSelector_Singleton.instance.colNumber = 8;
        }
        else if (level == 5)
        {
            LevelSelector_Singleton.instance.rowNumber = 8;
            LevelSelector_Singleton.instance.colNumber = 8;
        }
        else if (level == 6)
        {
            LevelSelector_Singleton.instance.rowNumber = 10;
            LevelSelector_Singleton.instance.colNumber = 10;
        }
        else
        {
            LevelSelector_Singleton.instance.rowNumber = 2;
            LevelSelector_Singleton.instance.colNumber = 2;
        }
    }


    public void ExitGame()
    {
        Application.Quit();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    


}
