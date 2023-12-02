using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Drag : MonoBehaviour
{

    float startPosX; // strat position at x axis
    float startPosY; // strat position at y axis
    bool isBeingHeld; //determine if object is being held

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (isBeingHeld) // if object is being held
        {
            Vector2 mousePos; // create a vector 2 called mousePos
            mousePos = Input.mousePosition; // change value of mousePos
            mousePos = Camera.main.ScreenToWorldPoint(mousePos); // change value of mousePos
            gameObject.transform.localPosition = new Vector2(mousePos.x, mousePos.y); // change position of object
        }
    }

    void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePos;
            mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);

            isBeingHeld = true;
        }
    }

    void OnMouseUp()
    {
        isBeingHeld = false;
    }

    //function for collision
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Goal") // if player hits goal
        {
            SceneManager.LoadScene("EndScene"); // restart game
        }
    }
}
