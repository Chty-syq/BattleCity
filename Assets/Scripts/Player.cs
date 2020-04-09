using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed = 3;
    public float attackCD = 0.4f;
    public float defendCD = 3.0f;
    public GameObject bulletPrefab;
    public GameObject defendPrefab;
    public GameObject explodePrefab;

    float attackTime;
    float defendTime;
    bool isDefended = true;

    private void Update()
    {
        if (GameControl.instance.isOver) return;
        if (attackTime >= attackCD) {
            Attack();
        }
        else attackTime += Time.deltaTime;
        if (isDefended) {
            defendTime += Time.deltaTime;
            if (defendTime >= defendCD) {
                isDefended = false;
            }
            defendPrefab.SetActive(true);
        }
        else defendPrefab.SetActive(false);
    }
    private void FixedUpdate()
    {
        if (GameControl.instance.isOver) return;
        Move();
    }
    private void Move()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        transform.Translate(Vector3.right * h * moveSpeed * Time.deltaTime, Space.World);
        switch (h) {
            case  1: transform.rotation = Quaternion.Euler(0f, 0f, 270); return;
            case -1: transform.rotation = Quaternion.Euler(0f, 0f, 90);  return;
        }
        transform.Translate(Vector3.up    * v * moveSpeed * Time.deltaTime, Space.World);
        switch (v) {
            case  1: transform.rotation = Quaternion.Euler(0f, 0f, 0);   break;
            case -1: transform.rotation = Quaternion.Euler(0f, 0f, 180); break;
        }
    }
    private void Attack()
    {
        if (Input.GetKeyDown(KeyCode.Space)) {
            Instantiate(bulletPrefab, transform.position, transform.rotation);
            attackTime = 0;
        }
    }
    private void Die()
    {
        if (isDefended) return;
        Instantiate(explodePrefab, transform.position, transform.rotation);
        Destroy(gameObject);
        GameControl.instance.isDead = true;
    }
}
