using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowTarget : MonoBehaviour {

	//what we are following
	public Transform target;
	//zeros out the velocity
	Vector3 velocity = Vector3.zero;
	//time to follow target
	public float smoothTime = .15f;

	public bool YMaxEnabled = false;
	public float YMaxValue = 0;

	public bool YMinEnabled = false;
	public float YMinValue = 0;

	public bool XMaxEnabled = false;
	public float XMaxValue = 0;

	public bool XMinEnabled = false;
	public float XMinValue = 0;


	void fixedUpdate(){

		//target position
		Vector3 targetPos = target.position;

		if (YMinEnabled && YMaxEnabled)
			targetPos.y = Mathf.Clamp (target.position.y, YMinValue, YMaxValue);
		else if (YMinEnabled)
			targetPos.y = Mathf.Clamp (target.position.y, YMinValue, target.position.y);
		else if (YMaxEnabled)
			targetPos.y = Mathf.Clamp (target.position.y, YMaxValue, target.position.y);


		if (XMinEnabled && XMaxEnabled)
			targetPos.x = Mathf.Clamp (target.position.x, XMinValue, XMaxValue);
		else if (XMinEnabled)
			targetPos.x = Mathf.Clamp (target.position.x, XMinValue, target.position.x);
		else if (XMaxEnabled)
			targetPos.x = Mathf.Clamp (target.position.x, XMaxValue, target.position.x);
		


		//align the camera and the targets z position
		targetPos.z = transform.position.z;
		//using smooth damp we will gradually change the camera transform position to the target position on the cameras transform velocity and our smooth time
		transform.position = Vector3.SmoothDamp(transform.position, targetPos, ref velocity, smoothTime);
	}
}
