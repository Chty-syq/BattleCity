using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateMap : MonoBehaviour
{
    public GameObject[] itemPrefab;
    //0.Heart
    //1.Wall
    //2.Barrier
    //3.Grass
    //4.River
    //5.AirBarrier
    //6.Born
    List<Vector3> itemPositionList = new List<Vector3>();
    private void Awake()
    {
        CreateItem(itemPrefab[0], new Vector3(0, -8, 0), Quaternion.identity);
        CreateItem(itemPrefab[1], new Vector3(1, -8, 0), Quaternion.identity);
        CreateItem(itemPrefab[1], new Vector3(1, -7, 0), Quaternion.identity);
        CreateItem(itemPrefab[1], new Vector3(0, -7, 0), Quaternion.identity);
        CreateItem(itemPrefab[1], new Vector3(-1, -7, 0), Quaternion.identity);
        CreateItem(itemPrefab[1], new Vector3(-1, -8, 0), Quaternion.identity);
        for(int i = -11; i <= 11; ++i) {
            CreateItem(itemPrefab[5], new Vector3(i, 9, 0), Quaternion.identity);
            CreateItem(itemPrefab[5], new Vector3(i, -9, 0), Quaternion.identity);
        }
        for(int i = -9; i <= 9; ++i) {
            CreateItem(itemPrefab[5], new Vector3(11, i, 0), Quaternion.identity);
            CreateItem(itemPrefab[5], new Vector3(-11, i, 0), Quaternion.identity);
        }
        for(int i = 1; i <= 20; ++i) {
            CreateItem(itemPrefab[1], RandomPosition(), Quaternion.identity);
            CreateItem(itemPrefab[2], RandomPosition(), Quaternion.identity);
            CreateItem(itemPrefab[3], RandomPosition(), Quaternion.identity);
            CreateItem(itemPrefab[4], RandomPosition(), Quaternion.identity);
        }
        GameObject Player = CreateItem(itemPrefab[6], new Vector3(-2, -8, 0), Quaternion.identity);
        Player.GetComponent<Born>().createPlayer = true;
        CreateItem(itemPrefab[6], new Vector3(-10, 8, 0), Quaternion.identity);
        CreateItem(itemPrefab[6], new Vector3(0, 8, 0), Quaternion.identity);
        CreateItem(itemPrefab[6], new Vector3(10, 8, 0), Quaternion.identity);
        InvokeRepeating("CreateEnemy", 4, 5);
    }
    private GameObject CreateItem(GameObject item, Vector3 position, Quaternion rotation)
    {
        GameObject itemGo = Instantiate(item, position, rotation);
        itemGo.transform.SetParent(transform);
        itemPositionList.Add(position);
        return itemGo;
    }
    private Vector3 RandomPosition()
    {
        Vector3 position=new Vector3();
        while (true) {
            position.x = Random.Range(-9, 10);
            position.y = Random.Range(-7, 8);
            position.z = 0;
            if (!VisPosition(position)) break;
        }
        return position;
    }
    private bool VisPosition(Vector3 position)
    {
        for(int i = 0; i < itemPositionList.Count; ++i) {
            if (itemPositionList[i] == position) {
                return true;
            }
        }
        return false;
    }
    private void CreateEnemy()
    {
        Vector3 position=new Vector3();
        int type = Random.Range(0, 3);
        switch (type) {
            case 0: position = new Vector3(-10, 8, 0); break;
            case 1: position = new Vector3(0, 8, 0);   break;
            case 2: position = new Vector3(10, 8, 0);  break;
        }
        CreateItem(itemPrefab[6], position, Quaternion.identity);
    }
}
