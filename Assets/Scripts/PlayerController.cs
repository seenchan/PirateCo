using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public GameObject player;
    public GameObject gunPoint;
    public GameObject bullet;
    public float moveSpeed = 750f;
    public float speedLimit = 8f;

    private Rigidbody playerRB;
    private float timerInterval = 0f;

    // Start is called before the first frame update
    void Start()
    {
        playerRB = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (GameManager.Instance.gameMode == 1)
        {
            ShipControl();
        }
        if (GameManager.Instance.gameMode == 2 && GameManager.Instance.winGame == false)
        {
            AimToMouse();
            ShootControl2();
            MoveControl();
        }
        if (GameManager.Instance.gameMode == 2 && GameManager.Instance.winGame == true)
        {

        }
    }

    void MoveControl()
    {
        if (Input.GetKey(KeyCode.D))
        {
            if (playerRB.velocity.x <= speedLimit)
            {
                playerRB.AddForce(Vector3.right * moveSpeed);
            }
        }
        else if (Input.GetKey(KeyCode.A))
        {
            if (playerRB.velocity.x >= -speedLimit)
            {
                playerRB.AddForce(Vector3.left * moveSpeed);
            }
        }

        if (Input.GetKey(KeyCode.W))
        {
            if (playerRB.velocity.z <= speedLimit)
            {
                playerRB.AddForce(Vector3.forward * moveSpeed);
            }
        }
        else if (Input.GetKey(KeyCode.S))
        {
            if (playerRB.velocity.z >= -speedLimit)
            {
                playerRB.AddForce(Vector3.back * moveSpeed);
            }
        }
    }

    void ShipControl()
    {
        if (Input.GetKey(KeyCode.D))
        {
            playerRB.transform.Rotate(Vector3.up);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            playerRB.transform.Rotate(Vector3.down);
        }

        if (Input.GetKey(KeyCode.W))
        {
            if (playerRB.velocity.z <= speedLimit)
            {
                playerRB.AddRelativeForce(Vector3.forward * moveSpeed);
            }
        }
        else if (Input.GetKey(KeyCode.S))
        {
            if (playerRB.velocity.z >= -speedLimit)
            {
                playerRB.AddRelativeForce(Vector3.back * moveSpeed);
            }
        }
    }

    void AimToMouse()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit))
        {
            Debug.DrawRay(ray.origin, ray.direction * 100, Color.yellow);
            player.transform.LookAt(new Vector3(hit.point.x, this.transform.position.y, hit.point.z));
        }
    }

    void ShootControl()
    {
        if (Input.GetMouseButton(0))
        {
            timerInterval += Time.deltaTime;
            if (timerInterval >= GameManager.Instance.gunShootInterval)
            {
                Instantiate(bullet, gunPoint.transform.position, gunPoint.transform.rotation);
                timerInterval = 0;
            }
        }
    }

    void ShootControl2()
    {
        Vector2 randomCircle;
        Vector3 randomCone;
        if (Input.GetMouseButton(0))
        {
            timerInterval += Time.deltaTime;
            if (timerInterval >= GameManager.Instance.gunShootInterval)
            {
                randomCircle = Random.insideUnitCircle * GameManager.Instance.gunAccuracy;
                randomCone = new Vector3(randomCircle.x, randomCircle.y, 10.0f);
                Debug.Log(randomCone);
                Instantiate(bullet, gunPoint.transform.position, gunPoint.transform.rotation);
                timerInterval = 0;
            }
        }
        //Vector2 randomCircle = Random.insideUnitCircle * inherentAccuracy;
        //Vector3 randomCone = new Vector3(randomCircle.x, randomCircle.y, 10.0f);
        //Bullet ejectedAmmo = Instantiate(bullet, muzzle.transform.position, muzzle.transform.rotation);
        //ejectedAmmo.gameObject.transform.LookAt(transform.TransformPoint(randomCone));
    }
}
