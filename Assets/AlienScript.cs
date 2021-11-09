using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum State
{
    Rest,
    Charge,
    Retreat,
    GameOver
}

public enum Color
{
    Blue,
    Red,
    Black
}


public class AlienScript : MonoBehaviour
{
    // Start is called before the first frame update
    public void Start()
    {
        setColor();

        
    }

    public State state;
    public Color color;
    public int speed;
    public int maxSpeed;
    public int timer;
    private int upperLimit = 7;
    private int bounces = 0;
    public int bounceLimit;

    public Material materialRed;
    public Material materialBlue;

    // Update is called once per frame
    void FixedUpdate()
    {
        move();
        if (transform.position.z < -9)
        {
            GameObject uiManagerGO = GameObject.Find("UIManager");
            UIManager uimanagerS = uiManagerGO.GetComponent<UIManager>();
            uimanagerS.gameOver();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Red Crate") && color == Color.Red)
        {
            bounces++;

            if (speed < maxSpeed && bounces < bounceLimit)
            {
                speed++;
            }

            GameObject uiManagerGO = GameObject.Find("UIManager");
            UIManager uimanagerS = uiManagerGO.GetComponent<UIManager>();
            uimanagerS.score += 100;

            state = State.Retreat;
            //Debug.Log("retreat");
        }

        else if (other.gameObject.CompareTag("Blue Crate") && color == Color.Blue)
        {
            if (speed < maxSpeed && bounces < bounceLimit)
            {
                speed++;
            }

            GameObject uiManagerGO = GameObject.Find("UIManager");
            UIManager uimanagerS = uiManagerGO.GetComponent<UIManager>();
            uimanagerS.score += 100;

            state = State.Retreat;
            //Debug.Log("retreat blue");
        }

        else if (other.gameObject.CompareTag("Player") )
        {
            if (speed < maxSpeed && bounces < bounceLimit)
            {
                speed++;
            }

            GameObject uiManagerGO = GameObject.Find("UIManager");
            UIManager uimanagerS = uiManagerGO.GetComponent<UIManager>();
            uimanagerS.health -= 1;
            uimanagerS.score += 100;

            state = State.Retreat;
            Debug.Log("player hurt");
        }

        else
        {
            //maybe put a destroy here
        }
    }

    private void move()
    {
        switch (state)
        {
            case State.Charge:
                transform.Translate(Vector3.back * Time.deltaTime * speed);
                break;
            case State.Rest:
                if (timer > 0)
                {
                    timer -= speed;
                }
                else
                {
                    state = State.Charge;
                }
                break;
            case State.Retreat:

                transform.Translate(Vector3.back * Time.deltaTime * -speed);

                if (transform.position.z > upperLimit)
                {
                    setColor();
                    int random = Random.Range(60, 600);
                    timer = random;
                    state = State.Rest;
                }
                break;
            case State.GameOver:
                {

                }
                break;

            default:
                break;
        }
    }

    private void setColor()
    {
        //Debug.Log("color set");

        int random = Random.Range(1, 3);
        Debug.Log(random);

        switch (random)
        {
            case 1:
                GetComponent<MeshRenderer>().material = materialBlue;
                color = Color.Blue;
                //Debug.Log("color set to blue");
                break;

            case 2:
                GetComponent<MeshRenderer>().material = materialRed;
                color = Color.Red;
                //Debug.Log("color set to red");
                break;

            default:
                break;
        }
        
    }
}
