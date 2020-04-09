using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : MonoBehaviour
{
    public Sprite brokenHeart;
    public GameObject explodePrefab;
    public AudioClip dieAudio;

    SpriteRenderer spriteRender;

    private void Awake()
    {
        spriteRender = GetComponent<SpriteRenderer>();
    }
    private void Die()
    {
        spriteRender.sprite = brokenHeart;
        Instantiate(explodePrefab, transform.position, transform.rotation);
        GameControl.Instance.isOver = true;
        AudioSource.PlayClipAtPoint(dieAudio, transform.position);
    }
}
