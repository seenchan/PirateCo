using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    private int enemyKilled = 0;

    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * 1000);
    }

    // Update is called once per frame
    void FixedUpdate()
    {

    }

    void OnCollisionEnter(Collision col)
    {
        Destroy(this.gameObject);
        if (col.gameObject.tag == "Enemy" && this.gameObject.tag == "PlayerBullet")
        {
            Destroy(col.gameObject);
        }
        if (col.gameObject.tag == "Civilian" && this.gameObject.tag == "PlayerBullet")
        {
            Destroy(col.gameObject);
        }

        if (col.gameObject.tag == "Player" && this.gameObject.tag == "EnemyBullet")
        {
            Destroy(col.gameObject);
            GameManager.Instance.playerDead = true;
        }
    }
}
