using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockMove : MonoBehaviour
{
    [SerializeField] private float patrolRange;
    [SerializeField] private float moveSpeed;

    private Vector3 _initialPosition;
    private Vector3 _minPosition;
    private Vector3 _maxPosition;
    private Vector3 _destinationPoint;
    
    


    private void Awake()
    {
        _initialPosition = transform.position;
        
        //bu alanlarda maximum ve minimum posisyonları veriyoruz ve patrol range kadar gezdiyoruz.
        _minPosition = _initialPosition + Vector3.left * patrolRange;
        _maxPosition = _initialPosition + Vector3.right * patrolRange;

        SetDestination(_maxPosition);
       
    }

    private void SetDestination(Vector3 destination)
    {
        _destinationPoint = destination;
    }


    private void Update()
    {
        if (Vector3.Distance(transform.position, _maxPosition) < 0.1f)
        {
            SetDestination(_minPosition);
        }
        else if (Vector3.Distance(transform.position, _minPosition) < 0.1f)
        {
            SetDestination(_maxPosition);
        }
        
        transform.position =
            Vector3.MoveTowards(transform.position,
                _destinationPoint, 
                Time.deltaTime * moveSpeed);
    }
    //Bu alanda platforma tutunmasını saglıyorum
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.collider.transform.SetParent(transform);
        }
    }

    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.collider.transform.SetParent(null);
        }
    }

}
