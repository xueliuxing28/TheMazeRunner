﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AEnemyMove : MonoBehaviour
{
    private float moveSpeed = 0.1f;//移动速度
    public bool isMove = false;//判断是否正在移动
    private Vector3 endpos;//目标位置
    private float process = 0;//标记
    private PlayerMove2 playermove;
    private bool startStatus = true;//设置中间方向转换
    private float dis = 3.8f;
    private void Start()
    {
        playermove = GameObject.Find("Player").GetComponent<PlayerMove2>();
    }
    void Update()
    {
        Obstacle5Move();
    }
    void Obstacle5Move()
    {
            if (playermove.canMove)
            {
                if (startStatus)
                {
                    if (!isMove)
                    {
                        endpos = new Vector3(this.transform.position.x, this.transform.position.y + 2.7f, this.transform.position.z);
                        process = 0;
                        isMove = true;
                        startStatus = false;
                    }
                }
                else if (this.transform.position.z > 49f)
                {
                    if (!isMove)
                    {
                        endpos = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z - dis);
                        process = 0;
                        isMove = true;
                    }

                }
                else if (this.transform.position.z < 49f)
                {
                    if (!isMove)
                    {
                        endpos = new Vector3(this.transform.position.x, this.transform.position.y - dis, this.transform.position.z);
                        process = 0;
                        isMove = true;
                    }
                    if (this.transform.position.y < -7f)
                    {
                        Destroy(this.gameObject);
                    }
                }

                if (isMove)
                {
                   
                process += Time.deltaTime * moveSpeed;
                this.transform.position = Vector3.Lerp(this.transform.position, endpos, process);
                if (Vector3.Distance(this.transform.position, endpos) < 0.05f)
                    {
                    isMove = false;
                }
//                     else
//                     {
//                       
// //                         this.transform.position = new Vector3(0.6f, -4.5f, 54.6f);
// //                         Debug.Log("zhixing");
// //                         Status = false;
//                     }
                }

            }
        
    }
}
