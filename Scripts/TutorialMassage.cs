using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialMassage : MonoBehaviour
{
	[SerializeField]
	GameObject TutorialUI;

	void OnTriggerEnter2D(Collider2D col)
	{

		TutorialUI.gameObject.SetActive(true);

	}

	void OnTriggerExit2D(Collider2D col)
	{

		TutorialUI.gameObject.SetActive(false);

	}
}
