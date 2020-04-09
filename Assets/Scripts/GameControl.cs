using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameControl : MonoBehaviour
{
    public int life = 3;
    public int score = 0;
    public bool isDead = false;
    public bool isOver = false;
    public GameObject born;
    public GameObject over;
    public Text scoreText;
    public Text lifeText;
    public static GameControl instance;
    public static GameControl Instance { get => instance; set => instance = value; }

    private void Awake()
    {
        Instance = this;
    }
    private void Update()
    {
        if (isOver) {
            over.SetActive(true);
            if (Input.GetKeyDown(KeyCode.Space)) {
                SceneManager.LoadScene(0);
            }
        }
        if (isDead) Recover();
        scoreText.text = score.ToString();
        lifeText.text = life.ToString();
    }
    private void Recover()
    {
        if (life <= 0) {
            isOver = true;
            return;
        }
        else {
            life--;
            GameObject Player = Instantiate(born, new Vector3(-2, -8, 0), Quaternion.identity);
            Player.GetComponent<Born>().createPlayer = true;
            isDead = false;
        }
    }
}
