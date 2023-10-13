using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClickTarget : MonoBehaviour
{
    public GameObject targetPrefab;

    public Vector3 center;
    public Vector3 size;
    public Camera camera;
    private SpriteRenderer rend;
    private Color originalColor;

    // Start is called before the first frame update
    void Start()
    {
        camera = Camera.main;
        //rend = this.gameObject.GetComponent<SpriteRenderer>();
        Vector3 pos = center + randPosition();
        transform.position = pos;

        rend = this.gameObject.GetComponent<SpriteRenderer>();
        originalColor = rend.color;
        StartCoroutine(delayFade(100)); //set to 0 to make sprite invisible

    }

    // Update is called once per frame
    void Update()
    {
        //Raycast & Hit2D Detecting
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
                        rend.color = originalColor;
                        SpawnNextCircle();
                    }
                
                }
            }
        }

    }

    void SpawnNextCircle()
    {
        moveJJ();

        //Random Spawning in dedicated position
        /*Vector3 pos = center + new Vector3(Random.Range(-size.x / 2, size.x / 2),
                                           Random.Range(-size.y / 2, size.y / 2),
                                           0);
        
        Instantiate(targetPrefab, pos, Quaternion.identity);
        Destroy(gameObject);*/

        // StartCoroutine(delayDestroy(2));

        

    }

    /*IEnumerator delayDestroy(float s)
    {
        yield return new WaitForSeconds(s);
        Destroy(gameObject);
    }
    */

    IEnumerator delayFade(float s)
    {
        yield return new WaitForSeconds(s);
        Color transparentColor = new Color(rend.color.r, rend.color.g, rend.color.b, 0f);
        rend.color = transparentColor;
    }

    void moveJJ() {
        targetPrefab.transform.position = center + randPosition();
    }

    Vector3 randPosition() {
        float height = camera.orthographicSize;
        float width = camera.aspect * height;
        double x = Random.Range(-width, width);
        double y = Random.Range(-height, height);
        Debug.Log("Height: " + height + "\nWidth :" + width);
        Debug.Log("JJ Height: " + y + "\nJJ Width :" + x);
        //double x = Random.Range(-size.x / 2, size.x / 2);
        //double y = Random.Range(-size.y / 2, size.y / 2);
        
        

        /*if (x > (width - 2)) {
            x = (width - 2);
        } else if (x < (-width + 2)) {
            x = (-width + 2);
        } else if (y > (height - 3)) {
            y = (height - 3);
        } else if (y < (-height + 3)) {
            y = (-height + 3);
        }*/

        return new Vector3((float) x, (float) y, 0);
    }

    // private void OnMouseDown()
    // {
    //     SceneManager.LoadScene("WinScreen");
    // }
}
