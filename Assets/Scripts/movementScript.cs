using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movementScript : MonoBehaviour
{
   
    void Update()
    {
        int[] direction=new int[] {0,0};

        if (Input.GetKeyDown(KeyCode.D))      direction = new int[] { 1, 0 };
        else if (Input.GetKeyDown(KeyCode.A)) direction = new int[] { -1, 0 };
        else if (Input.GetKeyDown(KeyCode.W)) direction = new int[] { 0, 1 };
        else if (Input.GetKeyDown(KeyCode.S)) direction = new int[] { 0, -1 };

        transform.Translate(direction[0], direction[1], 0);
        Collider2D collision = Physics2D.OverlapCircle(transform.position, .2f);

        if (collision != null)
        {
            if (collision.gameObject.tag == "wall" || collision.gameObject.tag == "player" || collision.gameObject.tag == "laser") transform.Translate(-1 * direction[0], -1 * direction[1], 0);
            else if (collision.gameObject.tag == "box")
            {
                collision.gameObject.transform.Translate(new Vector2(direction[0], direction[1]));
                Collider2D collision2 = Physics2D.OverlapCircle(collision.gameObject.transform.position, .2f);
                if (collision2!= null)
                {
                    if (collision2.gameObject.tag == "wall" || collision2.gameObject.tag == "player" || collision2.gameObject.tag == "box" || collision2.gameObject.tag == "laser")
                    {
                        transform.Translate(-1 * direction[0], -1 * direction[1], 0);
                        collision.gameObject.transform.Translate(new Vector2(-1 * direction[0], -1 * direction[1]));
                    }
                }
            }

        }
    }
}
