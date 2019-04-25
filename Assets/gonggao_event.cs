using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gonggao_event : MonoBehaviour {


    [SerializeField]
    Transform gg;


    public void getGongGaoId(object value)
    {
        if (value.ToString() != loadGongGaoid())
        {
            gg.gameObject.SetActive(true);
        }
        Static.Instance.DeleteFile(Application.persistentDataPath, "gonggaoid.txt");
        Static.Instance.CreateFile(Application.persistentDataPath, "gonggaoid.txt", value.ToString());
    }

    public string loadGongGaoid()
    {
        ArrayList infoall = Static.Instance.LoadFile(Application.persistentDataPath, "gonggaoid.txt");
        string sr = null;
        if (infoall == null)
            return string.Empty;
        foreach (string str in infoall)
        {
            sr += str;
        }
        return sr;
    }
}
