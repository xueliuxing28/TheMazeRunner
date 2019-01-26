using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMove2 : MonoBehaviour {

    public Animator animator;
    public float moveSpeed;//移动速度
    public Transform _mode;//控制旋转
    //public AudioSource source;//音效
    public  bool isMove = false;//判断是否正在移动
    private Vector3 endpos;//目标位置
    private float process = 0;//标记
    private Vector3 direction;//移动方向
    public bool canMove = false;//判断障碍物的移动
    public int foodNum = 20;//闯关基础食物数量
    public bool isCommonScene = false;
    public bool isExtremeScene = false;
    public bool die = false;
    public GameObject weapon;//使用武器
    private bool speedUp = false;//加速判断
    public GameObject leftShoe;
    public GameObject rightShoe;
    private void Start()
    {
        int index = SceneManager.GetActiveScene().buildIndex;
        if (index > 7)
        {
            isCommonScene = true;
        }
        else
        {
            isExtremeScene = true;
        }
       
    }
    void Update () {
        Move();
        if (foodNum <= 0)
        {
            die = true;
        }
        if (WeaponNum.weaponNum.num > 0)
        {
            if (Input.GetKeyDown(KeyCode.P))
            {
                weapon.SetActive(true);
            }
        }
        if (Input.GetKeyDown(KeyCode.I) && ShoeNum.shoeNum.num > 0)//加速开关不全条件
        {
            speedUp = true;
            moveSpeed = 0.2f;
            leftShoe.SetActive(true);
            rightShoe.SetActive(true);
            ShoeNum.shoeNum.num = ShoeNum.shoeNum.num - 1;
            if (PlayerPrefs.HasKey("shoeNum"))
            {
                int beforeShoeNum=PlayerPrefs.GetInt("shoeNum");
                PlayerPrefs.SetInt("shoeNum", beforeShoeNum - 1);
            }
        }
    }
    void Move()
    {
        if ((Input.GetKeyUp(KeyCode.D) && this.transform.position.z < 57f) || (Input.GetKeyDown(KeyCode.D) && canForward() && this.transform.position.z > 57f))
        {
            if (!isMove&&!die)
            {
                if (speedUp&&(this.transform.position.z<53|| this.transform.position.z<57&&this.transform.position.x>7))
                {
                    direction = new Vector3(0, 0, 1);
                    endpos = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z + 7.6f);
                    process = 0;
                    isMove = true;
                    if (isExtremeScene)
                    {
                        FoodNum.foodNum.food--;
                    }
                    else if (isCommonScene)
                    {
                        foodNum--;
                    }
                }
                else
                {
                    direction = new Vector3(0, 0, 1);
                    endpos = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z + 3.8f);
                    process = 0;
                    moveSpeed = 0.1f;
                    isMove = true;
                    if (isExtremeScene)
                    {
                        FoodNum.foodNum.food--;
                    }
                    else if (isCommonScene)
                    {
                        foodNum--;
                    }
                }
               
            }
        }
        if (Input.GetKeyUp(KeyCode.A) && this.transform.position.z > 48f)
        {
            if (!isMove && !die)
            {
                if (speedUp&&this.transform.position.z>53)
                {
                    direction = new Vector3(0, 0, -1);
                    endpos = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z - 7.6f);
                    process = 0;
                    isMove = true;
                    if (isExtremeScene)
                    {
                        FoodNum.foodNum.food--;
                    }
                    else if (isCommonScene)
                    {
                        foodNum--;
                    }
                }
                else
                {
                    direction = new Vector3(0, 0, -1);
                    endpos = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z - 3.8f);
                    process = 0;
                    moveSpeed = 0.1f;
                    isMove = true;
                    if (isExtremeScene)
                    {
                        FoodNum.foodNum.food--;
                    }
                    else if (isCommonScene)
                    {
                        foodNum--;
                    }
                }             
            }
        }
        if (Input.GetKeyUp(KeyCode.W) && this.transform.position.x > -2f)
        {
            if (!isMove && !die)
            {
                if (speedUp&&this.transform.position.x>2)
                {
                    direction = new Vector3(-1, 0, 0);
                    endpos = new Vector3(this.transform.position.x -7.6f, this.transform.position.y, this.transform.position.z);
                    process = 0;
                    isMove = true;
                    if (isExtremeScene)
                    {
                        FoodNum.foodNum.food--;
                    }
                    else if (isCommonScene)
                    {
                        foodNum--;
                    }
                }
                else
                {
                    direction = new Vector3(-1, 0, 0);
                    endpos = new Vector3(this.transform.position.x - 3.8f, this.transform.position.y, this.transform.position.z);
                    process = 0;
                    moveSpeed = 0.1f;
                    isMove = true;
                    if (isExtremeScene)
                    {
                        FoodNum.foodNum.food--;
                    }
                    else if (isCommonScene)
                    {
                        foodNum--;
                    }
                }
             
            }
        }
        if (Input.GetKeyUp(KeyCode.S) && this.transform.position.x < 7f)
        {
            if (!isMove && !die)
            {
                if (speedUp&&this.transform.position.x<2)
                {
                    direction = new Vector3(1, 0, 0);
                    endpos = new Vector3(this.transform.position.x + 7.6f, this.transform.position.y, this.transform.position.z);
                    process = 0;
                    isMove = true;
                    if (isExtremeScene)
                    {
                        FoodNum.foodNum.food--;
                    }
                    else if (isCommonScene)
                    {
                        foodNum--;
                    }
                }
                else
                {
                    direction = new Vector3(1, 0, 0);
                    endpos = new Vector3(this.transform.position.x + 3.8f, this.transform.position.y, this.transform.position.z);
                    process = 0;
                    moveSpeed = 0.1f;
                    isMove = true;
                    if (isExtremeScene)
                    {
                        FoodNum.foodNum.food--;
                    }
                    else if (isCommonScene)
                    {
                        foodNum--;
                    }
                }
              
            }
        }
        if (isMove)
        {
            process += Time.deltaTime * moveSpeed;
            this.transform.position = Vector3.Lerp(this.transform.position, endpos, process);
            if (Vector3.Distance(this.transform.position, endpos) > 0.05f)
            {
                animator.SetBool("isMove", true);
                //source.Play();
                canMove = true;
            }
            else
            {
                canMove = false;
                moveSpeed = 0.1f;
                speedUp = false;
                leftShoe.SetActive(false);
                rightShoe.SetActive(false);
                animator.SetBool("isMove", false);
                //source.Stop();
                isMove = false;
            }
        }
        if (direction != Vector3.zero)
        {
            _mode.rotation = Quaternion.LookRotation(direction);
        }
    }
    private bool canForward()
    {
        if (this.transform.position.x > 7)
        {
            return true;
        }
        return false;
    }
}
