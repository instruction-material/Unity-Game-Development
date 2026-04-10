using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] GameObject footCheck;

    Rigidbody playerBody;

    // Start is called before the first frame update
    void Start()
    {
        playerBody = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        playerBody.velocity = new Vector3(horizontalInput * 5, playerBody.velocity.y, 0);

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
        //BoostUp tagged platforms are sideways and boost diagonally up
        else if (collision.gameObject.tag == "BoostUp")
        {
            playerBody.AddForce(Vector3.right * 5 + Vector3.up * 8, ForceMode.VelocityChange);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Collectible")
        {
            Destroy(other.gameObject);
        }
    }
}
