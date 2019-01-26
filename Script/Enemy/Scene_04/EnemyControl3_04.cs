using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl3_04 : MonoBehaviour {

    public float moveSpeed;//移动速度
    public Transform _mode;//控制旋转
    private bool isMove = false;//判断是否正在移动
    private Vector3 endpos;//目标位置
    private float process = 0;//标记
    //public float MovTime;//移动时间
    private Vector3 direction;//移动方向
    public PlayerMove2 playermove;
    private bool startStatus = true;//设置障碍开始状态
    private bool Status = true;//设置中间方向转换
    private int rightTimer = 0;
    private float dis = 3.8f;//前进距离
    private int startTimer = 0;//开始计数器
    public ParticleSystem[] yan;
    private ParticleSystem thePlayYan;
    void Update()
    {
        Obstacle4Move();
        if (rightTimer > 1)
        {
            Status = !Status;
            rightTimer = 0;
        }
        if (startTimer > 1)
        {
            startStatus = false;
        }
    }
    void Obstacle4Move()
    {
        if (playermove.canMove)
        {
            if (startStatus && this.transform.position.x >= -2f && this.transform.position.x <= 7f)
            {
                if (!isMove)
                {
                    direction = new Vector3(-1, 0, 0);
                    endpos = new Vector3(this.transform.position.x - dis, this.transform.position.y, this.transform.position.z);
                    process = 0;
                    thePlayYan = yan[0];
                    startTimer += 1;
                    isMove = true;
                }

            }
            else if (this.transform.position.x < -2f)
            {
                if (!isMove)
                {
                    direction = new Vector3(1, 0, 0);
                    endpos = new Vector3(this.transform.position.x + dis, this.transform.position.y, this.transform.position.z);
                    process = 0;
                    thePlayYan = yan[1];
                    isMove = true;
                }

            }
            else if (this.transform.position.x > 7f)
            {
                if (!isMove)
                {
                    direction = new Vector3(-1, 0, 0);
                    endpos = new Vector3(this.transform.position.x - dis, this.transform.position.y, this.transform.position.z);
                    process = 0;
                    thePlayYan = yan[0];
                    isMove = true;
                }

            }

            else if (this.transform.position.x >= -2f && this.transform.position.x <= 7f && Status)
            {
                if (!isMove)
                {
                    direction = new Vector3(1, 0, 0);
                    endpos = new Vector3(this.transform.position.x + dis, this.transform.position.y, this.transform.position.z);
                    process = 0;
                    thePlayYan = yan[1];
                    isMove = true;
                    rightTimer += 1;
                }

            }
            else if (this.transform.position.x >= -2f && this.transform.position.x <= 7f && !Status)
            {
                if (!isMove)
                {
                    direction = new Vector3(-1, 0, 0);
                    endpos = new Vector3(this.transform.position.x - dis, this.transform.position.y, this.transform.position.z);
                    process = 0;
                    thePlayYan = yan[0];
                    isMove = true;
                    rightTimer += 1;
                }

            }
        }
        if (direction != Vector3.zero)
        {
            _mode.rotation = Quaternion.LookRotation(direction);
        }
        if (isMove)
        {
            process += Time.deltaTime * moveSpeed;
            if (Vector3.Distance(this.transform.position, endpos) > 0.05f)
            {
                this.transform.position = Vector3.Lerp(this.transform.position, endpos, process);
                thePlayYan.Play();
            }
            else
            {
                // yan.SetActive(false);
                isMove = false;
            }
        }

    }
}
