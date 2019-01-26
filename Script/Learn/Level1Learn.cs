using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1Learn : MonoBehaviour {
    public PlayerMove1 player;
    public GameObject[] showHelp;
    bool show1 = true;
    bool show2 = false;
    bool show3 = false;
	void Start () {
        player.die = true;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyUp(KeyCode.Return) && show3)
        {
            showHelp[2].SetActive(false);
            player.die = false;
            show3 = false;
        }
        if (Input.GetKeyUp(KeyCode.Return) && show2)
        {
            showHelp[1].SetActive(false);
            showHelp[2].SetActive(true);
            show2 = false;
            show3 = true;
        }
        if (Input.GetKeyUp(KeyCode.Return) && show1)
        {
            showHelp[0].SetActive(false);
            showHelp[1].SetActive(true);
            show1 = false;
            show2 = true;
        }
    }
}
