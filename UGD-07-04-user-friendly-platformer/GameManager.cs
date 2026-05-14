using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] Text welcomeText;
    [SerializeField] Text winText;
    [SerializeField] Text scoreText;
    [SerializeField] GameObject player;
    [SerializeField] Button startButton;
    [SerializeField] Button pauseButton;
    [SerializeField] Button unpauseButton;


    // Start is called before the first frame update
    void Start()
    {
        //Set UI components that shouldn't appear the start to true
        winText.gameObject.SetActive(false);
        unpauseButton.gameObject.SetActive(false);
        pauseButton.gameObject.SetActive(false);
        welcomeText.gameObject.SetActive(false);
        scoreText.gameObject.SetActive(false);

        //Make sure the player can't move until the start button is pressed
        player.GetComponent<Player>().canMove = false;
    }

    // Update is called once per frame
    void Update()
    {
        int candy = player.GetComponent<Player>().candy;

        if (candy > 9)
        {
            winText.gameObject.SetActive(true);
        }

        //Display updated score
        scoreText.text = "Candy Remaining: " + (10 - candy).ToString();



    }


    private void showText()
    {
        welcomeText.gameObject.SetActive(true);
    }

    private void hideText() {
        welcomeText.gameObject.SetActive(false);
    }

    public void startGame()
    {
        //Let player move
        player.GetComponent<Player>().canMove = true;

        //Show pause button and score, hide start button
        startButton.gameObject.SetActive(false);
        pauseButton.gameObject.SetActive(true);
        scoreText.gameObject.SetActive(true);

        //Delay showing welcome message then hide it
        Invoke("showText", 1);
        Invoke("hideText", 4);
    }

    public void pauseGame()
    {
        //Make player immobile again
        player.GetComponent<Player>().canMove = false;

        //Hide pause button and show unpause button
        unpauseButton.gameObject.SetActive(true);
        pauseButton.gameObject.SetActive(false);
    }

    public void unpauseGame()
    {
        //Let player move again
        player.GetComponent<Player>().canMove = true;

        //Hide unpause button and show pause button
        unpauseButton.gameObject.SetActive(false);
        pauseButton.gameObject.SetActive(true);
    }
}
