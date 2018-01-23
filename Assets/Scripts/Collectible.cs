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

    public void Collect(Player player)
    {
        Debug.Log(player.name + " trying to collect " + gameObject.name);
    }
}
