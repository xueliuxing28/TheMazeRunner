﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowStar_02 : MonoBehaviour {
    public GameObject leftStar;
    public GameObject centerStar;
    public GameObject rightStar;
    public PlayerMove1 player;
    private void Update()
    {
        if (player.foodNum <=5)
        {
            leftStar.SetActive(true);
            centerStar.SetActive(false);
            rightStar.SetActive(false);
        }
        else if (player.foodNum <13&& player.foodNum >5)
        {
            leftStar.SetActive(true);
            centerStar.SetActive(true);
            rightStar.SetActive(false);
        }
        else
        {
            leftStar.SetActive(true);
            rightStar.SetActive(true);
            centerStar.SetActive(true);
        }

    }

}
