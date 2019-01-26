using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShoeNum : MonoBehaviour {
    public static ShoeNum shoeNum;
    public int num;
    void Start()
    {
        if (PlayerPrefs.HasKey("shoeNum"))
        {
            num = PlayerPrefs.GetInt("shoeNum");
        }
        else
        {
            PlayerPrefs.SetInt("shoeNum", 0);
            num= PlayerPrefs.GetInt("shoeNum");
        }
        if (shoeNum != null)
        {
            Destroy(this);
            return;
        }
        shoeNum = this;
        DontDestroyOnLoad(this.gameObject);
    }
}
