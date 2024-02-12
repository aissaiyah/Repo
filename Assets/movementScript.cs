using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movementScript : MonoBehaviour
{
    public bool canMove;
    public BoxCollider2D bc;
    public int[] movement = new int[2];



    // Start is called before the first frame update
    void Start()
    {
        bc = this.GetComponent<BoxCollider2D>();
        canMove = true;
    }

    // Update is called once per frame
    void Update()
    {
        movement = new int[] {0,0};

        if (Input.GetKeyDown(KeyCode.D))
        {
            movement = new int[] { 1, 0 };
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            movement = new int[] { -1, 0 };
        }
        else if (Input.GetKeyDown(KeyCode.W))
        {
            movement = new int[] { 0, 1 };
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            movement = new int[] { 0, -1 };
        }

        if (canMove) transform.Translate(movement[0], movement[1], 0);

    }

    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "wall")
        {
            canMove = false;
            Debug.Log("Hello");
        }
    }
    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "wall")
        {
            canMove = true;
            Debug.Log("Hello");
        }
    }
}
