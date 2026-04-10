using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //Public score and candy variable for GameManager to access
    public int candy;
    public bool canMove;

    [SerializeField] GameObject footCheck;

    Rigidbody playerBody;

    // Start is called before the first frame update
    void Start()
    {
        candy = 0;
        playerBody = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        if (canMove) {
            playerBody.velocity = new Vector3(horizontalInput * 5, playerBody.velocity.y, 0);
        }
        

        if (Input.GetKeyDown(KeyCode.Space) && Physics.OverlapSphere(footCheck.transform.position, 0.1f).Length > 1)
        {
            playerBody.AddForce(Vector3.up * 5, ForceMode.VelocityChange);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        //BounceUp tagged platforms are flat and bounces directly up
        if (collision.gameObject.tag == "BounceUp")
        {
            playerBody.AddForce(Vector3.up * 11, ForceMode.VelocityChange);
        }
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Candy")
        {
            Destroy(other.gameObject);
            candy++;
        }
    }

}
