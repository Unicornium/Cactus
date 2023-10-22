using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxSlideSound : MonoBehaviour
{
    [SerializeField]
    private AudioSource SoundBoxSlideSnd;

	void OnTriggerEnter2D(Collider2D col)
	{

		if (col.gameObject.tag == "Player")
		{

			SoundBoxSlideSnd.Play();
		}
		else 
		{
			SoundBoxSlideSnd.Stop();
		}
	}

	void OnTriggerExit2D(Collider2D col)
	{

		SoundBoxSlideSnd.Stop();
	}

	
}
