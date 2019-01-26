using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FightPlayer2Move : MonoBehaviour {
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
    public Wall1Move doorMove;
    public int foodNum = 20;
    public bool die = false;
    public GameObject weapon;//使用武器
    private bool speedUp = false;//加速判断
    public GameObject leftShoe;
    public GameObject rightShoe;
    public int starNum;
    private void Start()
    {
        starNum = 1;
        int index = SceneManager.GetActiveScene().buildIndex;       
    }
    void Update()
    {
        Move();
        if (starNum>=4)
        {
            bool yes = true;
            if (Input.GetKeyDown(KeyCode.Keypad1))
            {
                weapon.SetActive(true);
                if (yes)
                {
                    starNum-= 4;
                }
                yes = false;
            }
        }
        if (starNum>=4)
        {
            bool yes = true;
            if (Input.GetKeyDown(KeyCode.Keypad2))//加速开关不全条件
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
        if (PlayerMoveOrder.instance.num==2)
        {
            if ((Input.GetKeyUp(KeyCode.RightArrow) && this.transform.position.z < 57f))
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
            if (Input.GetKeyUp(KeyCode.LeftArrow) && this.transform.position.z > 48f || (Input.GetKeyDown(KeyCode.LeftArrow) && canForward() && this.transform.position.z <47f))
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
            if (Input.GetKeyUp(KeyCode.UpArrow) && this.transform.position.x > -2f)
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
            if (Input.GetKeyUp(KeyCode.DownArrow) && this.transform.position.x < 7f)
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
            }
            else
            {
                canMove = false;
                moveSpeed = 0.1f;
                speedUp = false;
                leftShoe.SetActive(false);
                rightShoe.SetActive(false);
                animator.SetBool("isMove", false);
                isMove = false;
                PlayerMoveOrder.instance.num = 1;
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
        if (dirx < 0 && this.transform.position.x < -2f && Door.position.x >28 && Door.position.x <31)
        {
            return true;
        }
        if (dirx < 0 && this.transform.position.x < 1f && this.transform.position.x > -2f && Door.position.x <32 && Door.position.x>29)
        {
            return true;
        }
        if (dirx < 0 && this.transform.position.x < 4f && this.transform.position.x > 1f && Door.position.x >35 && Door.position.x < 32)
        {
            return true;
        }
        if (dirx < 0 && this.transform.position.x < 7f && this.transform.position.x > 4f && Door.position.x > 37)
        {
            return true;
        }
        if (dirx > 0 && this.transform.position.x > 7f && Door.position.x > 34 && Door.position.x < 37)
        {
            return true;

        }
        if (dirx > 0 && this.transform.position.x < 7f && this.transform.position.x > 4f && Door.position.x > 31&& Door.position.x <34)
        {
            return true;

        }
        if (dirx > 0 && this.transform.position.x < 4f && this.transform.position.x > 1f && Door.position.x <31&& Door.position.x >28)
        {
            return true;
        }
        if (dirx > 0 && this.transform.position.x < 1f && this.transform.position.x > -2f && Door.position.x < 28)
        {
            return true;
        }
        return false;
    }
}
