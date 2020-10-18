using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour

{

    private bool GameOver = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameOver)
        {
            Debug.Log("Game Over!");
        }
    }


    public void SetGameOver(bool State)
    {
        this.GameOver = State;
    }

}
