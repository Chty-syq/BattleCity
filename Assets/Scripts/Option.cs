using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Option : MonoBehaviour
{
    int choice = 0;
    public Transform[] pos;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow)) {
            choice--;
            choice = Mathf.Max(choice, 0);
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow)) {
            choice++;
            choice = Mathf.Min(choice, 2);
        }
        transform.position = pos[choice].position;
        if (choice == 0 && Input.GetKeyDown(KeyCode.Space)) {
            SceneManager.LoadScene(1);
        }
        if (choice == 2 && Input.GetKeyDown(KeyCode.Space)) {
            Application.Quit();
        }
    }
}
