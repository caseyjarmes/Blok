using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Vector3 newPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //Movement
        if (Input.GetKeyDown(KeyCode.W))
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + 1);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - 1);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            transform.position = new Vector3(transform.position.x + 1, transform.position.y, transform.position.z);
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            transform.position = new Vector3(transform.position.x - 1, transform.position.y, transform.position.z);
        }
    }


    //I did attempt to implement the TestPhysics1 code, but wasn't quite sure how it worked and decided to go with the already working code I had

    //public float distance;
    //Vector3 direction;

    //private void OnTriggerEnter(Collider other)
    //{
    //    direction = new Vector3(transform.position.x, transform.position.y, transform.position.z);
    //    other.transform.Translate(-direction * distance);
    //}


}
