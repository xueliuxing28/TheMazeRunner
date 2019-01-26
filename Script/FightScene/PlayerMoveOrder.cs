using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveOrder : MonoBehaviour {
    public static PlayerMoveOrder instance;
    public int num;
	void Start () {
        if (instance==null)
        {
            instance = this;
        }
        num = 1;
	}

}
