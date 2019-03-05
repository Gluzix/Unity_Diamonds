using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Collisions_with_coins : MonoBehaviour
{
    public Text countText;
    private int punctation = 0;
    private bool add_bonus = false;

    public bool addb()
    {
        return add_bonus;
    }
    public void instbns(bool bns)
    {
        add_bonus = bns;
    }
    void Start()
    {
        countText.text = "Punctation: " + punctation.ToString();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "image 3")
        {
            if(punctation%50==0)add_bonus = true;
            Destroy(collision.gameObject);
            punctation += 5;
            countText.text = "Punctation: " + punctation.ToString();
        }
    }
}
