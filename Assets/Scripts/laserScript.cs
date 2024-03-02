using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class laserScript : MonoBehaviour
{
    public LayerMask colliderLayer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.right, 100f, colliderLayer);
        transform.localScale = new Vector3(hit.distance, transform.localScale.y, 1);

        if(hit.collider.gameObject.tag == "laser")
        {
            Debug.Log("lvl complete!");
        }

    }
}