using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public int health;
    public int score;

    public TMP_Text healthText;
    public TMP_Text scoreText;
    public TMP_Text goTEXt;
    public TMP_Text intructions;
    public GameObject player;
    public GameObject aliens;
    public GameObject resetButton;
    public GameObject quitButton;

    public int waitTime = 300;
    int timer;

    // Update is called once per frame
    void Update()
    {
        healthText.text = "Health: " + health;
        scoreText.text = "Score: " + score;

        if (health <= 0)
        {
            gameOver();
        }

        if (timer < waitTime)
        {
            timer++;
        }
        else if (timer == waitTime)
        {
            intructions.gameObject.SetActive(false);
        }
    }

    public void gameOver()
    {
        Debug.Log("game over");
        goTEXt.gameObject.SetActive(true);
        resetButton.gameObject.SetActive(true);
        quitButton.gameObject.SetActive(true);
        Destroy(player);
        Destroy(aliens);
    }

    public void reset()
    {
        SceneManager.LoadScene("Game");
    }

    public void close()
    {
        Application.Quit();
    }

}
