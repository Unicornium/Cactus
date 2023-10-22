using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform8 : MonoBehaviour {
	Animator anim;

	private Rigidbody2D rb;

	[SerializeField]
	private AudioSource SoundFallPlatform;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator> ();
	}

	void OnCollisionEnter2D (Collision2D col) {
		if ( col.gameObject.name.Equals ("Cactus")) 
	{
			Invoke ("DropPlatform", 0.5f);
			Destroy (gameObject, 2f);
			anim.SetFloat("Fall", 0.5f);
			SoundFallPlatform.Play();
		}
		
	}

	void DropPlatform(){
		rb.isKinematic = false;

	}
}
