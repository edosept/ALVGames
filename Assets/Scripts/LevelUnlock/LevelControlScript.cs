using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelControlScript : MonoBehaviour
{
    public static LevelControlScript instance = null;
    GameObject youWinText;
    int sceneIndex, sceneStagePassed;

    public static int lovehealth;

    void Start()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        youWinText = GameObject.Find("YouWinText");
        youWinText.gameObject.SetActive(false);
        sceneIndex = SceneManager.GetActiveScene().buildIndex;
        sceneStagePassed = PlayerPrefs.GetInt("SceneStagePassed");
    }

    public void youWin()
    {
        if (sceneIndex == 1)
            Invoke("loadStageMenu", 1f);
        else
        {
            if (sceneStagePassed < sceneIndex)
                PlayerPrefs.SetInt("SceneStagePassed", sceneIndex);
            
            youWinText.gameObject.SetActive(true);
            Invoke("loadNextLevel", 1f);
        }
    }

    void loadNextLevel()
    {
        SceneManager.LoadScene(sceneIndex + 1);
        TimeLeftScript.timeLeft = 270f;
        lovehealth = 9;
        ScoreTextScript.coinAmount = 0;
    }

    void loadStageMenu()
    {
        SceneManager.LoadScene("sceneMainMenuQuiz");
    }

}
