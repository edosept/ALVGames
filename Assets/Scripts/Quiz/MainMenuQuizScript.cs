using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuQuizScript : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("sceneQuiz01");
    }

    public void GotoTrophyRoom()
    {
        SceneManager.LoadScene("sceneTrophyRoom");
    }

    public void ResetPlayerPrefs()
    {
        PlayerPrefs.DeleteAll();
    }
}
