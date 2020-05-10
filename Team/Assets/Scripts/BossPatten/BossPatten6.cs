﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossPatten6 : MonoBehaviour
{
    public int speed;

    [SerializeField]
    private int bulletsAmount = 10;

    [SerializeField]
    private float startAngle = 90f, endAngle = 270f;

    private Vector2 bulletMoveDirection;

    public GameObject Bullet;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Down();
    }

   void Down()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);
        if (transform.position.y < 0)
        {
            Destroy(gameObject);
            Fire();
        }
         
    }

    private void Fire()
    {

        float angleStep = (endAngle - startAngle) / bulletsAmount;
        float angle = startAngle;

        for (int i = 0; i < bulletsAmount + 1; i++)
        {
            float bulDirX = transform.position.x + Mathf.Sin(angle * Mathf.PI / 180f);
            float bulDirY = transform.position.y + Mathf.Cos(angle * Mathf.PI / 180f);


            Vector3 bulMoveVector = new Vector3(bulDirX, bulDirY, 0f);
            Vector2 bulDir = (bulMoveVector - transform.position).normalized;

            GameObject bul = Instantiate(Bullet, transform.position, Quaternion.identity);
            bul.transform.position = transform.position;
            bul.transform.rotation = transform.rotation;
            bul.GetComponent<BossBullet>().SetMoveDirection(bulDir);
            angle += angleStep;
        }
    }
}