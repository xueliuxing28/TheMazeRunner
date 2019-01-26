using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl5_03 : MonoBehaviour {
    public float moveSpeed;//移动速度
    public Transform _mode;//控制旋转
    private bool isMove = false;//判断是否正在移动
    private Vector3 endpos;//目标位置
    private float process = 0;//标记
    private Vector3 direction;//移动方向
    public PlayerMove2 playermove;
    private bool Status = true;//设置中间方向转换
    private int rightTimer = 0;
    private int startTimer = 0;
    private bool startStatus = true;
    public ParticleSystem[] yan;
    private ParticleSystem thePlayYan;
    void Update()
    {
        Obstacle3Move();
        if (rightTimer > 1)
        {
            Status = !Status;
            rightTimer = 0;
        }
        if (startTimer > 2)
        {
            startStatus = false;
        }
    }
    void Obstacle3Move()
    {
        if (playermove.canMove)
        {
            if (startStatus)
            {
                if (!isMove)
                {
                    direction = new Vector3(0, 0, -1);
                    endpos = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z - 3.8f);
                    process = 0;
                    thePlayYan = yan[0];
                    startTimer += 1;
                    isMove = true;
                }

            }
            else if (this.transform.position.z > 57f)
            {
                if (!isMove)
                {
                    direction = new Vector3(0, 0, -1);
                    endpos = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z - 3.8f);
                    process = 0;
                    thePlayYan = yan[0];
                    isMove = true;
                }

            }
            else if (this.transform.position.z < 48f)
            {
                if (!isMove)
                {
                    direction = new Vector3(0, 0, 1);
                    endpos = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z + 3.8f);
                    process = 0;
                    thePlayYan = yan[1];
                    isMove = true;
                }

            }

            else if (this.transform.position.z >= 48f && this.transform.position.z < 57f && Status)
            {
                if (!isMove)
                {
                    direction = new Vector3(0, 0, 1);
                    endpos = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z + 3.8f);
                    process = 0;
                    thePlayYan = yan[1];
                    isMove = true;
                    rightTimer += 1;
                }

            }
            else if (this.transform.position.z >= 48f && this.transform.position.x < 57f && !Status)
            {
                if (!isMove)
                {
                    direction = new Vector3(0, 0, -1);
                    endpos = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z - 3.8f);
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
                thePlayYan.Play();
                this.transform.position = Vector3.Lerp(this.transform.position, endpos, process);
            }
            else
            {
                isMove = false;
            }
        }

    }
}
