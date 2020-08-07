using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrophyRoomControlScript : MonoBehaviour
{
    public GameObject cup1, cup2, cup3, cup4, cup5;

    int cup1Got, cup2Got, cup3Got, cup4Got, cup5Got;

	// Use this for initialization
	void Start ()
    {
        cup1Got = PlayerPrefs.GetInt("Cup1Got");
        cup2Got = PlayerPrefs.GetInt("Cup2Got");
        cup3Got = PlayerPrefs.GetInt("Cup3Got");
        cup4Got = PlayerPrefs.GetInt("Cup4Got");
        cup5Got = PlayerPrefs.GetInt("Cup5Got");

        if (cup1Got == 1)
            cup1.SetActive(true);

        else
            cup1.SetActive(false);

        if (cup2Got == 1)
            cup2.SetActive(true);

        else
            cup2.SetActive(false);

        if (cup3Got == 1)
            cup3.SetActive(true);

        else
            cup3.SetActive(false);

        if (cup4Got == 1)
            cup4.SetActive(true);

        else
            cup4.SetActive(false);

        if (cup5Got == 1)
            cup5.SetActive(true);

        else
            cup5.SetActive(false);



    }
}
