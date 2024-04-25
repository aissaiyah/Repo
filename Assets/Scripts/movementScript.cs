using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class movementScript : MonoBehaviour
{
   
    void Update()
    {
        int[] direction=new int[] {0,0};//direction the player moves {x,y}
        if      (Input.GetKeyDown(KeyCode.D)) direction = new int[] { 1, 0 };
        else if (Input.GetKeyDown(KeyCode.A)) direction = new int[] { -1, 0 };
        else if (Input.GetKeyDown(KeyCode.W)) direction = new int[] { 0, 1 };
        else if (Input.GetKeyDown(KeyCode.S)) direction = new int[] { 0, -1 };
        if(Input.GetKeyDown(KeyCode.R)) SceneManager.LoadScene(SceneManager.GetActiveScene().name);//Restart level
      
        transform.Translate(direction[0], direction[1], 0);//move player
        Collider2D[] collisionList = Physics2D.OverlapCircleAll(transform.position, .2f);//create a collision circle to check if they moves into something
        
        if (collisionList.Length > 0)//if there is an object overlapping with the collision circle
        {
            for (int i = 0; i < collisionList.Length; i++)
            {
                if (collisionList[i].gameObject.tag == "solid" || collisionList[i].gameObject.tag == "player") transform.Translate(-1 * direction[0], -1 * direction[1], 0);//if you collide with a wall or other player you move back to where you where
                else if (collisionList[i].gameObject.tag == "laser") SceneManager.LoadScene(SceneManager.GetActiveScene().name);//if you hit a laser you die and the level restarts
                else if (collisionList[i].gameObject.tag == "box")//if its a box then you can push it
                {
                    collisionList[i].gameObject.transform.Translate(new Vector2(direction[0], direction[1]));//move box
                    Collider2D[] collisionList2 = Physics2D.OverlapCircleAll(collisionList[i].gameObject.transform.position, .2f);//check collision for box
                    if (collisionList2.Length > 0)
                    {
                        for (int i2 = 0; i2 < collisionList.Length; i2++) 
                        {
                            if (collisionList2[i2].gameObject.tag == "solid" || collisionList2[i2].gameObject.tag == "player" || collisionList2[i2].gameObject.tag == "box")//if it hits something it and the player moves back
                            {
                                transform.Translate(-1 * direction[0], -1 * direction[1], 0);
                                collisionList[i].gameObject.transform.Translate(new Vector2(-1 * direction[0], -1 * direction[1]));
                            }
                        }
                    }
                }
            }
        }
    }
}
