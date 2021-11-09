using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrateScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    KeyCode latestKey;
    bool movedRecently = false;

    // Update is called once per frame
    void Update()
    {
        //this is probably spaghetti code; this saves what was held down a frame ago so it can move in that direction

        if (Input.GetKeyDown(KeyCode.S))
        { 
            latestKey = KeyCode.S;
            movedRecently = false;
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            latestKey = KeyCode.A;
            movedRecently = false;
        }


        if (Input.GetKeyDown(KeyCode.W))
        {
            latestKey = KeyCode.W;
            movedRecently = false;
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            latestKey = KeyCode.D;
            movedRecently = false;
        }
    }

    void OnTriggerStay(Collider other)
    {
        //Debug.Log("trigger entered");

        if (other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("Blue Crate") || other.gameObject.CompareTag("Red Crate"))
        {
            if (!movedRecently)
            {

                if (latestKey == KeyCode.S)
                {
                    //Debug.Log("crate pushed down");
                    transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - 1);
                }

                if (latestKey == KeyCode.W)
                {
                    //Debug.Log("crate pushed up");
                    transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + 1);
                }

                if (latestKey == KeyCode.A)
                {
                    //Debug.Log("crate pushed left");
                    transform.position = new Vector3(transform.position.x - 1, transform.position.y, transform.position.z);
                }

                if (latestKey == KeyCode.D)
                {
                    //Debug.Log("crate pushed right");
                    transform.position = new Vector3(transform.position.x + 1, transform.position.y, transform.position.z);
                }

                movedRecently = true;
            }
        }


    }
}
