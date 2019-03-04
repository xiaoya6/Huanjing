using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static GameManager Instance;

    public bool IsGameStart { get; set; }
    public bool isGameOver {get;set;}

    public void Awake()
    {
        Instance = this;
    }

}
