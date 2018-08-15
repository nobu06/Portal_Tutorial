using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalTeleporter_NT : MonoBehaviour {

	public Transform player;
	public Transform receiver;		// the receiving portal - in the other world


	private bool playerIsOverlapping = false;		// to check if the player and the portal are overlapping

	void Update() {
		
		if (playerIsOverlapping) {
			Vector3 portalToPlayer = player.position - transform.position;  // get a vector pointing from the portal to the player 
			float dotProduct = Vector3.Dot(transform.up, portalToPlayer);

			// If this is true: The player has moved across the portal
			if (dotProduct < 0f)
			{
				// teleport him
				float rotationDiff = -Quaternion.Angle(transform.rotation, receiver.rotation);
				rotationDiff += 180;
				player.Rotate (Vector3.up, rotationDiff);

				Vector3 positionOffset = Quaternion.Euler(0f, rotationDiff, 0f) * portalToPlayer;
				 
				player.position = receiver.position + positionOffset;

				playerIsOverlapping = false;
			}
		}
	}

	void OnTriggerEnter(Collider other) {
		if (other.tag == "Player"){
			playerIsOverlapping = true;	
		}
	}

	void OnTriggerExit(Collider other) {
		if (other.tag == "Player") {
			playerIsOverlapping = false;
		}
	}

}


//Vector3 playerForward = player.forward;
//Vector3 portalUp = gameObject.transform.forward;
//
//if (Mathf.Cos(Vector3.Angle (playerForward, portalUp)) > 0)
//{
//	// coming from the right direction
//	// then move the player to another place
//	player.position = receiver.position;
//}
//
//else if (Mathf.Cos(Vector3.Angle (playerForward, portalUp)) < 0)
//{
//	// do nothing
//
//}




//// teleport him!
//float rotationDiff = -Quaternion.Angle(transform.rotation, receiver.rotation);
//rotationDiff += 180;
//player.Rotate (Vector3.up, rotationDiff);
//
//Vector3 positionOffset = Quaternion.Euler (0f, rotationDiff, 0f) * portalToPlayer;
//player.position = receiver.position + positionOffset;
//
//playerIsOverlapping = false;