using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassageTrigger : MonoBehaviour {

	// 0 is up, 1 is right, 2 is down, 3 is left.
	public int direction;
	private float rayDistance = 3f;
	private PassageTileManager tileManager;
	public bool inTrigger = false;

	private void Awake() {
		if (direction < 0 || direction >= 4) {
			Debug.Log("The direction is an invalid number, please fix. -KB");
		}
		if (transform.parent != null) {
			tileManager = transform.parent.gameObject.GetComponent<PassageTileManager>();
		}
	}


	private void OnTriggerEnter2D(Collider2D trigger) {
		if (trigger.gameObject.tag == "Player") {
			if (!inTrigger) {
				inTrigger = true;
				if (CheckForTile()) {
					tileManager.PlaceNewTile(direction);
				} 
				// This was for testing.
				//else {
					//Debug.Log("There is a tile in the " + direction + " direction.");
				//}
			}
		}
	}

	private void OnTriggerExit2D(Collider2D trigger) {
		if (trigger.gameObject.tag == "Player") {
			if (inTrigger) {
				inTrigger = false;
			}
		}
	}

	// True means there is a tile in the specified direction, false means there is not.
	private bool CheckForTile() {
		RaycastHit2D[] hit;
		Vector2 rayDirection = transform.position;
		switch (direction) {
			case 0:
				rayDirection = transform.up;		
			break;
			case 1:
				rayDirection = transform.right;
			break;
			case 2:
				rayDirection = -transform.up;
			break;
			case 3:
				rayDirection = -transform.right;
			break;
		}
		// Disable collider to avoid casting at self
		this.GetComponent<BoxCollider2D>().enabled = false;
		hit = Physics2D.RaycastAll(transform.position, rayDirection, rayDistance);

		// This was for testing.
		//Debug.DrawRay(transform.position, rayDirection, Color.red, 5f);

		// Reenable collider after casting.
		this.GetComponent<BoxCollider2D>().enabled = true;
		if (hit != null) {
			for (int rayCycler = 0; rayCycler < hit.Length; rayCycler++) {
				if (hit[rayCycler].collider.tag == "FloorTile") {
					// This was for testing
					//Debug.Log(hit[rayCycler].collider.name);
					return false;
				}
			}
		}
		return true;
	}
}