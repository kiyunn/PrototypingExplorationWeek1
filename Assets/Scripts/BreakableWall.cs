using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableWall : MonoBehaviour {

    public BoxCollider2D collision;
    public GameObject explodePrefab;

	// Use this for initialization
	void Start () {

        collision = GetComponent<BoxCollider2D>();

	}
	
	// Update is called once per frame
	void Update () {
        
        
	}

    void OnTriggerStay2D(Collider2D other)
   {
        
            if (Input.GetKeyDown(KeyCode.Space))
            {
            Debug.Log("HEY");
            Destroy(gameObject);
            }
        
    }

    private void OnDestroy()
    {
        Instantiate(explodePrefab, transform.position, explodePrefab.transform.rotation);
    }
}
