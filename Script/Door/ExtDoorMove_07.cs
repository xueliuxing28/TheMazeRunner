using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtDoorMove_07 : MonoBehaviour {

    private float moveSpeed = 0.1f;//移动速度
    private bool isMove = false;//判断是否正在移动
    private Vector3 endpos;//目标位置
    private float process = 0;//标记
    public Vector3 direction;//移动方向
    public PlayerMove3_08 playermove;
    private bool startStatus = true;//设置障碍开始状态
    private bool Status = true;//设置中间方向转换
    private int rightTimer = 0;
    private float dis = 3f;//前进距离
    private int startTimer = 0;//开始计数器
    void Update()
    {
        ChangeDir();
        Obstacle7Move();
        if (rightTimer > 2)
        {
            Status = !Status;
            rightTimer = 0;
        }
        if (startTimer > 2)
        {
            startStatus = !startStatus;
            startTimer = 0;
        }
    }
    void Obstacle7Move()
    {
        if (playermove.canMove)
        {
            if (startStatus)
            {
                if (!isMove)
                {
                    endpos = new Vector3(this.transform.position.x - dis, this.transform.position.y, this.transform.position.z);
                    process = 0;
                    isMove = true;
                    startTimer++;
                }
            }
            else if (this.transform.position.x < -31f)
            {
                if (!isMove)
                {
                    endpos = new Vector3(this.transform.position.x + dis, this.transform.position.y, this.transform.position.z);
                    process = 0;
                    isMove = true;
                }
            }
            else if (this.transform.position.x > -21f)
            {
                if (!isMove)
                {
                    endpos = new Vector3(this.transform.position.x - dis, this.transform.position.y, this.transform.position.z);
                    process = 0;
                    isMove = true;
                }

            }

            else if (this.transform.position.x >= -31f && this.transform.position.x <= -21f && Status)
            {
                if (!isMove)
                {
                    endpos = new Vector3(this.transform.position.x + dis, this.transform.position.y, this.transform.position.z);
                    process = 0;
                    isMove = true;
                    rightTimer += 1;
                }

            }
            else if (this.transform.position.x >= -31f && this.transform.position.x <= -21f && !Status)
            {
                if (!isMove)
                {
                    endpos = new Vector3(this.transform.position.x - dis, this.transform.position.y, this.transform.position.z);
                    process = 0;
                    isMove = true;
                    rightTimer += 1;
                }

            }
        }
        if (isMove)
        {
            process += Time.deltaTime * moveSpeed;
            if (Vector3.Distance(this.transform.position, endpos) > 0.05f)
            {
                this.transform.position = Vector3.Lerp(this.transform.position, endpos, process);
            }
            else
            {
                isMove = false;
            }
        }
    }
    void ChangeDir()
    {
        if (this.transform.position.x < -31f)
        {
            direction = new Vector3(1, 0, 0);
        }
        else if (this.transform.position.x > -21f)
        {
            direction = new Vector3(-1, 0, 0);
        }
        else if (this.transform.position.x >= -31f && this.transform.position.x <= -21f && Status)
        {
            direction = new Vector3(1, 0, 0);
        }
        else if (this.transform.position.x >= -31f && this.transform.position.x <= -21f && !Status)
        {
            direction = new Vector3(-1, 0, 0);
        }
    }
}
