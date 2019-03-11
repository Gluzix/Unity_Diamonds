using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour
{
    public Transform trnsf1;
    static bool finished = false;
    
    static public bool ret_if_plr_entered_fnsh()
    {
        return finished;
    }

    void FixedUpdate()
    {
        if(transform.position.x>trnsf1.position.x)
        {
            finished = true;
        }
    }
}
