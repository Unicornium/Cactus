using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressureSwitch : Switch {

	int numberColliding = 0;

	[SerializeField]
	private AudioSource buttonSound;


	void OnTriggerEnter2D(Collider2D col){
		/*
		numberColliding++;
		TurnOn ();
		buttonSound.Play();
		*/

		if (col.gameObject.tag == "Player" ^ col.gameObject.tag == "Box")
		{
			numberColliding++;
			TurnOn();
			buttonSound.Play();
		}
	}

	void OnTriggerExit2D(Collider2D col){

		numberColliding--;
		if (numberColliding == 0)
			TurnOff ();
			buttonSound.Play();
	}

}
