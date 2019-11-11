using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BisonMovement : MonoBehaviour
{
    // Get players
    public GameObject Player1;
    public GameObject Player2;
    public GameObject Herd;
    private bool inPlay = true;
    public Rigidbody rb;

    [SerializeField, Range(0, 10)]
    private float playerStrength = 0.75f;
    [SerializeField, Range(0, 10)]
    private float bisonStrength = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Player1 = GameObject.Find("PlayerRed");
        Player2 = GameObject.Find("PlayerBlue");
        Herd = GameObject.Find("Bison Herd");
    }

    // Update is called once per frame
    void Update()
    {
        // Check out of bounds
        if (transform.position.magnitude > 10)
        {
            Ragdoll();
        }

        if (this.inPlay)
        {
            // Apply force from players
            Vector3 force = PlayerForce(Player1);
            rb.AddForce(force, ForceMode.Impulse);
            force = PlayerForce(Player2);
            rb.AddForce(force, ForceMode.Impulse);

            // Apply force from bisons
            // For each bison
            for (int i = 0; i < Herd.transform.childCount; i++)
            {
                force = BisonForce(i);
                //rb.AddForce(force, ForceMode.Impulse);
            }
        }
        
    }

    // Function to calculate force bison are exerting on bison
    private Vector3 BisonForce(int index)
    {
        Vector3 bisonForce; // returns this

        // Get the positions
        Vector3 bPos = Herd.transform.GetChild(index).position;
        Vector3 myPos = transform.position;

        // Get distance and direction to bison
        float dist = (myPos - bPos).magnitude;
        if (dist > 1.5)
        {
            return Vector3.zero; // Exit if bison is far away
        }

        Vector3 direction = (myPos - bPos).normalized;

        // Figure out how strong the push should be
        bisonForce = direction * (bisonStrength/dist);
        
        bisonForce.y = 0;
        return bisonForce;
    }

    // Function to calculate force player is exerting on bison
    private Vector3 PlayerForce(GameObject player)
    {
        Vector3 playerForce; // returns this

        // Get the positions
        Vector3 myPos = transform.position;
        Vector3 pPos = player.transform.position;

        // Get distance and direction to players
        float dist = (myPos - pPos).magnitude;
        if (dist > 5)
        {
            return Vector3.zero; // Exit if player is far away
        }

        Vector3 direction = (myPos - pPos).normalized;

        // Figure out how strong the push should be
        playerForce = direction * (playerStrength/dist);

        playerForce.y = 0;
        return playerForce;
    }

    // Falls out of play
    void Ragdoll()
    {
        //rb.isKinematic = false;
        rb.freezeRotation = false;
        rb.angularDrag = 0;
        rb.drag = 0;
        rb.angularVelocity = new Vector3(Random.value, Random.value, Random.value);
        this.inPlay = false;
    }
}