using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepMusicPlaying : MonoBehaviour
{
    private static KeepMusicPlaying _keepMusicPlayingControl;
    private void Awake()
    {
        //eger eşi varsa yok et bu kalsın siyor şair :)
        if (_keepMusicPlayingControl == null)
        {
            _keepMusicPlayingControl = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (_keepMusicPlayingControl != this)
        {
            Destroy(gameObject);
        }
        
        
    }
}
