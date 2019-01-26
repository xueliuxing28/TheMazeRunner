using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FightPlayer1Move : MonoBehaviour {
    public Animator animator;
    public float moveSpeed;//移动速度
    public Transform _mode;//控制旋转
    public bool isMove = false;//判断是否正在移动
    private Vector3 endpos;//目标位置
    private float process = 0;//标记
    private Vector3 direction;//移动方向
    public bool canMove = false;//判断障碍物的移动
    private float dis = 3f;
    public Transform Door;
    private Vector3 DoorPoint;
    public Wall2Move doorMove;
    public bool die = false;
    public GameObject weapon;//使用武器
    private bool speedUp = false;//加速判断
    public GameObject leftShoe;
    public GameObject rightShoe;
    public int starNum;
    private void Start()
    {
        starNum = 0;
        int index = SceneManager.GetActiveScene().buildIndex;
    }
    void Update()
    {
        Move();
        if (starNum>=4)
        {
            bool yes = true;
            if (Input.GetKeyDown(KeyCode.P))
            { 
                weapon.SetActive(true);
                if (yes)//保证执行一次
                {
                    starNum = starNum - 4;
                }
                yes = false;
            }
        }
        if (starNum>=4)
        {
            bool yes = true;
            if (Input.GetKeyDown(KeyCode.I))
            {
                speedUp = true;
                moveSpeed = 0.2f;
                leftShoe.SetActive(true);
                rightShoe.SetActive(true);
                if (yes)//保证执行一次
                {
                    starNum = starNum - 4;
                }
                yes = false;
            }
        }
     
    }
    void Move()
    {
        if (PlayerMoveOrder.instance.num == 1)
        {
            if ((Input.GetKeyUp(KeyCode.D) && this.transform.position.z < 57f) || (Input.GetKeyDown(KeyCode.D) && canForward() && this.transform.position.z > 57f))
            {
                if (!isMove && !die)
                {
                    if (speedUp && (this.transform.position.z < 54 || (this.transform.position.z < 57 && canForward())))
                    {
                        direction = new Vector3(0, 0, 1);
                        endpos = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z + 2 * dis);
                        process = 0;
                        isMove = true;
                    }
                    else
                    {
                        direction = new Vector3(0, 0, 1);
                        endpos = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z + dis);
                        process = 0;
                        moveSpeed = 0.1f;
                        isMove = true;
                    }
                }
            }
            if (Input.GetKeyUp(KeyCode.A) && this.transform.position.z > 48f)
            {
                if (!isMove && !die)
                {
                    if (speedUp && this.transform.position.z > 51)
                    {
                        direction = new Vector3(0, 0, -1);
                        endpos = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z - 2 * dis);
                        process = 0;
                        isMove = true;
                    }
                    else
                    {
                        direction = new Vector3(0, 0, -1);
                        endpos = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z - dis);
                        process = 0;
                        moveSpeed = 0.1f;
                        isMove = true;
                    }

                }
            }
            if (Input.GetKeyUp(KeyCode.W) && this.transform.position.x > -2f)
            {
                if (!isMove && !die)
                {
                    if (speedUp && this.transform.position.x > 1)
                    {
                        direction = new Vector3(-1, 0, 0);
                        endpos = new Vector3(this.transform.position.x - 2 * dis, this.transform.position.y, this.transform.position.z);
                        process = 0;
                        isMove = true;
                    }
                    else
                    {
                        direction = new Vector3(-1, 0, 0);
                        endpos = new Vector3(this.transform.position.x - dis, this.transform.position.y, this.transform.position.z);
                        process = 0;
                        isMove = true;
                        moveSpeed = 0.1f;
                    }

                }
            }
            if (Input.GetKeyUp(KeyCode.S) && this.transform.position.x < 7f)
            {
                if (!isMove && !die)
                {
                    if (speedUp && this.transform.position.x < 4)
                    {
                        direction = new Vector3(1, 0, 0);
                        endpos = new Vector3(this.transform.position.x + 2 * dis, this.transform.position.y, this.transform.position.z);
                        process = 0;
                        isMove = true;
                    }
                    else
                    {
                        direction = new Vector3(1, 0, 0);
                        endpos = new Vector3(this.transform.position.x + dis, this.transform.position.y, this.transform.position.z);
                        process = 0;
                        moveSpeed = 0.1f;
                        isMove = true;
                    }
                }
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
                //source.Play();
            }
            else
            {
                canMove = false;
                moveSpeed = 0.1f;
                speedUp = false;
                leftShoe.SetActive(false);
                rightShoe.SetActive(false);
                animator.SetBool("isMove", false);
                PlayerMoveOrder.instance.num = 2;
                isMove = false;
                starNum++;
            }
        }
        if (direction != Vector3.zero)
        {
            _mode.rotation = Quaternion.LookRotation(direction);
        }
    }
    private bool canForward()
    {
        int dirx = (int)doorMove.direction.x;
        if (dirx < 0 && this.transform.position.x < -2f && Door.position.x < -28 && Door.position.x > -31)
        {
            return true;
        }
        if (dirx < 0 && this.transform.position.x < 1f && this.transform.position.x > -2f && Door.position.x > -28 && Door.position.x < -25)
        {
            return true;
        }
        if (dirx < 0 && this.transform.position.x < 4f && this.transform.position.x > 1f && Door.position.x > -25 && Door.position.x < -22)
        {
            return true;
        }
        if (dirx < 0 && this.transform.position.x < 7f && this.transform.position.x > 4f && Door.position.x > -22)
        {
            return true;
        }
        if (dirx > 0 && this.transform.position.x > 7f && Door.position.x > -25 && Door.position.x < -22)
        {
            return true;

        }
        if (dirx > 0 && this.transform.position.x < 7f && this.transform.position.x > 4f && Door.position.x > -28 && Door.position.x < -25)
        {
            return true;

        }
        if (dirx > 0 && this.transform.position.x < 4f && this.transform.position.x > 1f && Door.position.x < -28 && Door.position.x > -31)
        {
            return true;
        }
        if (dirx > 0 && this.transform.position.x < 1f && this.transform.position.x > -2f && Door.position.x < -31f)
        {
            return true;
        }
        return false;
    }
}
