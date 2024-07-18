using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffect : MonoBehaviour
{

    [SerializeField]
    private AudioSource flip;
    [SerializeField]
    private AudioSource correct;
    [SerializeField]
    private AudioSource wrong;
    [SerializeField]
    private AudioSource levelComplete;

    public void PlayFlipSound()
    {
        flip.Play();
    }
    public void PlayCorrectSound()
    {
        correct.Play();
    }
    public void PlayWrongSound()
    {
        wrong.Play(); 
    }
    public void PlayLevelCompleteSound()
    {
        levelComplete.Play(); 
    }

}
