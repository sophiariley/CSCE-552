using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeoClickTarget : MonoBehaviour
{
    public GameObject JJ;

    public Vector3 center = new Vector3(0,0,0);
    public Vector3 size;


    // Start is called before the first frame update
    void Start()
    {
        moveJJ();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

        RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);

        //Checking if what you hit is available
        if (hit.collider != null)
        {
            if (hit.collider)
            {
                //If the hit targets the tag Circle
                if (hit.collider.tag == "target")
                {
                    //When pressing the left mouse button
                    if (Input.GetMouseButtonDown(0))
                    {
                        moveJJ();
                    }
                }
            }
        }
    }

    void moveJJ() {
        JJ.transform.position = center + randPosition();
    }

    Vector3 randPosition() {
        return new Vector3(Random.Range(-size.x / 2, size.x / 2), Random.Range(-size.y / 2, size.y / 2), 0);
    }
}
