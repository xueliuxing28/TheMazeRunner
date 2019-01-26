using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl2_04 : MonoBehaviour {
    public float moveSpeed;//移动速度
    public Transform _mode;//控制旋转
    //public AudioSource source;//音效
    private bool isMove = false;//判断是否正在移动
    private Vector3 endpos;//目标位置
    private float process = 0;//标记
    //public float MovTime;//移动时间
    private Vector3 direction;//移动方向
    public PlayerMove2 playermove;
    private bool Status2 = true;//设置障碍开始状态
    private bool Status1 = true;//设置中间方向转换
    private int rightTimer1 = 0;//横向计数
    private int rightTimer2 = 0;//纵向计数
    private float dis = 3.8f;//前进距离
    //private int startTimer = 0;//开始计数器
    private bool changedir = false;//中转
    public ParticleSystem[] yan;
    private ParticleSystem thePlayYan;
    void Update()
    {
        Obstacle4Move();
        if (rightTimer1 >= 1)
        {
            Status1 = !Status1;
            rightTimer1 = 0;
        }
        if (rightTimer2 >=1)
        {
            Status2 = !Status2;
            rightTimer2 = 0;
        }
    }
    void Obstacle4Move()
    {
        if (playermove.canMove)
        {
            if (this.transform.position.x >7f && this.transform.position.z < 52f)//横向最初位置
            {
                if (!isMove)
                {
                    changedir = false;
                    direction = new Vector3(-1, 0, 0);
                    _mode.rotation = Quaternion.LookRotation(direction);
                    endpos = new Vector3(this.transform.position.x - dis, this.transform.position.y, this.transform.position.z);
                    process = 0;
                    thePlayYan = yan[0];
                    isMove = true;
                }
            }
            else if (this.transform.position.x >2f && this.transform.position.x <7f && Status1 && this.transform.position.z <52f)//横向中间
            {
                if (!isMove)
                {
                    direction = new Vector3(-1, 0, 0);
                    _mode.rotation = Quaternion.LookRotation(direction);
                    endpos = new Vector3(this.transform.position.x - dis, this.transform.position.y, this.transform.position.z);
                    process = 0;
                    thePlayYan = yan[0];
                    isMove = true;
                    rightTimer1 += 1;
                }

            }
            else if (this.transform.position.x >2f && this.transform.position.x <7f && !Status1 && this.transform.position.z<52f)//返回横向中间
            {
                if (!isMove)
                {
                    direction = new Vector3(1, 0, 0);
                    _mode.rotation = Quaternion.LookRotation(direction);
                    endpos = new Vector3(this.transform.position.x +dis, this.transform.position.y, this.transform.position.z);
                    process = 0;
                    thePlayYan = yan[1];
                    isMove = true;
                    rightTimer1 += 1;
                }
            }
            //纵向移动
            else if (this.transform.position.x <2f && this.transform.position.z <52f && !Status1 && !changedir)//头
            {
                if (!isMove)
                {
                    direction = new Vector3(0, 0,1);
                    _mode.rotation = Quaternion.LookRotation(direction);
                    endpos = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z + dis);
                    process = 0;
                    thePlayYan = yan[3];
                    isMove = true;
                }
            }
            else if (this.transform.position.x <2f && this.transform.position.z < 52f && !Status1 && changedir)//头
            {
                if (!isMove)
                {
                    direction = new Vector3(1, 0, 0);
                    _mode.rotation = Quaternion.LookRotation(direction);
                    endpos = new Vector3(this.transform.position.x + dis, this.transform.position.y, this.transform.position.z);
                    process = 0;
                    thePlayYan = yan[1];
                    isMove = true;
                }
            }
            else if (this.transform.position.x <2f && this.transform.position.z > 57f)//尾
            {
                if (!isMove)
                {
                    changedir = true;
                    direction = new Vector3(0, 0, -1);
                    _mode.rotation = Quaternion.LookRotation(direction);
                    endpos = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z - dis);
                    process = 0;
                    thePlayYan = yan[2];
                    isMove = true;
                }
            }
            else if (this.transform.position.x <2f && this.transform.position.z > 48f && this.transform.position.z < 57f && Status2)//中转
            {
                if (!isMove)
                {
                    direction = new Vector3(0, 0,1);
                    _mode.rotation = Quaternion.LookRotation(direction);
                    endpos = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z+dis);
                    process = 0;
                    thePlayYan = yan[3];
                    isMove = true;
                    rightTimer2++;
                }
            }
            else if (this.transform.position.x<2f && this.transform.position.z > 48f && this.transform.position.z < 57f && !Status2)//中转
            {
                if (!isMove)
                {
                    direction = new Vector3(0, 0, -1);
                    _mode.rotation = Quaternion.LookRotation(direction);
                    endpos = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z - dis);
                    process = 0;
                    thePlayYan = yan[2];
                    isMove = true;
                    rightTimer2++;
                }
            }
        }
        if (isMove)
        {
            process += Time.deltaTime * moveSpeed;
            if (Vector3.Distance(this.transform.position, endpos) > 0.05f)
            {
                //source.Play();
                this.transform.position = Vector3.Lerp(this.transform.position, endpos, process);
                thePlayYan.Play();
            }
            else
            {
                // yan.SetActive(false);
                isMove = false;
                //source.Stop();
            }
        }
    }
}
