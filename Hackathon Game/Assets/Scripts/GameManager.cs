using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour

{
    public GameObject Mines;
    public GameObject Civillians;
    public GameObject Player;
    private List<Vector3> Spawns;
    private bool GameOver = false;
    private bool Spawnable = false;
    public bool civSaved = false;


    // Start is called before the first frame update
    void Start()
    {
        Civillians.GetComponent<CivillianScript>().Player = this.Player;
        Civillians.GetComponent<CivillianScript>().Manager = this;
        Spawns = new List<Vector3>();
       
        SpawnMines(10);
        SpawnCivillians(3);
    }

    // Update is called once per frame
    void Update()
    {
        if (GameOver)
        {
            Debug.Log("Game Over!");
            SceneManager.LoadScene("GameOver");
        }
        GameObject civsLeft = GameObject.FindWithTag("Civillian");
        if (civsLeft == null && civSaved == true)
        {
            SceneManager.LoadScene("Win");
        }
        else if (civsLeft == null && civSaved == false)
        {
            SceneManager.LoadScene("GameOver");
        }
    }


    public void SetGameOver(bool State)
    {
        this.GameOver = State;
    }

    private void SpawnMines(float NumberOfMines)
    {
        UnityEngine.Random.seed = System.DateTime.Now.Millisecond;
        GameObject mine;
        for (int i = 0; i < NumberOfMines; i++)
        {
            bool LocationSpawned = false;
            Vector3 SpawnLocation;
            do
            {
                SpawnLocation = new Vector3(Mathf.Round(UnityEngine.Random.Range(-14.0f, 14.0f))
               + 0.5f, Mathf.Round(UnityEngine.Random.Range(-6.0f, 6.0f)) + 0.5f, -1);
                foreach (Vector3 item in Spawns)
                {
                    if (SpawnLocation == item)
                    {
                        LocationSpawned = true;
                        Spawnable = false;
                        break;
                     
                    }
                    else
                    {
                        Spawnable = true;
                    }
                }
                if (Spawnable)
                {
                    LocationSpawned = false;
                }

            } while (LocationSpawned);
            Spawns.Add(SpawnLocation);
            mine = Instantiate(Mines, SpawnLocation, Quaternion.identity);
        }
    }

    private void SpawnCivillians(float NumberOfCivillians)
    {
        UnityEngine.Random.seed = System.DateTime.Now.Millisecond;
        GameObject civ;
        for (int i = 0; i < NumberOfCivillians; i++)
        {
            bool LocationSpawned = false;
            Vector3 SpawnLocation;
            do
            {
                SpawnLocation = new Vector3(Mathf.Round(UnityEngine.Random.Range(-14.0f, 14.0f))
               + 0.5f, Mathf.Round(UnityEngine.Random.Range(-6.0f, 6.0f)) + 0.5f, -1);
                foreach (Vector3 item in Spawns)
                {
                    if (SpawnLocation == item)
                    {
                        LocationSpawned = true;
                        Spawnable = false;
                        break;
                        
                    }
                    else
                    {
                        Spawnable = true;
                    }
                }
                if (Spawnable)
                {
                    LocationSpawned = false;
                }
                
            } while (LocationSpawned);
            Spawns.Add(SpawnLocation);
            civ = Instantiate(Civillians, SpawnLocation, Quaternion.identity);
        }
    }

    
}