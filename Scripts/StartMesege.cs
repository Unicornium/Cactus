using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMesege : MonoBehaviour {

	float currentTime = 0f;
	float startingTime = 2f;

	[SerializeField]
	GameObject LvlBignUI;

	void Start () {
		currentTime = startingTime;
	}
	

	void Update () {
		currentTime -= 1 * Time.deltaTime;
		if (currentTime <= 0){
			currentTime = 0;
			LvlBignUI.gameObject.SetActive (false);
		}
	}
}
