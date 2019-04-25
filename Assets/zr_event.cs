using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class zr_event : MonoBehaviour {

    Timer _timer = new Timer(1);
    int time;

    void time_event()
    {
        if (time <= 0)
        {
            _timer.EndTimer();
        }
        else
        {
            if (time <= 0)
            {
                this.GetComponent<Text>().text = "已到期";
                _timer.EndTimer();
            }
            else
            {
                this.GetComponent<Text>().text = string.Format("{0}天{1}时{2}分{3}秒", Mathf.Floor(time / 86400), Mathf.Floor((time % 86400) / 3600), Mathf.Floor((time % 86400 % 3600) / 60), Mathf.Floor(time % 86400 % 3600 % 60));
                time--;
            }
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
}
