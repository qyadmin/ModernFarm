using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class bank_list_event : MonoBehaviour {

    [SerializeField]
    Sprite wx, zfb,yhk;

    [SerializeField]
    Image img;



    public void getzf_type(string value)
    {
        switch (value)
        {
            case "微信":
                img.sprite = wx;
                break;
            case "支付宝":
                img.sprite = zfb;
                break;
            default:
                img.sprite = yhk;
                break;
        }
    }
}
