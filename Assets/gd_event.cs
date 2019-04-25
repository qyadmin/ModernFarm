using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gd_event : MonoBehaviour {

    public void gethf(string value)
    {
        if (value == string.Empty)
        {
            this.GetComponent<Text>().text = "暂无回复";
        }
    }
}
