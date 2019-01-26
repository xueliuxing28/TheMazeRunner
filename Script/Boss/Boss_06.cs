using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_06 : MonoBehaviour {

    public Animator animator;
    public float moveSpeed;//移动速度
    public Transform _mode;//控制旋转
    private bool isMove = false;//判断是否正在移动
    private Vector3 endpos;//目标位置
    private float process = 0;//标记
    private Vector3 direction;//移动方向
    public bool canMove = false;//判断障碍物的移动
    private float dis = 3f;
    void Update()
    {
        Move();
    }
    void Move()
    {
        if (Input.GetKeyUp(KeyCode.D))
        {
            if (!isMove)
            {
                direction = new Vector3(0, 0, -1);
                endpos = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z -dis);
                process = 0;
                isMove = true;
            }
        }
        if (Input.GetKeyUp(KeyCode.A) && this.transform.position.z<57f)
        {
            if (!isMove)
            {
                direction = new Vector3(0, 0,1);
                endpos = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z + dis);
                process = 0;
                isMove = true;
            }
        }
        if (Input.GetKeyUp(KeyCode.W) && this.transform.position.x > -2f)
        {
            if (!isMove)
            {
                direction = new Vector3(-1, 0, 0);
                endpos = new Vector3(this.transform.position.x - dis, this.transform.position.y, this.transform.position.z);
                process = 0;
                isMove = true;
            }
        }
        if (Input.GetKeyUp(KeyCode.S) && this.transform.position.x < 7f)
        {
            if (!isMove)
            {
                direction = new Vector3(1, 0, 0);
                endpos = new Vector3(this.transform.position.x + dis, this.transform.position.y, this.transform.position.z);
                process = 0;
                isMove = true;
            }
        }
        if (isMove)
        {
            process += Time.deltaTime * moveSpeed;
            if (Vector3.Distance(this.transform.position, endpos) > 0.05f)
            {
                canMove = true;
                this.transform.position = Vector3.Lerp(this.transform.position, endpos, process);
                animator.SetBool("isMove", true);
            }
            else
            {
                canMove = false;
                animator.SetBool("isMove", false);
                isMove = false;
            }
        }
        if (direction != Vector3.zero)
        {
            _mode.rotation = Quaternion.LookRotation(direction);
        }
    }
}
