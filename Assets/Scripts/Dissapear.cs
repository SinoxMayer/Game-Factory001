using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dissapear : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        if (other.rigidbody.CompareTag("Player"))
        {
            Disappear();
        }
       
    }

    private void Disappear()
    {

        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<BoxCollider>().enabled = false;
        
    }
}
