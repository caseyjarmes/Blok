using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public GameObject target;

    public GameObject[] aliens;
    
    // Update is called once per frame
    void FixedUpdate()
    {
        determineTarget();

        transform.position = new Vector3(target.gameObject.transform.position.x, transform.position.y, target.gameObject.transform.position.z);
    }

    void determineTarget()
    {
        foreach (GameObject alien in aliens)
        {
            if (alien.gameObject.transform.position.z < target.gameObject.transform.position.z)
            {
                target = alien;
            }
        }
    }


}
