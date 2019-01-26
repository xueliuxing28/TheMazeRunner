using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComShowLife_06 : MonoBehaviour {

    public PlayerMove3 player;
    public UILabel life;

    // Update is called once per frame
    void Update()
    {
        life.text = "体力*" + player.foodNum;
    }
}
