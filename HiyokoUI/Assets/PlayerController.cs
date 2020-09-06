using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.AI;
using Object = UnityEngine.Object;

public class PlayerController : MonoBehaviour
{
    public float speed = 8f;

    public float moveableRange = 5.5f;

    public GameObject cannonBall;
    public Transform spawnPoint;
    public float power = 1000f;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Input.GetAxisRaw("Horizontal")* speed * Time.deltaTime,0,0);
        transform.position = new Vector2(Mathf.Clamp(transform.position.x, -moveableRange, moveableRange)
            , transform.position.y);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        GameObject newBullet = Instantiate(cannonBall, spawnPoint.position,Quaternion.identity) as GameObject;
        newBullet.GetComponent<Rigidbody2D>().AddForce(Vector3.up * power);
    }
}
