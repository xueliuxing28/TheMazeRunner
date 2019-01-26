using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComShowLife_03 : MonoBehaviour {

    public PlayerMove2 player;
    public UILabel life;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        life.text = "体力*" + player.foodNum;
    }
}
