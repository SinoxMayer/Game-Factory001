using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadNextLvl : MonoBehaviour
{
    private LevelManager _levelManager;
    private bool _isFirstAppleEaten = false;
    private ScoreManager _scoreManager;
    private Collectible _collectible;

    private void Awake()
    {
        _levelManager = FindObjectOfType<LevelManager>();
        _scoreManager = FindObjectOfType<ScoreManager>();
        _collectible  = FindObjectOfType<Collectible>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerController>() == null) return;
        if (_isFirstAppleEaten != true)
        { 
            _collectible.Collect();
            InvisibleAndGone();
            _isFirstAppleEaten = true;
            //build indexte şuankinden sonra gelen ekranı alacak .
            StartCoroutine(NextLvlLastStop());
        }
        else
        {   _collectible.Collect();
            InvisibleAndGone();
            _scoreManager.AddScore(5);
        }
    }

    private void InvisibleAndGone()
    {
        
        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<BoxCollider>().enabled = false;
        
    }

    private IEnumerator NextLvlLastStop()
    {
        
        yield return new WaitForSeconds(5f);
        _levelManager.NextLevel();
        
    }
}
