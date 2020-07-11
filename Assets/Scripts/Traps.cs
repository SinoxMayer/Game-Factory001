using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Traps : MonoBehaviour
{
    private ScoreManager _scoreManager;
    private LevelManager _levelManager;

    private void Awake()
    {
        _scoreManager = FindObjectOfType<ScoreManager>();
        _levelManager = FindObjectOfType<LevelManager>();
    }

    private void OnCollisionEnter(Collision other)
    {
        if (!other.gameObject.CompareTag("Player")) return;
        if (_levelManager.playerNumber == true)
        {
            
            _scoreManager.AddScore(-5);  
            other.gameObject.transform.position = new  Vector3(0,-25,0);
            _levelManager.playerNumber = false;

            //ilk basta zemini yok ediyordum sımdı playerı isınlıyorum

        }
        else 
        {
            //hata var bakacağım
            _levelManager.GameOver();

        }
       
    }
}
