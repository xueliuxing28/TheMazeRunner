using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaoXiangCon : MonoBehaviour {
    public FightPlayer1Move player1;
    public FightPlayer2Move player2;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player1")
        {
            player1.starNum += 4;
        }
        if (other.tag == "Player2")
        {
            player2.starNum += 4;
        }
        Destroy(this.gameObject);
    }
}
