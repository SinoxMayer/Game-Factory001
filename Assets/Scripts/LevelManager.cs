using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelManager : MonoBehaviour
{
    public bool playerNumber = true;
    

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
