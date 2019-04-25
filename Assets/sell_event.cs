using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class sell_event : MonoBehaviour {

    [SerializeField]
    Text tital;
    [SerializeField]
    Text worning_text;


    [SerializeField]
    Button button0, button1;


    string tital_text;

    string worning;

    string id;

    private void Start()
    {
        sell0();
        click();

        button0.onClick.AddListener(delegate() {
            sell0();
        });

        button1.onClick.AddListener(delegate () {
            sell1();
        });
    }


    public void sell0()
    {
        id = "0";
        tital_text = "推广收益";
        worning = "500以上可以出售";
        button0.GetComponent<Image>().color = new Color(0.8f,0.8f,0.8f);
        button1.GetComponent<Image>().color = new Color(1, 1, 1);
    }
    public void sell1()
    {
        id = "1";
        tital_text = "收益转存";
        worning = "1200以上可以出售";
        button0.GetComponent<Image>().color = new Color(1, 1, 1);
        button1.GetComponent<Image>().color = new Color(0.8f, 0.8f, 0.8f);
    }

    public void Exit()
    {
        if (Static.Instance.GetValue("type_id") == "0")
            sell0();
        if (Static.Instance.GetValue("type_id") == "1")
            sell1();
    }


    public void click()
    {
        Static.Instance.AddValue("type_id", id);
        tital.text = tital_text;
        worning_text.text = worning;
    }
}
