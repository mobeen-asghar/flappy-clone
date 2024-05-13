using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BirdScript : MonoBehaviour
{


    public LogicScript logic;
    public Rigidbody2D myRigidbody;
    public float flapStrength;
    public bool birdIsAlive = true;

    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();

    }

    // Update is called once per frame
    void Update()
    {

        if (transform.position.y < -17 || transform.position.y > 17)
        {
            exitGame();
        }

        if (Input.GetKeyDown(KeyCode.Space) && birdIsAlive)
        {
            myRigidbody.velocity = Vector2.up * flapStrength;
        }

    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        exitGame();

    }

    public void exitGame()
    {
        birdIsAlive = false;
        logic.gameOver();
    }
}
