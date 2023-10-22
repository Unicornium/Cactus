using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseableSwich : Switch {

	[SerializeField]
	private AudioSource SwSound;

	public void Use(){

		Toggle ();

		SwSound.Play();
	}
	void OnTriggerEnter2D(Collider2D col)
	{
		
	}
}
