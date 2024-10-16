using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBounce : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision other)
    {
        Color color = UnityEngine.Random.ColorHSV();
        gameObject.GetComponent<MeshRenderer>().material.color = color;
    }
}
