using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] GameObject footCheck;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Rigidbody playerBody = gameObject.GetComponent<Rigidbody>();

        float horizontalInput = Input.GetAxis("Horizontal");

        playerBody.velocity = new Vector3(horizontalInput * 5, playerBody.velocity.y, 0);

        if (Input.GetKeyDown(KeyCode.Space) && Physics.OverlapSphere(footCheck.transform.position, 0.1f).Length > 1)
        {
            playerBody.AddForce(Vector3.up * 5, ForceMode.VelocityChange);
        }

        //If the player falls too low, reset them back to the start
        if (gameObject.transform.position.y < -8)
        {
            gameObject.transform.position = new Vector3(0, 3, 0);
        }
    }
}
