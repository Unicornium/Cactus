using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour {

	public bool IsOpen;
	public int KnocksToOpen = 1;

	Animator myAnimator;
	Collider2D myCollider;
	int knocks;

	[SerializeField]
	private AudioSource dooropenSound;

	// Use this for initialization
	void Start () {

		myAnimator = GetComponent<Animator> ();
		myCollider = GetComponent<Collider2D> ();
	}

	public void Open(){

		knocks++;
		if (!IsOpen && knocks >= KnocksToOpen)
			SetState (true);
	}

	public void Close(){

		knocks--;
		if (IsOpen && knocks < KnocksToOpen)
			SetState (false);
	}

	public void Toggle(){

		if (IsOpen)
			Close ();
		else
			Open ();
	}


	void SetState (bool open) {

		IsOpen = open;
		myAnimator.SetBool ("Open", open);
		myCollider.isTrigger = open;
		dooropenSound.Play();
	}
}
