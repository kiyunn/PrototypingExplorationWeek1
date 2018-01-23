using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particles : MonoBehaviour
{

	// Use this for initialization
	void Start()
    {
        //Calls function "Die" and makes Particles disappear after 5 seconds
        Invoke("Die", 5f);
	}
	
	// Update is called once per frame
	void Update()
    {
		
	}

    //Die Function
    void Die()
    {
        //Destorys particle system object
        Destroy(gameObject);
    }
}
