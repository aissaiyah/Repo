using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class laserScript : MonoBehaviour
{
    public LayerMask hitRead;
    public Vector3 dir;
    public float angle;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        angle =  Mathf.Deg2Rad;
        Vector2 dir = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));


        RaycastHit2D hit = Physics2D.Raycast(transform.position, dir, 100f, hitRead);
        transform.localScale = new Vector3(hit.distance, transform.localScale.y, 1);
        
        if (hit.collider == null)
        {
           
            transform.localScale = new Vector3(100f, transform.localScale.y, 1);
            return;

        }
        if(hit.collider.gameObject.tag == "laser")
        {
            Debug.Log("lvl complete!");
        }

    }
}
