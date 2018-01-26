using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{

    int scoreSum = 0;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //hello!
    }

    //Item Collect function
    public void Collect(Player player)
    {
        //Prints message in console on which player is trying to collect which treasure object when button is pressed
        Debug.Log(player.name + " collected " + gameObject.name);
        scoreSum ++;
        Destroy(gameObject);

        player.AddScore(scoreSum);
    }

}
