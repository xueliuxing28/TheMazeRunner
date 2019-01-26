using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtShowLife : MonoBehaviour {
    public UILabel life;
    void Update()
    {
        life.text = "体力*" + FoodNum.foodNum.food;
    }
}
