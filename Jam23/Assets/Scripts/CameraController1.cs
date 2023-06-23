using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController1 : MonoBehaviour
{
	public Transform CameraHolder;                  //Parent fo camera.
	public float SetPositionSpeed = 1;              //Change position speed.
	public float VelocityMultiplier;                //Velocity of car multiplier.

	public bool EnableRotation;
	public float MinDistanceForRotation = 0.1f;     //Min distance for potation, To avoid uncontrolled rotation.
	public float SetRotationSpeed = 1;              //Change rotation speed.

	CarController TargetCar { get { return MainController.PlayerCar; } }
	MainController MainController { get { return MainController.Instance; } }

	private float SqrMinDistance;

	Vector3 TargetPoint
	{
		get
		{
			if (MainController == null || TargetCar == null)
				return transform.position;

			Vector3 result = TargetCar.RB.velocity * VelocityMultiplier;
			result += TargetCar.transform.position;
			result.y = 0;

			return result;
		}
	}

	private IEnumerator Start()
	{
		while (MainController == null)
			yield return null;

		while (TargetCar == null)
			yield return null;

		transform.position = TargetPoint;
		CameraHolder.SetParent(TargetCar.transform);
	}

	private void Update()
	{
		if (EnableRotation && (TargetPoint - transform.position).sqrMagnitude >= SqrMinDistance)
		{
			Quaternion rotation = Quaternion.LookRotation(TargetPoint - transform.position, Vector3.up);
			CameraHolder.rotation = Quaternion.Lerp(CameraHolder.rotation, rotation, Time.deltaTime * SetRotationSpeed);
		}

		transform.position = Vector3.LerpUnclamped(transform.position, TargetPoint, Time.deltaTime * SetPositionSpeed);
	}
}
