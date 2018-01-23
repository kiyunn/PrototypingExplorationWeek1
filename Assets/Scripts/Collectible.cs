using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{//Script for Jess

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
        Debug.Log(player.name + " trying to collect " + gameObject.name);
    }
}
