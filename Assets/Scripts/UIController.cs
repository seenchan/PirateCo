using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{

    private Canvas winUI;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "ShipBattle")
        {
            if (GameManager.Instance.gameMode == 2)
            {
                GameObject tempObj = GameObject.Find("WinUI");
                winUI = tempObj.GetComponent<Canvas>();
            }

            if (GameManager.Instance.winGame == true)
            {
                winUI.enabled = true;
            }
            else if (GameManager.Instance.winGame == false)
            {
                winUI.enabled = false;
            }

        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("SeaBattle");
    }
}
