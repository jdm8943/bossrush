using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.Mathematics;
using UnityEngine;

public class BossActions : MonoBehaviour
{
    public GameObject player;
    public GameObject AoeAttack;
    public int movespeed = 4;
    public float attackDamage = 10f;
    public bool Moving = false;

    public float attackCooldown = 10f;
    public GameObject deathEffect;
    private float lastAttackTime = 0f;
    System.Random rand = new System.Random();
    int randnum = 0;


    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Time.time > lastAttackTime + attackCooldown)
        {
            
            randnum = rand.Next(1, 3);
            switch(randnum)
            {
                case 1:
                    {
                        if(Moving==false)
                        {
                            moveto();
                        }
                        else
                        {
                            Moving = true;
                        } 
                        return;
                    }
               case 2:
                    {
                        if (AoeAttack.activeInHierarchy == false)
                        {
                            WaveAttack();
                        }
                        else
                        {
                            AoeAttack.SetActive(false);
                        }
                        
                        return;
                    }
            }
            lastAttackTime = Time.time;
            
        }
    }
        
    public void moveto()
    {
 

        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, movespeed * Time.deltaTime);
        

    }

    public void WaveAttack()
    {
        AoeAttack.SetActive(true);
        
    }

    public void SummonMinions()
    {

    }
}
