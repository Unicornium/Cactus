using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class MusicOperator : MonoBehaviour
{
    [SerializeField]
    GameObject DeathUI;
    [SerializeField]
    private AudioSource gameoverSounds;
    [SerializeField]
    private AudioSource music;
  
    void Start()
    {
        music.Play();
        Debug.Log("MusicPlay!");
    }

    /* Update is called once per frame
    void Update()
    {
        if (Health.health <= 0)
        {
            music.Stop();
            gameoverSounds.Play();
            Debug.Log("GameOverSoundPlay!");
        }
    }*/
}
