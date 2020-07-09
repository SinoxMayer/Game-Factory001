using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private int _score;

    public void AddScore(int amount)
    {
        _score += amount;
        Debug.Log(_score);
    }
}
