using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particles : MonoBehaviour
{//Script for Selina

    // Use this for initialization

    public GameObject prefabParticle;


	void Start()
    {
 
        //Calls function "Die" and makes Particles disappear after 5 seconds
        Invoke("Die", 5f);
	}
	
	// Update is called once per frame
	void Update()
    {
        //make empty game object at object position
        GameObject particleEffect = Instantiate(prefabParticle, transform.position, transform.rotation);

        //

	}

    //Die Function
    void Die()
    {
        //Destorys particle system object
        Destroy(gameObject);
    }
}
