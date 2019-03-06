using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : TacticsMove 
{

    public int hp = 10;
    public int force = 1;

	// Use this for initialization
	void Start () 
	{
        Init();
	}
	
	// Update is called once per frame
	void Update () 
	{
        Debug.DrawRay(transform.position, transform.forward);

        if (!turn)
        {
            return;
        }

        if (!moving)
        {
            FindSelectableTiles();
            CheckMouse();
            Atack();
        }
        else
        {
            Move();
        }
	}

    void CheckMouse()
    {
        if (Input.GetMouseButtonUp(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.tag == "Tile")
                {
                    Tile t = hit.collider.GetComponent<Tile>();

                    if (t.selectable)
                    {
                        MoveToTile(t);
                    }
                }
            }
        }
    }

    void Atack()
    {
        if (Input.GetMouseButtonUp(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.tag == "Player")
                {
                    PlayerMove p = hit.collider.GetComponent<PlayerMove>();

                    foreach (Tile t in currentTile.adjacencyList)
                    {
                        Debug.Log(t);
                        Debug.Log(p.currentTile);

                        if (t == p.currentTile)
                        {
                            p.Damage(force);
                            Debug.Log(hp);
                        }
                    }

                }
            }
        }
    }

    void Damage(int hits)
    {
        if (hp > 0)
            hp -= hits;
        else if (hp >= 0)
            //change to destroy
            gameObject.SetActive(false);
    }
}
