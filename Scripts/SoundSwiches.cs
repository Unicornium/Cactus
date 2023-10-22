using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundSwiches : MonoBehaviour
{

    [SerializeField]
    private AudioSource SoundSwich;
   
    void OnTriggerEnter2D(Collider2D col)
    {
        SoundSwich.Play();
    }
}
