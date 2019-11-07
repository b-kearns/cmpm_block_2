using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BisonMovement : MonoBehaviour
{
    // Get players
    public GameObject PLAYER1;
    public GameObject PLAYER2;
    private bool inPlay = true;

    [SerializeField, Range (0, 1)]
    private float strength = 1;

    // Start is called before the first frame update
    void Start()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (this.inPlay)
        {
            Rigidbody rb = GetComponent<Rigidbody>();

            // Apply force from players
            Vector3 force = PlayerForce(PLAYER1);
            rb.velocity += force;
            force = PlayerForce(PLAYER2);
            rb.velocity += force;
        }
        
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
        Vector3 direction = (myPos - pPos).normalized;

        // Figure out how strong the push should be
        playerForce = direction * (strength/dist);

        return playerForce;
    }
}