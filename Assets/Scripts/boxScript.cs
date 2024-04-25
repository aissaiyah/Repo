using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boxScript : MonoBehaviour
{
    public BoxCollider2D laser;
    // Start is called before the first frame update
    void Start()
    {
        Physics2D.IgnoreCollision(laser.GetComponent<Collider2D>(), GetComponent<Collider2D>());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
