using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WEnemyCon_07 : MonoBehaviour {
    private float moveSpeed = 0.1f;//移动速度
    public bool isMove = false;//判断是否正在移动
    private Vector3 endpos;//目标位置
    private float process = 0;//标记
    private PlayerMove3_07 playermove;
    private bool startStatus = true;//设置障碍开始状态
    private float dis = 3f;
    public ParticleSystem yan;
    private void Start()
    {
        playermove = GameObject.Find("Player").GetComponent<PlayerMove3_07>();
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
                    endpos = new Vector3(this.transform.position.x, this.transform.position.y + 3.5f, this.transform.position.z);
                    process = 0;
                    startStatus = false;
                    isMove = true;
                }
            }
            else if (this.transform.position.x > -2f)
            {
                if (!isMove)
                {
                    endpos = new Vector3(this.transform.position.x - dis, this.transform.position.y, this.transform.position.z);
                    process = 0;
                    isMove = true;
                }
            }
            else if (this.transform.position.x <-2f)
            {
                if (!isMove)
                {
                    endpos = new Vector3(this.transform.position.x, this.transform.position.y - 4f, this.transform.position.z);
                    process = 0;
                    isMove = true;
                }
                if (this.transform.position.y < -7f)
                {
                    Destroy(this.gameObject);
                }
            }
        }
        if (isMove)
        {
            process += Time.deltaTime * moveSpeed;
            this.transform.position = Vector3.Lerp(this.transform.position, endpos, process);
            yan.Play();
            if (Vector3.Distance(this.transform.position, endpos) < 0.05f)
            {

                isMove = false;
            }
        }
    }
}
