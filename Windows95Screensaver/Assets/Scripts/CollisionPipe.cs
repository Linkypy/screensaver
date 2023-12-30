using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionPipe : MonoBehaviour
{
   


    void OnCollisionEnter(UnityEngine.Collision collision)
    {

        if (collision.gameObject.CompareTag("Wall"))
        {
            pipeGenerator.hitWall = true; 
        }
    }
}
