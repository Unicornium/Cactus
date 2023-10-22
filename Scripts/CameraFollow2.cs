using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow2 : MonoBehaviour {

	public Transform target;

	public float YMax = 0;

	public float YMin = 0;

	public float XMax = 0;

	public float XMin = 0;


	void FixedUpdate () {


		transform.position = new Vector3 (Mathf.Clamp(target.position.x, XMin, XMax), Mathf.Clamp(target.position.y, YMin, YMax), transform.position.z);

	}
}
