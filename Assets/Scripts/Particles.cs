using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particles : MonoBehaviour
{

	// Use this for initialization
	void Start()
    {
        Invoke("Die", 5f);
	}
	
	// Update is called once per frame
	void Update()
    {
		
	}

    void Die()
    {
        Destroy(gameObject);
    }
}
