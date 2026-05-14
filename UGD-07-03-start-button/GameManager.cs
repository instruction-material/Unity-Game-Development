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


    // Start is called before the first frame update
    void Start()
    {
        //Hide the win and welcome texts to start
        winText.gameObject.SetActive(false);
        hideText();

        //Make player immobile until start button is pressed
        player.GetComponent<Player>().canMove = false;
    }

    // Update is called once per frame
    void Update()
    {
        int score = player.GetComponent<Player>().score;

        if (score > 6)
        {
            winText.gameObject.SetActive(true);
        }

        scoreText.text = "Score: " + score.ToString();
    }


    private void showText()
    {
        welcomeText.gameObject.SetActive(true);
    }

    private void hideText() {
        welcomeText.gameObject.SetActive(false);
    }

    private void startGame()
    {
        //Make player mobile again
        player.GetComponent<Player>().canMove = true;

        //Hide the start button and show the welcome message with a delay
        startButton.gameObject.SetActive(false);
        Invoke("showText", 1);
        Invoke("hideText", 4);
    }
}
