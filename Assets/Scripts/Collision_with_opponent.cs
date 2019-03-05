using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision_with_opponent : MonoBehaviour
{
    private Rigidbody2D rb;
    private int how_many_opponents=4;
    private float HitForce = 35;
    public GameObject Hearts_1, Hearts_2, Hearts_3;
    private int heart_counter = 1;
    private bool destroy_life = false;
    private int wait_few_frames = 0;
    private bool if_hit = false;

    public bool Ret_if_hit()
    {
        return if_hit;
    }

    public void Ins_if_hit(bool _if_hit)
    {
        if_hit = _if_hit;
    }


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (wait_few_frames > 60)
        {
            destroy_life = true;
            wait_few_frames = 0;
        }
        else if(!destroy_life) wait_few_frames++;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        for(int i=1; i<=how_many_opponents; i++)
        {
            if (collision.gameObject.name == "Opponent_Mace_" + i.ToString())
            {
                if_hit = true;
                rb.velocity = new Vector2();
                rb.velocity = Vector2.up * HitForce;
                if(destroy_life)
                {
                    switch(heart_counter)
                    {
                        case 1: Destroy(Hearts_3); heart_counter++; break;
                        case 2: Destroy(Hearts_2); heart_counter++; break;
                        case 3: Destroy(Hearts_1); break;
                    }
                    destroy_life = false;
                }
            }
        }
    }
}
