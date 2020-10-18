using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineScript : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject gameManager;
    GameManager manager;
    
    void Start()
    {
        gameManager = GameObject.Find("GameManager");
        manager = gameManager.GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(collision.gameObject);
            Destroy(this);
            manager.SetGameOver(true);
        }
        else if (collision.gameObject.tag == "Civillian")
        {
            Destroy(collision.gameObject);
        }
        Destroy(this);
    }
}
