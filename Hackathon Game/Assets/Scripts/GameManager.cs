using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour

{
    public GameObject Mines;
    public GameObject Civillians;


    private bool GameOver = false;
    // Start is called before the first frame update
    void Start()
    {
        SpawnMines(15);

    }

    // Update is called once per frame
    void Update()
    {
        if (GameOver)
        {
            Debug.Log("Game Over!");
            SceneManager.LoadScene("GameOver");
        }
    }


    public void SetGameOver(bool State)
    {
        this.GameOver = State;
    }

    private void SpawnMines(float NumberOfMines)
    {
        for (int i = 0; i < NumberOfMines; i++)
        {
            Vector3 Pos = new Vector3(Mathf.Round(UnityEngine.Random.Range(-14.0f, 14.0f))+0.5f, Mathf.Round(UnityEngine.Random.Range(-6.0f, 6.0f))+0.5f, -1);
            Instantiate(Mines, Pos, Quaternion.identity);
        }
    }

    private void SpawnCivillians(float NumberOfCivillians)
    {

    }

}
