using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelControlQuizScript : MonoBehaviour
{
    GameObject[] toEnable, toDisable;

    public GameObject correctSign, incorrectSign, cup, trophySing;

    int currentSceneIndex;

    public string whichCupGot = "Cup1Got";

	// Use this for initialization
	void Start ()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        toEnable = GameObject.FindGameObjectsWithTag("ToEnable");
        toDisable = GameObject.FindGameObjectsWithTag("ToDisable");

        foreach (GameObject element in toEnable)
        {
            element.gameObject.SetActive(false);
        }
	}
	
    public void RightAnswer()
    {
        foreach (GameObject element in toDisable)
        {
            element.gameObject.SetActive(false);
        }

        correctSign.gameObject.SetActive(true);

        int Cupgot = PlayerPrefs.GetInt(whichCupGot);

        if (Cupgot == 1)

            Invoke("LoadNextLevelQuiz", 1f);
        else
            Invoke("GetTrophy", 1f);
    }

    public void WrongAnswer()
    {
        foreach (GameObject element in toDisable)
        {
            element.gameObject.SetActive(false);
        }

        incorrectSign.SetActive(true);

        Invoke("GotoMainMenu", 1f);
    }

    void GetTrophy()
    {
        correctSign.SetActive(false);
        cup.SetActive(true);

        trophySing.SetActive(true);

        PlayerPrefs.SetInt(whichCupGot, 1);

        Invoke("LoadNextLevelQuiz", 1f);
    }

    void LoadNextLevelQuiz()
    {
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

    void GotoMainMenu()
    {
        SceneManager.LoadScene("sceneMainMenuQuiz");
    }
}
