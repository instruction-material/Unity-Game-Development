using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Rigidbody playerBody = gameObject.GetComponent<Rigidbody>();
        float horizontalInput = Input.GetAxis("Horizontal");
        playerBody.velocity = new Vector3(horizontalInput* 5,playerBody.velocity.y,0);
    }
}
