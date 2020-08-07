using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinSceneScript : MonoBehaviour
{
	// Use this for initialization
	void Start ()
    {
        Invoke("GotoMainMenu", timeToLoadScene);
	}
	
	void GotoMainMenu()
    {
        SceneManager.LoadScene("sceneMainMenuQuiz");
    }

    float timeToLoadScene = 5;

    
}
