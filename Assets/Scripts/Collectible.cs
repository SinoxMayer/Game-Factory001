using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{    private bool _isFirstAppleEaten = false;
    private ScoreManager _scoreManager;
    private LoadNextLvl _loadNextLvl;


    private void Awake()
    {
        _scoreManager = FindObjectOfType<ScoreManager>();
        _loadNextLvl  = FindObjectOfType<LoadNextLvl>();
    }

    public void Collect()
    {
        
        _scoreManager.AddScore(5);
       
    }
    
    
    private void InvisibleAndGone()
    {

     
        
        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<BoxCollider>().enabled = false;
        
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerController>() == null) return;
        
        //aşağıdaki if ile appleeve dısında yediği objeleri destroy edebiliyorum ve nextlvl trigger etmiyor.
        if (CompareTag("AppleEve"))
        {
           
            if (_isFirstAppleEaten != true)
            { 
                Collect();
                InvisibleAndGone();
                _isFirstAppleEaten = true;
                //build indexte şuankinden sonra gelen ekranı alacak .
                StartCoroutine(_loadNextLvl.NextLvlLastStop());
            }
            else
            {   Collect();
                InvisibleAndGone();
              
            }
        }
        else
        {
            Collect();
            Destroy(gameObject);
            
        }
     
    }

}
