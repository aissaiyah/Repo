using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movementScript : MonoBehaviour
{
    public bool canMove;
    public BoxCollider2D bc;
    private int[] movement = new int[2];
    private bool move;



    // Start is called before the first frame update
    void Start()
    {
        bc = this.GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        move = false;

        if (Input.GetKeyDown(KeyCode.D))
        {
            move = true;
            movement = new int[] { 1, 0 };
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            move = true;
            movement = new int[] { -1, 0 };
        }
        else if (Input.GetKeyDown(KeyCode.W))
        {
            move = true;
            movement = new int[] { 0, 1 };
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            move = true;
            movement = new int[] { 0, -1 };
        }

        if(move) transform.Translate(movement[0], movement[1], 0);

    }

    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "wall")
        {
            transform.Translate(-1*movement[0], -1*movement[1], 0);
            print(movement[0]+" " + movement[1]);
        }
    }
}
