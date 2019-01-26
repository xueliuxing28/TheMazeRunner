using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HEnemyControl2 : MonoBehaviour {

    public float moveSpeed;//移动速度
    public Transform _mode;//控制旋转
   // public AudioSource source;//音效
    private bool isMove = false;//判断是否正在移动
    private Vector3 endpos;//目标位置
    private float process = 0;//标记
    private Vector3 direction;//移动方向
    public PlayerMove1 playermove;
    private bool startStatus = true;//设置障碍开始状态
    private bool Status = true;//设置中间方向转换
    private int rightTimer = 0;
    public ParticleSystem[] yan;
    private ParticleSystem thePlayYan;

    void Update()
    {
        if (!playermove.die)
        {
            Obstacle1Move();
        }  
        if (rightTimer >= 1)
        {
            Status = !Status;
            rightTimer = 0;
        }
    }
    void Obstacle1Move()
    {
        if (playermove.canMove)
        {
            if (startStatus && this.transform.position.x >= -2f && this.transform.position.x <= 7f)
            {
                if (!isMove)
                {
                    direction = new Vector3(-1, 0, 0);
                    endpos = new Vector3(this.transform.position.x - 5, this.transform.position.y, this.transform.position.z);
                    process = 0;
                    thePlayYan = yan[0];
                    startStatus = false;
                    isMove = true;
                }

            }
            else if (this.transform.position.x < -2f)
            {
                if (!isMove)
                {
                    direction = new Vector3(1, 0, 0);
                    endpos = new Vector3(this.transform.position.x + 5, this.transform.position.y, this.transform.position.z);
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
                    endpos = new Vector3(this.transform.position.x - 5, this.transform.position.y, this.transform.position.z);
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
                    endpos = new Vector3(this.transform.position.x + 5, this.transform.position.y, this.transform.position.z);
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
                    endpos = new Vector3(this.transform.position.x - 5, this.transform.position.y, this.transform.position.z);
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
               // source.Play();
            }
            else
            {
                //animator.SetBool("isMove", false);
               // source.Stop();
                isMove = false;
            }
        }

    }
}
