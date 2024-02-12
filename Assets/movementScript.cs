using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movementScript : MonoBehaviour
{
    public bool canMoveLeft;
    public bool canMoveRight;
    public bool canMoveUp;
    public bool canMoveDown;
    public BoxCollider2D bc;
    public int[] movement = new int[2];



    // Start is called before the first frame update
    void Start()
    {
        bc = this.GetComponent<BoxCollider2D>();
        canMoveUp = true;
        canMoveDown = true;
        canMoveLeft = true;
        canMoveRight = true;
    }

    // Update is called once per frame
    void Update()
    {
        movement = new int[] {0,0};

        if (Input.GetKeyDown(KeyCode.D) && canMoveRight == true)
        {
            movement = new int[] { 1, 0 };
            transform.Translate(movement[0], movement[1], 0);
        }
        else if (Input.GetKeyDown(KeyCode.A) && canMoveLeft == true)
        {
            movement = new int[] { -1, 0 };
            transform.Translate(movement[0], movement[1], 0);
        }
        else if (Input.GetKeyDown(KeyCode.W) && canMoveUp == true)
        {
            movement = new int[] { 0, 1 };
            transform.Translate(movement[0], movement[1], 0);
        }
        else if (Input.GetKeyDown(KeyCode.S) && canMoveDown == true)
        {
            movement = new int[] { 0, -1 };
            transform.Translate(movement[0], movement[1], 0);
        }

        

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "LeftWall")
        {
            canMoveLeft = false;
            Debug.Log("Left");
        }
        if (collision.gameObject.tag == "RightWall")
        {
            canMoveRight = false;
            Debug.Log("Right");
        }
        if (collision.gameObject.tag == "UpWall")
        {
            canMoveUp = false;
            Debug.Log("Up ");
        }
        if (collision.gameObject.tag == "DownWall")
        {
            canMoveDown = false;
            Debug.Log("Down");
        }
    }
    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "LeftWall")
        {
            canMoveLeft = true;
            Debug.Log("Left");
        }
        if (collision.gameObject.tag == "RightWall")
        {
            canMoveRight = true;
            Debug.Log("Right");
        }
        if (collision.gameObject.tag == "UpWall")
        {
            canMoveUp = true;
            Debug.Log("Up ");
        }
        if (collision.gameObject.tag == "DownWall")
        {
            canMoveDown = true;
            Debug.Log("Down");
        }
    }
}
