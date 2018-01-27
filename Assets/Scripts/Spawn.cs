using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour {

    public float range = 5;

	// Use this for initialization
	void Awake () {
		Vector3 pos = Random.insideUnitCircle * range; 
		transform.position += pos; 
	}

}
