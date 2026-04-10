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
        //Hide the welcome and win text initially
        winText.gameObject.SetActive(false);
        hideText();
        //Show the welcome text with a delay and then hide the text with a delay
        Invoke("showText", 2);
        Invoke("hideText", 5);
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

    private void hideText()
    {
        welcomeText.gameObject.SetActive(false);
    }
}
