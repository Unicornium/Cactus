using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxFallSound : MonoBehaviour
{
	[SerializeField]
	private AudioSource SoundBoxFallSnd;


	[SerializeField]
	GameObject Box;
	/*
		private void OnCollisionEnter2D(Collision2D collision)
		{
			SoundBoxFallSnd.Play();

			if (collision.gameObject.tag == "Box")
			{

				SoundBoxFallSnd.Play();
			}

		}
	*/
	void OnTriggerEnter2D(Collider2D col)
	{

		if (col.gameObject.tag == "Box")
		{

			SoundBoxFallSnd.Play();
		}
		else
		{ 
			SoundBoxFallSnd.Stop(); 
		}
	}


}
