using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using System.IO;

public class Signup_script : MonoBehaviour
{
    public GameObject username;
    public GameObject email;
    public GameObject password;
    public GameObject confirmpassword;
    private string Username;
    private string Email;
    private string Password;
    private string Confirmpassword;
    Saved_Data data;
    public TextMeshProUGUI warning;



    public void Register_Button()
    {
        data = new Saved_Data();
        if (Username != "" && Password != "" && Confirmpassword != "" && Email != "")
        {
            bool Un = false;
            bool Em = false;
            bool Pw = false;
            bool ConfPw = false;

            if (verif(Username) == false)
                warning.text = "Username can only contain letters or numbers";
            else
            {
                if (File.Exists(Application.persistentDataPath + "/" + Username + ".json") == true)
                {
                    warning.text = "Username taken.";
                }
                else
                {
                    Un = true;
                }
                if (Email.Contains("@"))
                {
                    if (Email.Contains("."))
                    {
                        Em = true;
                    }
                    else
                        warning.text = "Email is incorrect.";
                }
                else
                {
                    warning.text = "Email is incorrect.";
                }
                if (Password.Length > 5)
                {
                    Pw = true;
                }
                else
                {
                    warning.text = "Password must be atleast 6 characters long.";
                }
                if (Confirmpassword == Password)
                {
                    ConfPw = true;
                }
                else
                {
                    warning.text = "Passwords don't match.";

                }
                if (Un == true && Em == true && Pw == true && ConfPw == true)
                {
                    data.username = Username;
                    data.password = Password;
                    data.email = Email;
                    string jsonData = JsonUtility.ToJson(data, true);
                    File.WriteAllText(Application.persistentDataPath + "/" + Username + ".json", jsonData);
                    SceneManager.LoadScene(4);
                    PlayerPrefs.SetString("User", Username);
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
                email.GetComponent<TMP_InputField>().Select();
            }
            if (email.GetComponent<TMP_InputField>().isFocused)
            {
                password.GetComponent<TMP_InputField>().Select();
            }
            if (password.GetComponent<TMP_InputField>().isFocused)
            {
                confirmpassword.GetComponent<TMP_InputField>().Select();
            }



        }

        Username = username.GetComponent<TMP_InputField>().text;
        Email = email.GetComponent<TMP_InputField>().text;
        Password = password.GetComponent<TMP_InputField>().text;
        Confirmpassword = confirmpassword.GetComponent<TMP_InputField>().text;

    }

}
