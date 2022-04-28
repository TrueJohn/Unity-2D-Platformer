using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Respawn_Player: MonoBehaviour
{

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.CompareTag("Player"))
        {

            PlayerPrefs.SetInt("LastLevel", SceneManager.GetActiveScene().buildIndex);
            SceneManager.LoadScene(3);
        }
    }

}
