using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelector_Singleton : MonoBehaviour
{
    public static LevelSelector_Singleton instance {  get; private set; }
    public int rowNumber;
    public int colNumber;
    public int level = 0;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }



}
