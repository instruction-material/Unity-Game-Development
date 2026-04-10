using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{

    [SerializeField] GameObject footCheck;
    [SerializeField] GameObject endPlatform;
    [SerializeField] Button restartButton;

    private bool canMove;

    // Start is called before the first frame update
    void Start()
    {
        //Make player mobile and hide restart button
        restartButton.gameObject.SetActive(false);
        canMove = true;
    }

    // Update is called once per frame
    void Update()
    {
        Rigidbody playerBody = gameObject.GetComponent<Rigidbody>();
        if (canMove)
        {
            float horizontalInput = Input.GetAxis("Horizontal");

            playerBody.velocity = new Vector3(horizontalInput * 5, playerBody.velocity.y, 0);

            if (Input.GetKeyDown(KeyCode.Space) && Physics.OverlapSphere(footCheck.transform.position, 0.1f).Length > 1)
            {
                playerBody.AddForce(Vector3.up * 5, ForceMode.VelocityChange);
            }
        }
        else
        {
            playerBody.velocity = Vector3.zero;
        }

        if (gameObject.transform.position.y < -8)
        {
            gameObject.transform.position = new Vector3(0, 3, 0);
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        //Check with a direct reference to the object instead of a tag
        if (collision.gameObject.Equals(endPlatform))
        {
            restartButton.gameObject.SetActive(true);
            canMove = false;

        }
    }

    public void restartGame()
    {
        //Make player mobile, reset position, and hide restart button
        canMove = true;
        gameObject.transform.position = new Vector3(0, 4, 0);
        restartButton.gameObject.SetActive(false);
    }
}
