using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.IO;

public class Pickup_item : MonoBehaviour
{
    Stored_data data;
    private int gems=0;
    public TextMeshProUGUI textGems;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        data = new Stored_data();
        if(collision.transform.tag=="Gem")
        {
            
            gems++;
            textGems.text = gems.ToString();
            Destroy(collision.gameObject);
            
        }
        if (gems != 0)
        {
            data.gems = gems;
            save();
        }


    }
    private void save()
    {
        string jsonData = JsonUtility.ToJson(data, true);
        File.WriteAllText(Application.persistentDataPath + "/stored_data.json", jsonData);
    }


}
