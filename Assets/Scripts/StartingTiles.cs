using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartingTiles : MonoBehaviour {

    public PassageTileManager ptm;

    // Use this for initialization
    void Start () {
        PassageTileManager upPtm = ptm.PlaceNewTile(0).GetComponentInChildren<PassageTileManager>();
        upPtm.PlaceNewTile(1);
        upPtm.PlaceNewTile(3);

        ptm.PlaceNewTile(1);

        PassageTileManager downPtm = ptm.PlaceNewTile(2).GetComponentInChildren<PassageTileManager>();
        downPtm.PlaceNewTile(1);
        downPtm.PlaceNewTile(3);

        ptm.PlaceNewTile(3);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
