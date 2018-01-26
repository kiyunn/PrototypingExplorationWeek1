using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScore : MonoBehaviour {

    float initialY;

    private void Awake()
    {
        initialY = transform.localPosition.y;
    }

    void Update()
    {
        Vector3 pos = transform.localPosition;
        pos.y = initialY;
        if (transform.parent.position.y > 4f)
        {
            pos.y *= -1f;
        }
        transform.localPosition = pos;
    }
}
