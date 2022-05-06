using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AdventureScript : MonoBehaviour
{

    public Vector3 mousePos;
    public Camera mainCam;
    public GameObject player;
    public float speed = 1;
    private bool moving = false;
    private bool toItem = false;
    private Vector3 mouseWorldPos;
    private Vector2 rayPos;
    private Vector2 targetPos;
    private GameObject itemRef;
    private RaycastHit2D hit;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Maus Gedrückt?
        if(Input.GetMouseButtonDown(0))
        {
            //Mausposition
            mousePos = Input.mousePosition;
            //Screen zu World Position
            mouseWorldPos = mainCam.ScreenToWorldPoint(mousePos);

            //Raycast2D
            rayPos = new Vector2(mouseWorldPos.x, mouseWorldPos.y);
            hit = Physics2D.Raycast(rayPos, Vector2.zero);
            //Collider per Raycast getroffen?
            if(hit.collider != null)
            {
                //Wenn Tag == Ground soll der Spieler bewegt werden
                if(hit.collider.gameObject.tag == "Ground")
                {
                    targetPos = hit.point;
                    moving = true;
                    flipCheck();
                }
                else if(hit.collider.gameObject.tag == "Item")
                {
                    targetPos = hit.point;
                    moving = true;
                    itemRef = hit.collider.gameObject;
                    toItem = true;
                    flipCheck();
                }
                else if(hit.collider.gameObject.tag == "Gate")
                {
                    print(hit.collider.gameObject.GetComponent<GateScript>().levelId);
                    SceneManager.LoadScene(hit.collider.gameObject.GetComponent<GateScript>().levelId);
                }
            }
            else
            {
                print("Kein Treffer");
            }
        }
    }

    private void FixedUpdate()
    {
        if (moving)
        {
            //Spieler bewegen
            player.transform.position = Vector3.MoveTowards(player.transform.position, targetPos, speed);
            if(player.transform.position.x == targetPos.x && player.transform.position.y == targetPos.y)
            {
                //Ziel erreicht; Bewegung beenden
                moving = false;
            }
            if (toItem)
            {
                if (player.transform.position.x > itemRef.transform.position.x - 1 && player.transform.position.x < itemRef.transform.position.x + 1 && player.transform.position.y > itemRef.transform.position.y - 1 && player.transform.position.y < itemRef.transform.position.y + 1)
                {
                    itemRef.SetActive(false);
                    itemRef = null;
                    toItem = false;
                }
            }
        }
    }

    private void flipCheck()
    {
        if(player.transform.position.x > targetPos.x)
        {
            //Flippen
            player.GetComponent<SpriteRenderer>().flipX = true;
        }
        else if (player.transform.position.x < targetPos.x)
        {
            //Flippen
            player.GetComponent<SpriteRenderer>().flipX = false;
        }
    }
}
