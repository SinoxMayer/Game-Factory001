using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelManager : MonoBehaviour
{
    public bool playerNumber = true;
    private GameManager _gameManager;
    private ScoreManager _scoreManager;


    private void Awake()
    {
        _scoreManager = FindObjectOfType<ScoreManager>();
        _gameManager = FindObjectOfType<GameManager>();
    }

    private void ChangeScene()
    {

        StartCoroutine(ChangeSceneCoroutine());
    }
    
    private IEnumerator ChangeSceneCoroutine()
    {
        
        yield return  new  WaitForSeconds(.2f);

        LoadScene(GetActiveScene());
    }

    public void NextLevel()
    {
        if (_gameManager.playerOneIsAlive && _gameManager.playerTwoIsAlive)
        {
            _scoreManager.AddScore(+25);
        }
        LoadScene(GetActiveScene()+ 1);
    }

    private void LoadScene(int buildIndex)
    {
        SceneManager.LoadScene(buildIndex);
    }

    private int GetActiveScene()
    {
        return SceneManager.GetActiveScene().buildIndex;
    }

    public void GameOver()
    {
        
        //GAmeover state i değiştirebilirm.
        ChangeScene();
       
        
    }
}
