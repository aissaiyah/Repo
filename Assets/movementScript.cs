using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movementScript : MonoBehaviour
{
    public bool canMove;
    public BoxCollider2D bc;
   


    // Start is called before the first frame update
    void Start()
    {
        bc = this.GetComponent<BoxCollider2D>();
        canMove = true;
    }

    // Update is called once per frame
    void Update()
    {

        if(canMove == true)
        {
            if (Input.GetKeyDown(KeyCode.D))
            {
 
                transform.Translate(1, 0, 0);

            }
            if (Input.GetKeyDown(KeyCode.A))
            {
        
                transform.Translate(-1, 0, 0);
            }
            if (Input.GetKeyDown(KeyCode.W))
            {
           
                transform.Translate(0, 1, 0);
            }
            if (Input.GetKeyDown(KeyCode.S))
            {
              
                transform.Translate(0, -1, 0);
            }
        }
  

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
