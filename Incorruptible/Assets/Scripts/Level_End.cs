using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class Level_End : MonoBehaviour
{
    Stored_data data;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            int activeScene = SceneManager.GetActiveScene().buildIndex;
            PlayerPrefs.SetInt("LastLevel", activeScene);
            SceneManager.LoadScene(5);
        }
    }
    




}
