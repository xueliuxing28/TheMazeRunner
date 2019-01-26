using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowSpeed : MonoBehaviour {
    public UILabel Shoe;
	void Update () {
        Shoe.text = "加速*" + ShoeNum.shoeNum.num;
    }
}
