using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HijackModeDetector : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider col)
    {
        //Debug.Log(col.name);
        if (col.name == "PirateShip")
        {
            GameManager.Instance.gameMode = 2;
            SceneManager.LoadScene("ShipBattle");
        }
    }
}
