using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowStar : MonoBehaviour {
    public FightPlayer1Move player1;
    public FightPlayer2Move player2;
    public UILabel Player1Star;
    public UILabel Player2Star;
    void Update()
    {
        Player1Star.text = "法力水晶*" + player1.starNum;
        Player2Star.text = "法力水晶*" +player2.starNum;
    }
}
