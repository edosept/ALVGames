using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameControlScript : MonoBehaviour
{
    public GameObject timeIsUp, restartButton;

    public GameObject heart1, heart2, heart3, gameOver;
    public static int lovehealth;

    // Use this for initialization
    void Start ()
    {
        lovehealth = 9;
        heart1.gameObject.SetActive(true);
        heart2.gameObject.SetActive(true);
        heart3.gameObject.SetActive(true);
        gameOver.gameObject.SetActive(false);
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (TimeLeftScript.timeLeft <= 0)
        {
            Time.timeScale = 0;
            timeIsUp.gameObject.SetActive(true);
            restartButton.gameObject.SetActive(true);
            gameOver.gameObject.SetActive(true);
        }

        if (lovehealth > 3)
            lovehealth = 9;

        switch (lovehealth)
        {
            case 3:
                heart1.gameObject.SetActive(true);
                heart2.gameObject.SetActive(true);
                heart3.gameObject.SetActive(true);
                break;

            case 2:
                heart1.gameObject.SetActive(true);
                heart2.gameObject.SetActive(true);
                heart3.gameObject.SetActive(false);
                break;

            case 1:
                heart1.gameObject.SetActive(true);
                heart2.gameObject.SetActive(false);
                heart3.gameObject.SetActive(false);
                break;

            case 0:
                heart1.gameObject.SetActive(false);
                heart2.gameObject.SetActive(false);
                heart3.gameObject.SetActive(false);
                gameOver.gameObject.SetActive(true);
                restartButton.gameObject.SetActive(true);
                Time.timeScale = 0;
                break;
        }
	}

    public void restartScene()
    {
        timeIsUp.gameObject.SetActive(false);
        restartButton.gameObject.SetActive(false);
        Time.timeScale = 1;
        TimeLeftScript.timeLeft = 300f;
        lovehealth = 9;
        ScoreTextScript.coinAmount = 0;
        SceneManager.LoadScene("sceneStageMenu");
    }
}
