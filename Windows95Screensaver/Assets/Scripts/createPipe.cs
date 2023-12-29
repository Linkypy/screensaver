using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class createPipe : MonoBehaviour
{
    public float speedMovement = 5;
    public float speedSteer = 150;
    public float speedBody = 5;

    public GameObject pipe; //Prefab Rohr
    public GameObject ball; //Prefab Kugelverbindung
    private List<GameObject> pipeSegments = new List<GameObject>();
    private List<Vector3> PositionHistory = new List<Vector3>();

    public int Gap = 120;

    //public GameObject magicBall;
   // Rigidbody rb;

    /*void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }*/

    // Start is called before the first frame update
    void Start()
    {
        //InvokeRepeating("SpawnIt", 1f, 5f); //alle 5s kommt ein neuer MagicBall dazu
        Cursor.lockState = CursorLockMode.Confined;       

    }

    // Update is called once per frame
    void Update()
    {
        //vorwärts bewegen
        transform.position += transform.right * speedMovement * Time.deltaTime;

        //Steuerung, nach rechts und links rotieren
        float directionSteer = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.up * directionSteer * speedSteer * Time.deltaTime);

        //Positionen speichern
        PositionHistory.Insert(0, transform.position);

        //Rohrsegmente positionieren/bewegen an vorherige Position des Rohrs anhängen
        int index = 0;
        foreach (var p in pipeSegments)
        {
            Vector3 point = PositionHistory[Mathf.Clamp(index * Gap, 0, PositionHistory.Count - 1)];

            Vector3 moveDirection = point - p.transform.position;
            p.transform.position += moveDirection * speedBody * Time.deltaTime;

            p.transform.LookAt(point);

            index++;
        }
    }

    //Teile vom Rohr hinzufügen
    public void PipeAddition()
    {
        GameObject segment = Instantiate(pipe);
        pipeSegments.Add(segment); //Prefab zur Liste beifügen
    }

    /*void SpawnIt()
    {
        //zufällige Positionierung des Spawnpoints für die MagicBalls
        float randomX = Random.Range(-9, 9);
        float randomZ = Random.Range(-9, 9);

        Vector3 randomPos = new Vector3(randomX, 0f, randomZ);
        Instantiate(magicBall, randomPos, Quaternion.identity); //MagicBall wird erzeugt
    }*/

    //falls Rohr mit Wand kollidiert
    //wird sie wieder auf Startpunkt positioniert
    void OnCollisionEnter(UnityEngine.Collision collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            //rb.velocity = Vector3.zero;
            transform.position = Vector3.zero;
            Debug.Log("Hit it");
        }
    }
}
