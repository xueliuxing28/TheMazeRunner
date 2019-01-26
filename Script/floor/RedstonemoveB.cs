using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedstonemoveB : MonoBehaviour {

    public float moveSpeed;//移动速度
    private bool isMove = false;//判断是否正在移动
    private Vector3 endpos;//目标位置
    private float process = 0;//标记                              
    private Vector3 direction;//移动方向
    public PlayerMove3 playerMove3;
    //private bool startStatus = true;//设置障碍开始状态
    private bool Status = true;//设置中间方向转换
    private int rightTimer = 0;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        StoneMove();
        if (rightTimer >= 1)
        {
            Status = !Status;
            rightTimer = 0;
        }
    }
    void StoneMove()
    {
        if (playerMove3.canMove)
        {
            if (this.transform.position.y < -9f)
            {
                if (!isMove)
                {
                    endpos = new Vector3(this.transform.position.x, this.transform.position.y + 5f, this.transform.position.z);
                    process = 0;
                    isMove = true;
                    Debug.Log("zhixing1");
                }
            }
            else if (this.transform.position.y > -1f)
            {
                if (!isMove)
                {
                    endpos = new Vector3(this.transform.position.x, this.transform.position.y - 5f, this.transform.position.z);
                    process = 0;
                    isMove = true;
                    Debug.Log("zhixing2");
                }
            }
            else if (this.transform.position.y < -4f && this.transform.position.y > -6f && Status)
            {
                if (!isMove)
                {
                    endpos = new Vector3(this.transform.position.x, this.transform.position.y + 5f, this.transform.position.z);
                    process = 0;
                    isMove = true;
                    rightTimer += 1;
                    Debug.Log("zhixing3");
                }
            }
            else if (this.transform.position.y < -4f && this.transform.position.y > -6f && !Status)
            {
                if (!isMove)
                {
                    endpos = new Vector3(this.transform.position.x, this.transform.position.y - 5f, this.transform.position.z);
                    process = 0;
                    isMove = true;
                    rightTimer += 1;
                    Debug.Log("zhixing4");
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
}
