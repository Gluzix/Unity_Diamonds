using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Collisions_with_coins : MonoBehaviour
{
    public Text countText;
    
    private int how_many_coins = 0;
    private int punctation = 0;

    void Start()
    {
        countText.text = "Punctation: " + punctation.ToString();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(how_many_coins<29)
        {
            for (int i = 0; i < 29; i++)
            {
                if (collision.gameObject.name == "image 3 (" + i.ToString() + ")")
                {
                    Destroy(collision.gameObject);
                    how_many_coins++;
                    punctation += 5;
                    countText.text = "Punctation: " + punctation.ToString();
                    break;
                }
            }
        }    
    }

}
