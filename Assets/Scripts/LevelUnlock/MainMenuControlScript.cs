using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuControlScript : MonoBehaviour
{
    public Button level02Button, level03Button;

    int sceneStagePassed;
	// Use this for initialization
	void Start ()
    {
        sceneStagePassed = PlayerPrefs.GetInt("SceneStagePassed");
        level02Button.interactable = false;
        level03Button.interactable = false;

		switch (sceneStagePassed)
        {
            case 1:
                level02Button.interactable = true;
                break;

            case 2:
                level02Button.interactable = true;
                level03Button.interactable = true;
                break;
        }
	}

    public void levelToLoad(int sceneHTStage)
    {
        SceneManager.LoadScene(sceneHTStage);
    }

    public void resetPlayerPrefs()
    {
        level02Button.interactable = false;
        level03Button.interactable = false;
        PlayerPrefs.DeleteAll();
    }
}
