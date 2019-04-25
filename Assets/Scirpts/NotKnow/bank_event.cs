using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class bank_event : MonoBehaviour {

    [SerializeField]
    Dropdown banklist;

    public void getjson(object bank)
    {
        for (int i =0;i< banklist.options.Count;i++)
        {
            Debug.Log(bank.ToString()+"   "+ banklist.options[i].text);
            if (bank.ToString() == banklist.options[i].text)
            {
                banklist.value = i;
                break;
            }
                
        }
        isbank();
    }

    [SerializeField]
    Transform Qrcode;
    [SerializeField]
    Camera_Contral cam;
    public void isbank()
    {
        if (banklist.value > 2)
        {
            Qrcode.gameObject.SetActive(false);
            cam.isworning = false;
        }
        else
        {
            Qrcode.gameObject.SetActive(true);
            cam.isworning = true;
        }
    }


}
