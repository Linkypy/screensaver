using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pipeGenerator : MonoBehaviour
{
    public float speed = 0.01f;
    public static bool hitWall = false;
    public GameObject pipe; //Prefab Rohr
    public GameObject ball; //Prefab Kugelverbindung


    // Update is called once per frame
    void Update()
    {
        growingPipes();
    }

    private void growingPipes() {
        if (!hitWall) {
            transform.localScale += new Vector3(0.0f, 1.0f * speed, 0.0f);
        }
    }

}
