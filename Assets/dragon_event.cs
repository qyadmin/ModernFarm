using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class dragon_event : MonoBehaviour {

    [SerializeField]
    Sprite[] dragon;
    [SerializeField]
    Image imag,lyimage;

    public void getid(string id)
    {
        imag.sprite = dragon[int.Parse(id) - 1];
    }


    Timer _timer = new Timer(1);
    int time;
    public void GetTime()
    {
        this.GetComponent<Text>().text = string.Empty;
        _timer.EndTimer();
        _timer.tickEvnet -= time_event;
        time = int.Parse(Static.Instance.GetValue("end_time")) - int.Parse(Static.Instance.GetValue("now_time"));
        _timer.tickEvnet += time_event;
        _timer.StartTimer();
    }

    void time_event()
    {
        if (time <= 0)
        {
            _timer.EndTimer();
        }
        else
        {
            if(time <= 90)
            click.GetComponentInChildren<Text>().text = string.Format("{0}<color=#8F362CFF>{1}</color>'s", active,time);

            time--;
            if (time <= 0)
                refresh.Get();
        }
    }

    private void Update()
    {
        _timer.UpdateRepeatTimer(Time.deltaTime);
    }

    public void Gettime(string value)
    {
        _timer.tickEvnet -= time_event;
        _timer.EndTimer();
        Debug.Log(value);
        time = int.Parse(value);
        _timer.tickEvnet += time_event;
        _timer.StartTimer();
    }



    [SerializeField]
    Sprite button1, button2, button3, button4;
    [SerializeField]
    Button click;

    [SerializeField]
    HttpModel yuyue,lingyang;

    [SerializeField]
    HttpModel refresh;

    string active;
    public void bt_type(string value)
    {
        active = value;
        click.GetComponentInChildren<Text>().text = active;
        string time = this.transform.parent.Find("time").GetComponent<Text>().text;
        Gettime(time);

        if (value == "预约")
        {
            click.GetComponent<Image>().sprite = button1;
            click.onClick.AddListener(delegate() {
                Static.Instance.AddValue("long_id", transform.parent.Find("id").GetComponent<Text>().text);
                yuyue.Get();
            });
        }

        if (value == "待预售")
        {
            click.GetComponent<Image>().sprite = button2;
        }
            
        if (value == "预售")
        {
            click.GetComponent<Image>().sprite = button3;
            click.onClick.AddListener(delegate () {
                Static.Instance.AddValue("long_id", transform.parent.Find("id").GetComponent<Text>().text);
                lingyang.Get();
                lyimage.sprite = imag.sprite;
            });
        }
            
        if (value == "开发中")
            click.GetComponent<Image>().sprite = button4;
    }

}
