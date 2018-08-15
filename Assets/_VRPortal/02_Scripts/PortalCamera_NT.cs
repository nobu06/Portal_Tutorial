using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalCamera_NT : MonoBehaviour {

	public Transform playerCamera;
	public Transform portal;		// portal this camera belongs to
	public Transform otherPortal;	// player is close to


	void Update() {
		// align the offset from the portal to this camera
		Vector3 playerOffsetFromPortal = playerCamera.position - otherPortal.position;
		transform.position = portal.position + playerOffsetFromPortal;


		// align the rotation of the cameras
		float angularDifferenceBetweenPortalRotations = Quaternion.Angle (portal.rotation, otherPortal.rotation); 

		Quaternion portalRotationalDifference = Quaternion.AngleAxis (angularDifferenceBetweenPortalRotations, Vector3.up);
		Vector3 newCameraDirection = portalRotationalDifference * playerCamera.forward;

		transform.rotation = Quaternion.LookRotation (newCameraDirection, Vector3.up);
	}

}

//// seems like this works too - NT
//		Quaternion playerCameraRotation = playerCamera.rotation;
//		gameObject.transform.rotation = playerCameraRotation;