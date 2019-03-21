using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager> {

    protected override void Init()
    {
    }

    public int gameMode = 2;

    public float gunAccuracy;
    public float gunShootInterval;

    public float enemyShootInterval;
    public bool winGame = false;
    public bool playerDead = false;

    private GameObject[] enemyList;

    // Use this for initialization
    void Start () {
        winGame = false;
        playerDead = false;
	}
	
	// Update is called once per frame
	void Update () {
        enemyList = GameObject.FindGameObjectsWithTag("Enemy");
        if (enemyList.Length == 0 && SceneManager.GetActiveScene().name == "ShipBattle")
        {
            winGame = true;
        }

        if (playerDead == true)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
	}
}
