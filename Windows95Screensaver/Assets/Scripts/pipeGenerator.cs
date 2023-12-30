using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pipeGenerator : MonoBehaviour
{
    public float speed = 0.01f;
    public static bool hitWall = false;
    public GameObject newPipe; //Prefab Rohr mit empty Gameobject
    public GameObject pipe; //einzelnes Rohr
    public GameObject sphere; //Prefab Kugelverbindung
    public Transform SpawnPos;
    public Vector3[] rotations = new Vector3[]
        {
            new Vector3(90, 0, 0),
            new Vector3(-90, 0, 0),
            new Vector3(0, 0, 90),
            new Vector3(0, 0, -90),
            new Vector3(-90, 0, 0),
            new Vector3(0, 0, 0)
        };

    // Update is called once per frame
    void Update()
    {
        growingPipes();
    }

    void SpawnNewPipe()
    {
        Instantiate(sphere, SpawnPos.position, SpawnPos.rotation);
        Instantiate(newPipe, SpawnPos.position, Quaternion.Euler(rotations[Random.Range(0, rotations.Length - 1)]));
    }

    void randomPipeColor() 
    {
        Color color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
        pipe.GetComponent<Renderer>().material.color = color;
        sphere.GetComponent<Renderer>().material.color = color;
    }


    void growingPipes() {
        transform.localScale += new Vector3(0.0f, 1.0f * speed, 0.0f);
    }

}
