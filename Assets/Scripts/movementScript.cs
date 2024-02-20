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
            if (collision.gameObject.tag == "Wall" || collision.gameObject.tag == "Player") transform.Translate(-1 * direction[0], -1 * direction[1], 0);
            else if (collision.gameObject.tag == "Box")
            {
                collision.gameObject.transform.Translate(new Vector2(direction[0], direction[1]));
                if (Physics2D.OverlapCircle(collision.gameObject.transform.position, .2f) != null)
                {
                    transform.Translate(-1 * direction[0], -1 * direction[1], 0);
                    collision.gameObject.transform.Translate(new Vector2(-1*direction[0], -1*direction[1]));
                }
            }
        }
    }
}
