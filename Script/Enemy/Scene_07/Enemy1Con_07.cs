using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1Con_07 : MonoBehaviour {
    public GameObject WEnemy;
    public Transform InitPoint;
    private int timer = 0;
    public PlayerMove3_07  playermove;
    public EnemyControl2_07 enemy2;
    private int canInstance = 0;
    void Update()
    {
        ChangeDir();
        if (timer > 1)
        {
            timer = 0;
        }
        if (!playermove.isMove)
        {
            canInstance = 0;
        }
    }
    void ChangeDir()
    {
        if (canInstance<1)
        {
            if (CanProduce())
            {
                if (timer == 0)
                {
                    Instantiate(WEnemy, InitPoint);
                    timer++;
                }
                else
                {
                    timer++;
                }
            }
        }
       
    }
    public bool CanProduce()
    {
        if (Input.GetKeyUp(KeyCode.A))
        {
            canInstance++;
            return true;
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            canInstance++;
            return true;
        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            canInstance++;
            return true;
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            canInstance++;
            return true;
        }
        return false;
    }
}
