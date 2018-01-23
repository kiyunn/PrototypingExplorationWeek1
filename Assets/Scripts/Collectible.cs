using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    //Item Collect function
    public void Collect(Player player)
    {
        //Prints message in console on which player is trying to collect which treasure object
        Debug.Log(player.name + " trying to collect " + gameObject.name);
    }
}
