using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] Text welcomeText;

    // Start is called before the first frame update
    void Start()
    {
        //Initially hide the welcome text
        hideText();
        //Show the welcome text with a delay and then hide it with a delay
        Invoke("showText", 2);
        Invoke("hideText", 5);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void showText()
    {
        welcomeText.gameObject.SetActive(true);
    }

    private void hideText() {
        welcomeText.gameObject.SetActive(false);
    }

}
