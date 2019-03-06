using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundBase : MonoBehaviour
{
    void Start()
    {
        CheckTile();
    }

    void CheckTile()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position,Vector3.down, out hit))
        {   
            if (hit.collider.tag == "Tile")
            {
                Tile t = hit.collider.GetComponent<Tile>();

                t.walkable = false;
            }
        }
    }

}
