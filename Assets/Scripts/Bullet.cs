using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float moveSpeed = 10;
    public bool isPlayerBullet;

    private void Update()
    {
        transform.Translate(transform.up * moveSpeed * Time.deltaTime, Space.World);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.tag) {
            case "Wall":
                Destroy(collision.gameObject);
                Destroy(this.gameObject);
                break;
            case "Barrier":
                Destroy(this.gameObject);
                break;
            case "Tank":
                if (!isPlayerBullet) {
                    collision.SendMessage("Die");
                    Destroy(this.gameObject);
                }
                break;
            case "Enemy":
                if (isPlayerBullet) {
                    collision.SendMessage("Die");
                    Destroy(this.gameObject);
                }
                break;
            case "Heart":
                collision.SendMessage("Die");
                Destroy(this.gameObject);
                break;
            case "Bullet":
                Destroy(collision.gameObject);
                Destroy(this.gameObject);
                break;
            default:
                break;
        }
    }
}
