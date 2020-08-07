using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSelectScript : MonoBehaviour
{
    public void selectScene()
    {
        switch (this.gameObject.name)
        {
            case "ButtonPlay":
                SceneManager.LoadScene("sceneStageMenu");
                break;

            case "ButtonHTPlay":
                SceneManager.LoadScene("sceneHTPlay");
                break;

            case "ButtonAbout":
                SceneManager.LoadScene("sceneAbout");
                break;
        }
    }
}
