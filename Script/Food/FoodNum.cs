using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FoodNum : MonoBehaviour {
    public static FoodNum foodNum;
    public int food=10;
    int index = 0;
    private void Awake()
    {
        if (foodNum!=null)
        {
            Destroy(this);
        }
        foodNum = this;
        index = SceneManager.GetActiveScene().buildIndex;
        if (index != 0)
        {
            DontDestroyOnLoad(this.gameObject);
        }
    }
}
