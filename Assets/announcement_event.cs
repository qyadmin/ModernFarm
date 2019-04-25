using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class announcement_event : MonoBehaviour {

    [System.Serializable]
    class announcement
    {
        [SerializeField]
        Text list;
        [SerializeField]
        Text announ;

        public void setvalue()
        {
            announ.text = list.text;
        }
    }

    [SerializeField]
    announcement[] gonggao;

    public void announcement_details()
    {
        foreach (announcement i in gonggao)
        {
            i.setvalue();
        }
    }


}
