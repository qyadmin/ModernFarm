using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class sell_event : MonoBehaviour
{

    [SerializeField]
    Text tital;
    [SerializeField]
    Text worning_text;


    [SerializeField]
    Button button0, button1, button2;

    public Color[] BgColors;


    string tital_text;

    string worning;

    string id;

    private void Start()
    {
        sell0();
        click();

        button0.onClick.AddListener(delegate ()
        {
            sell0();
        });

        button1.onClick.AddListener(delegate ()
        {
            sell1();
        });
        button2.onClick.AddListener(delegate ()
        {
            sell2();
        });
    }


    public void sell0()
    {
        id = "0";
        tital_text = "推广收益";
        worning = "500以上可以出售";
        button0.GetComponent<Image>().color = BgColors[0];
        button1.GetComponent<Image>().color = BgColors[1];
        button2.GetComponent<Image>().color = BgColors[1];
    }
    public void sell1()
    {
        id = "1";
        tital_text = "转存收益";
        worning = "1200以上可以出售";
        button0.GetComponent<Image>().color = BgColors[1];
        button1.GetComponent<Image>().color = BgColors[0];
        button2.GetComponent<Image>().color = BgColors[1];
    }

    public void sell2()
    {
        id = "2";
        tital_text = "团队收益";
        worning = "1200以上可以出售";
        button0.GetComponent<Image>().color = BgColors[1];
        button1.GetComponent<Image>().color = BgColors[1];
        button2.GetComponent<Image>().color = BgColors[0];
    }

    public void Exit()
    {
        if (Static.Instance.GetValue("type_id") == "0")
            sell0();
        if (Static.Instance.GetValue("type_id") == "1")
            sell1();
        if (Static.Instance.GetValue("type_id") == "2")
            sell2();
    }


    public void click()
    {
        Static.Instance.AddValue("type_id", id);
        tital.text = tital_text;
        worning_text.text = worning;
    }
}
