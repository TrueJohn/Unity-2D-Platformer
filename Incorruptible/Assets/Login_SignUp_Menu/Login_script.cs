using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using System.IO;


public class Login_script : MonoBehaviour
{
    public GameObject username;
    public GameObject password;
    private string Username;
    private string Password;
    Saved_Data data;
    public TextMeshProUGUI warning;



    public void Login_Button()
    {
        
        if (Username != "" && Password != "")
        {
 
            if (verif(Username) == false)
                warning.text = "Username can only contain letters or numbers";
            else
            {
                if (File.Exists(Application.persistentDataPath + "/" + Username + ".json") == true)
                {
                    data = JsonUtility.FromJson<Saved_Data>(File.ReadAllText(Application.persistentDataPath + "/"+Username+".json"));
                    if (data.password != Password)
                        warning.text = "Invalid password";
                    else if (data.password == Password && data.username == Username)
                    {
                        PlayerPrefs.SetString("User", Username);
                        SceneManager.LoadScene(4);
                    }
                }
                else
                {
                    warning.text = "Username doesn't exist.";
                }
               
               
                
                
            }

        }
        else
        {
            warning.text = "Please complete all fields";
        }


    }
    private bool verif(string x)
    {
        for (int i = 0; i < x.Length; i++)
        {
            if (!((x[i] >= 'a' && x[i] <= 'z') || (x[i] >= 'A' && x[i] <= 'Z') || (x[i] >= '0' && x[i] <= '9')))
                return false;
        }
        return true;
    }
    private void Awake()
    {
        warning.text = " ";
    }
    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (username.GetComponent<TMP_InputField>().isFocused)
            {
                password.GetComponent<TMP_InputField>().Select();
            }
            if (password.GetComponent<TMP_InputField>().isFocused)
            {
                username.GetComponent<TMP_InputField>().Select();
            }
            


        }

        Username = username.GetComponent<TMP_InputField>().text;
        Password = password.GetComponent<TMP_InputField>().text;
      

    }


}
