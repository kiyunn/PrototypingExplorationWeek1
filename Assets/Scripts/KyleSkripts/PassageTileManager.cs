using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassageTileManager : MonoBehaviour {

	private BoxCollider2D[] passageTriggers;
	public float tilePlaceDistance = 10f;
	public GameObject floorTileInventory;

	private void Awake() {
		passageTriggers = new BoxCollider2D[transform.childCount];
		int childCounter = 0;
		foreach (Transform child in transform) {
			if (child.GetComponent<BoxCollider2D>()) {
				passageTriggers[childCounter] = child.GetComponent<BoxCollider2D>();
				childCounter++;
			}
		}
		if (floorTileInventory == null) {
			if (GameObject.Find("TileOptions")) {
				floorTileInventory = GameObject.Find("TileOptions");
			}
		}
	}

	public GameObject PlaceNewTile(int direction) {
		int randomMax = floorTileInventory.transform.childCount;
		int randomTile = Random.Range(0, randomMax);
		GameObject tileToPlace = this.gameObject;

		int childCounter = 0;
		foreach (Transform child in floorTileInventory.transform) {
			if (childCounter == randomTile) {
				tileToPlace = child.gameObject;
				break;
			} else {
				childCounter++;
			}
		}
		Vector2 placePosition = transform.position;
		switch (direction) {
			case 0:
				placePosition = new Vector2(transform.position.x, transform.position.y + tilePlaceDistance);
			break;
			case 1:
				placePosition = new Vector2(transform.position.x + tilePlaceDistance, transform.position.y);
			break;
			case 2:
				placePosition = new Vector2(transform.position.x, transform.position.y - tilePlaceDistance);
			break;
			case 3:
				placePosition = new Vector2(transform.position.x - tilePlaceDistance, transform.position.y);
			break;
		}
		GameObject newTile = Instantiate(tileToPlace, placePosition, Quaternion.identity) as GameObject;
		newTile.gameObject.SetActive(true);
        return newTile;
	}
}