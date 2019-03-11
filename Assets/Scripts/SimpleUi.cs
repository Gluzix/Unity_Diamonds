using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SimpleUi : MonoBehaviour
{
    public Collision_with_opponent cwo;
    public Text text1, text2, text3;
    // Update is called once per frame
    void Update()
    {
        if(cwo.ret_fin() || Finish.ret_if_plr_entered_fnsh())
        {
            Time.timeScale = 0;
            text1.text = "Press Q to Quit";
            text2.text = "Press R to Restart";
            text3.text = "Koniec gry!";
            if (Input.GetKeyDown(KeyCode.R)) Application.LoadLevel(Application.loadedLevel);
            else if (Input.GetKeyDown(KeyCode.Q)) Application.Quit();
        }
        else Time.timeScale = 1;
    }
}
