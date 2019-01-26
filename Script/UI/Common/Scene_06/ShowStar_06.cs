using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowStar_06 : MonoBehaviour {

    public GameObject leftStar;
    public GameObject centerStar;
    public GameObject rightStar;
    public PlayerMove3 player;
    private void Update()
    {
        if (player.foodNum <= 3)
        {
            leftStar.SetActive(true);
            centerStar.SetActive(false);
            rightStar.SetActive(false);
        }
        else if (player.foodNum <5&& player.foodNum > 3)
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
