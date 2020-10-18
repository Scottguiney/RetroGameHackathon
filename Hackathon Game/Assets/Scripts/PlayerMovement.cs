using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 10;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 CurrentPos = this.transform.position;
        if (Input.GetKey("a"))
        {
            this.transform.position = new Vector2(CurrentPos.x - moveSpeed * Time.deltaTime, CurrentPos.y);
        }

        if (Input.GetKey("d"))
        {
            this.transform.position = new Vector2(CurrentPos.x + moveSpeed * Time.deltaTime, CurrentPos.y);
        }

        if (Input.GetKey("w"))
        {
            this.transform.position = new Vector2(CurrentPos.x, CurrentPos.y + moveSpeed * Time.deltaTime);
        }

        if (Input.GetKey("s"))
        {
            this.transform.position = new Vector2(CurrentPos.x, CurrentPos.y - moveSpeed * Time.deltaTime);
        }
    }
}
