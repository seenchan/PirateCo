using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public GameObject bullet;

    private GameObject player;
    private GameObject gunPoint;
    private float timerInterval = 0f;

    // Start is called before the first frame update
    void Start()
    {
        gunPoint = this.gameObject.transform.GetChild(0).GetChild(0).gameObject;
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        AimToPlayer();
        ShootControl();
    }
    
    void AimToPlayer()
    {
        this.transform.LookAt(new Vector3(player.transform.position.x, this.transform.position.y, player.transform.position.z));
    }

    void ShootControl()
    {
        timerInterval += Time.deltaTime;
        if (timerInterval >= GameManager.Instance.enemyShootInterval)
        {
            Instantiate(bullet, gunPoint.transform.position, gunPoint.transform.rotation);
            timerInterval = 0;
        }
    }
}
