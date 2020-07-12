using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{   [SerializeField] private Transform target;
    [SerializeField] private Transform target2;
    public bool playerOneIsAlive= true;
    public bool playerTwoIsAlive= true;
    private LevelManager _levelManager;

    private static GameManager _gameManagerControl;

    private void Awake()
    {
  
        _levelManager = FindObjectOfType<LevelManager>();
        /*
         
         //bu alanı kapattım
        //eger eşi varsa yok et bu kalsın siyor şair :)
        if (_gameManagerControl == null)
        {
            _gameManagerControl = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (_gameManagerControl != this)
        {
            Destroy(gameObject);
        }
      */
    }

    private void FixedUpdate()
    {
        LocationOfPlayers();
    }

    public void LocationOfPlayers()
    {
        float positionYPlayer1 = target.position.y;
        float positionYPlayer2= target2.position.y;

        if (positionYPlayer1 < -3)
        {
            playerOneIsAlive = false;
           
        }
        if (positionYPlayer2 < -3)
        {
          
            playerTwoIsAlive = false;
           
        }

        if (!playerOneIsAlive && !playerTwoIsAlive)
        {
            _levelManager.GameOver();
        }
        
        
    }
}
