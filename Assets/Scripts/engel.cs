using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Engel : MonoBehaviour

{
    private Scene scene;

    private void Awake()
    {
       scene = SceneManager.GetActiveScene();
        Debug.Log(scene.name);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Score.lives--;
            SceneManager.LoadScene(scene.name);
            Score.totalScore = 0;
        }
    }
}
