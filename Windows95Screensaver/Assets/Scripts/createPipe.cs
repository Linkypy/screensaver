using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class createPipe : MonoBehaviour
{
    public GameObject pipe; // pipe prefab
    public int maxSegments = 100; // max amount of segments

    private List<GameObject> pipeSegments = new List<GameObject>(); // list of created pipe segments
    private Vector3 currentPos; // current Position

    void Start()
    {
        currentPos = transform.position; // starting position of pipe
        GeneratePipes();
    }

    void GeneratePipes()
    {
        for (int i = 0; i < maxSegments; i++)
        {
            Vector3 nextDirection = GetRandomDirection(); // Zufällige Richtung wählen
            Vector3 nextPos = currentPos + nextDirection;

            // Prüfen, ob die neue Position bereits ein anderes Rohrsegment hat oder außerhalb des Raums liegt
            if (!HasPipeAtPosition(nextPos) && IsWithinRoom(nextPos))
            {
                GameObject newPipe = Instantiate(pipe, nextPos, Quaternion.identity);
                newPipe.GetComponent<Renderer>().material.color = GetRandomColor(); // Zufällige Farbe setzen

                pipeSegments.Add(newPipe); // Rohrsegment zur Liste hinzufügen
                currentPos = nextPos; // Aktuelle Position aktualisieren
            }
            else
            {
                // change direction if dead end got detected
                nextDirection = GetRandomDirection();
            }
        }
    }

    Vector3 GetRandomDirection()
    {
        return Vector3.forward; // still to do: implement random direction
    }

    bool HasPipeAtPosition(Vector3 position)
    {
        foreach (GameObject segment in pipeSegments)
        {
            if (Vector3.Distance(segment.transform.position, position) < 0.1f)
            {
                return true;
            }
        }
        return false;
    }

    bool IsWithinRoom(Vector3 position)
    {
        return true; 
    }

    Color GetRandomColor()
    {
        return new Color(Random.value, Random.value, Random.value); // generate random colors for pipes
    }
}
