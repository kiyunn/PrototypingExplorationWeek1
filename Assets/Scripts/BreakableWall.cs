using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableWall : MonoBehaviour {

    public GameObject explodePrefab;


	
    public void Break() {
        Debug.Log("HEY");
        Instantiate(explodePrefab, transform.position, explodePrefab.transform.rotation);
        Destroy(gameObject);
    }
}
