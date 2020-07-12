using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadNextLvl : MonoBehaviour
{
    private LevelManager _levelManager;




    private void Awake()
    {
        _levelManager = FindObjectOfType<LevelManager>();

    }

    

   
    public IEnumerator NextLvlLastStop()
    {
        
        yield return new WaitForSeconds(3f);
        _levelManager.playerNumber = true;
        _levelManager.NextLevel();
        
    }
}
