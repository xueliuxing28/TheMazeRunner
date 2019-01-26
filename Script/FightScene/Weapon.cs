using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {
    public float moveSpeed;//移动速度
    private bool isMove = false;//判断是否正在移动
    private Vector3 endpos;//目标位置
    private float process = 0;//标记                              
    private Vector3 direction;//移动方向
    private float dis = 2.5f;
    public GameObject Player1WinPanel;
    public GameObject Player2WinPanel;
    public FightPlayer1Move player1;
    public FightPlayer2Move player2;
    void Update()
    {
        MoveWeppon();
    }
    void MoveWeppon()
    {
        if (player1.canMove||player2.canMove)
        {
            if (this.transform.position.y < -10f)
            {
                if (!isMove)
                {
                    endpos = new Vector3(this.transform.position.x, this.transform.position.y + dis, this.transform.position.z);
                    process = 0;
                    isMove = true;
                }
            }
            else
            {
                if (!isMove)
                {
                    endpos = new Vector3(this.transform.position.x, this.transform.position.y - dis, this.transform.position.z);
                    process = 0;
                    isMove = true;
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
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player1")
        {
            Player2WinPanel.SetActive(true);
            player1.die = true;
        }
        if (other.tag == "Player2")
        {
            Player1WinPanel.SetActive(true);
            player2.die = true;
        }
    }
}
