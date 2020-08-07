using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControlScript : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D col)
    {
        switch (col.gameObject.tag)
        {
            case "plus1sec":
                TimeLeftScript.timeLeft += 1f;
                col.gameObject.SetActive(false);
                break;
            case "minus2sec":
                TimeLeftScript.timeLeft -= 2f;
                col.gameObject.SetActive(false);
                break;
        }
    }
}
