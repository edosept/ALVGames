using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackButtonQuizScript : MonoBehaviour
{
    public void BackToMainMenuQuiz()
    {
        SceneManager.LoadScene("sceneMainMenuQuiz");
    }
}
