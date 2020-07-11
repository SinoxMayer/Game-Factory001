using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFallow : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private Transform target2;
    [SerializeField] private float smoothness = 1f;
    [SerializeField] private Vector3 offset;
    
    private bool _isTargetNull;

    private LevelManager _levelManager;

    // Start is called before the first frame update
    private void Start()
    {
        _levelManager = FindObjectOfType<LevelManager>();
        _isTargetNull = target == null;
    }

    private void LateUpdate()
    {
       CamFallow();
    }

    private void CamFallow()
    {
        if (_isTargetNull)
        {
            return;
        }

        float plyrOneYPstn = target.position.y;
        float plyrTwoYPstn = target2.position.y;
        if (plyrOneYPstn > -2 && plyrTwoYPstn > -2)
        {
            Vector3 midPosition = (target.position + target2.position) / 2;
            transform.position = Vector3.Lerp(transform.position, b: midPosition + offset, 
                Time.deltaTime * smoothness);
        }
        else if (plyrOneYPstn > -2 && plyrTwoYPstn < -2)
        {
            transform.position = Vector3.Lerp(transform.position, target.position+ offset,
                Time.deltaTime * smoothness);
            
        }
        else if (plyrTwoYPstn > -2  && plyrOneYPstn < -2)
        {
            transform.position = Vector3.Lerp(transform.position, target2.position+ offset,
                Time.deltaTime * smoothness);
        }
        else
        {
            _levelManager.GameOver();
        }

        // (target.position/2 + target2.position/2) 

     
    }
}
