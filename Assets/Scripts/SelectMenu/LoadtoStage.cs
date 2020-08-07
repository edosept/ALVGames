using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadtoStage : MonoBehaviour
{
    public void Stage1()
    {
        SceneManager.LoadScene("sceneStage1");
    }

    public void Stage2()
    {
        SceneManager.LoadScene("sceneStage2");
    }

    public void Stage3()
    {
        SceneManager.LoadScene("sceneStage3");
    }
}
