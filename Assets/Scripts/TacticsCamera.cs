using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TacticsCamera : MonoBehaviour 
{
    public GameObject bound;
    private bool insertBound = false;
    private bool turnCam = false;

    private void Update()
    {
        if (Input.GetMouseButtonUp(0) &&  insertBound)
        {
            InsertBound();
        }
    }

    private void InsertBound()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.tag == "Tile")
            {
                Tile t = hit.collider.GetComponent<Tile>();
                Vector3 pos = new Vector3(t.transform.position.x, 1, t.transform.position.z);
                Instantiate(bound, pos, Quaternion.identity);
                SpawBound();
            }
        }
    }

    public void SpawBound()
    {
        insertBound = !insertBound;
    }

    public void RotateLeft()
    {
        transform.Rotate(Vector3.up, 180, Space.Self);
    }

    public void RotateRight()
    {
        transform.Rotate(Vector3.up, -180, Space.Self);
    }

    public void RotateRound()
    {
        transform.Rotate(Vector3.up, 180, Space.Self);
        if(turnCam)
            transform.position = new Vector3(0, 11, 16.2f);
        else
            transform.position = new Vector3(0, 11, -8.1f);

        turnCam = !turnCam;
    }


}
