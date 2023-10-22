using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour {

	public enum ResetType { Never, OnUse, Timed, Immediatly }

	public ResetType resetType = ResetType.OnUse;
	public List<GameObject> Targets = new List<GameObject>();
	public string OnMessage;
	public string OffMessage;
	public bool IsOn;
	public float ResetTime;

	Animator myAnimator;

	// Use this for initialization
	void Start () {

		myAnimator = GetComponent<Animator> ();
	}

	public void TurnOn(){

		if (!IsOn)
			SetState (true);
	}

	public void TurnOff(){

		if (IsOn && resetType!= ResetType.Never && resetType != ResetType.Timed)
			SetState (false);
	}

	public void Toggle(){

		if (IsOn)
			TurnOff ();
		else
			TurnOn ();
	}

	void TimedReset(){

		SetState (false);
	}

	void SetState (bool on) {

		IsOn = on;
		myAnimator.SetBool ("On", on);
		if (on) {

			if (Targets.Count>0 && !string.IsNullOrEmpty (OnMessage))
				Targets.ForEach(n=>n.SendMessage(OnMessage));
			if (resetType == ResetType.Immediatly)
				TurnOff();
			else if (resetType == ResetType.Timed)
				Invoke("TimedReset",ResetTime);
		}
		else {

			if (Targets.Count>0 && !string.IsNullOrEmpty (OffMessage))
				Targets.ForEach(n=>n.SendMessage(OffMessage));
		}
	}
}
