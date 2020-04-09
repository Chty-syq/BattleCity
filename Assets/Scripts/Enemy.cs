using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float moveSpeed = 3;
    public float attackCD = 3.0f;
    public float veerCD = 4.0f;
    public GameObject bulletPrefab;
    public GameObject explodePrefab;
    float v = 0;
    float h = 0;
    float attackTime;
    float veerTime;
    private void Awake()
    {
        veerTime = veerCD;
    }
    private void Update()
    {
        if (attackTime >= attackCD) {
            Attack();
        }
        else attackTime += Time.deltaTime;
    }
    private void FixedUpdate()
    {
        Move();
    }
    private void Move()
    {
        if (veerTime >= veerCD) {
            int type = Random.Range(0, 8);
            if (type == 0) { v = 1; h = 0; }
            else if (type <= 2) { v = 0; h = -1; }
            else if (type <= 4) { v = 0; h = 1; }
            else if (type <= 7) { v = -1; h = 0; }
            veerTime = 0;
        }
        else veerTime += Time.fixedDeltaTime;
        transform.Translate(Vector3.right * h * moveSpeed * Time.deltaTime, Space.World);
        switch (h) {
            case 1: transform.rotation = Quaternion.Euler(0f, 0f, 270); return;
            case -1: transform.rotation = Quaternion.Euler(0f, 0f, 90); return;
        }
        transform.Translate(Vector3.up * v * moveSpeed * Time.deltaTime, Space.World);
        switch (v) {
            case 1: transform.rotation = Quaternion.Euler(0f, 0f, 0); break;
            case -1: transform.rotation = Quaternion.Euler(0f, 0f, 180); break;
        }
    }
    private void Attack()
    {
        Instantiate(bulletPrefab, transform.position, transform.rotation);
        attackTime = 0;
    }
    private void Die()
    {
        Instantiate(explodePrefab, transform.position, transform.rotation);
        Destroy(gameObject);
        GameControl.instance.score++;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy") {
            veerTime = veerCD;
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy") {
            veerTime = veerCD;
        }
    }
}
