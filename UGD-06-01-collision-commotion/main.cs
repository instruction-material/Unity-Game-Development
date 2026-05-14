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
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            playerBody.velocity = new Vector3(4, playerBody.velocity.y, 0);
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            playerBody.velocity = new Vector3(-4, playerBody.velocity.y, 0);
        }

        if (Input.GetKeyDown(KeyCode.Space) && Physics.OverlapSphere(footCheck.transform.position, 0.1f).Length > 1)
        {
            playerBody.AddForce(Vector3.up * 5, ForceMode.VelocityChange);
        }
    }


    private void OnCollisionEnter(Collision collision)
    {
        /*Platforms to bounce right are tagged BounceRight and BounceLeft
        to bounce left*/
        if (collision.gameObject.tag == "BounceRight")
        {
            playerBody.AddForce(Vector3.right * 5, ForceMode.VelocityChange);
        }
        else if (collision.gameObject.tag == "BounceLeft")
        {
            playerBody.AddForce(Vector3.right * -5, ForceMode.VelocityChange);
        }
    }
}
