using UnityEngine;
using System.Collections;

using VibrationType = Thalmic.Myo.VibrationType;
using Pose = Thalmic.Myo.Pose;

public class FireArrow : MonoBehaviour {

	public GameObject Bow;
	public Rigidbody FlyingArrow;
	public GameObject myo = null;
	private bool clenched = false;

	private Pose _lastPose = Pose.Rest;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		ThalmicMyo thalmicMyo = myo.GetComponent<ThalmicMyo> ();
		if (thalmicMyo.pose != _lastPose)
		{
			_lastPose = thalmicMyo.pose;
			if (thalmicMyo.pose == Pose.Fist) {
				thalmicMyo.Vibrate (VibrationType.Medium);
				clenched = true;
				//
			} else if (thalmicMyo.pose == Pose.FingersSpread && clenched) {
				thalmicMyo.Vibrate (VibrationType.Short);
				clenched = false;
				fire();
			}
		}


	}

	void fire()
	{
		Rigidbody arrowClone = (Rigidbody) Instantiate (FlyingArrow,Bow.transform.position,Bow.transform.rotation);
		arrowClone.velocity = (transform.TransformDirection(Vector3.down*20));
	}

}
