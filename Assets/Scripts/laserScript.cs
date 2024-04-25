using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class laserScript : MonoBehaviour
{
    public LayerMask colliderLayer;
    void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.right, 100f, colliderLayer);
        transform.localScale = new Vector3(hit.distance, transform.localScale.y, 1);
    }
}