using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossActions : MonoBehaviour
{
    public GameObject player;
    public GameObject AoeAttack;
    public int movespeed = 4;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        WaveAttack();
        moveto();
    }

    public void moveto()
    {
        
        transform.position =Vector2.MoveTowards(transform.position,player.transform.position,movespeed*Time.deltaTime);

    }

    public void WaveAttack()
    {
        AoeAttack.SetActive(true);
        
        
    }
}
