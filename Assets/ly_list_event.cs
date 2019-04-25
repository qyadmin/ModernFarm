using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ly_list_event : MonoBehaviour {

    public void getckflag(string value)
    { 
        if (value == "1")
            this.transform.parent.parent.GetComponent<Button>().interactable = true;
        else
            this.transform.parent.parent.GetComponent<Button>().interactable = false;
    }


    [SerializeField]
    Text buttonText;
    public void Getpp_type(string value)
    {
        if (value == "待确认")
            buttonText.text = "区块写入中";
    }
}
