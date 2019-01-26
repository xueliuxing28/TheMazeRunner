using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2Con : MonoBehaviour {
    public GameObject WEnemy;
    public GameObject SEnemy;
    public Transform InitPoint1;
    public Transform InitPoint2;
    private int timer = 0;
    public PlayerMove2 playermove;
   // public Enemy2 enemy2;
    private int canInstance=0;
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
//         if (enemy2 != null)
//         {
//         }
             if (canInstance<1)
             {
                if (CanProduce())
                {
                    if (timer == 0)
                    {
                        Instantiate(WEnemy, InitPoint2);
                        Instantiate(SEnemy, InitPoint1);
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

