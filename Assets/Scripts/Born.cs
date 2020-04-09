using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Born : MonoBehaviour
{
    public GameObject playerPrefab;
    public GameObject[] enemyPrefabList;
    public bool createPlayer = false;
    private void Start()
    {
        Invoke("BornTank", 1f);
        Destroy(gameObject, 1f);
    }
    private void BornTank()
    {
        if (createPlayer) {
            Instantiate(playerPrefab, transform.position, Quaternion.identity);
        }
        else {
            int type = Random.Range(0, 2);
            Instantiate(enemyPrefabList[type], transform.position, Quaternion.identity);
        }
    }
}
