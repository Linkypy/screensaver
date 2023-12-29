using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionPipe : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(UnityEngine.Collision collision)
    {

        if (collision.gameObject.CompareTag("Wall"))
        {
            Debug.Log("Hit it");
            pipeGenerator.hitWall = true;

        }
    }
}
