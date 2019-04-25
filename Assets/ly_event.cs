using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ly_event : MonoBehaviour {


    [SerializeField]
    Transform loading,lypanle;
    [SerializeField]
    Text waitsecond;

    Timer _timer = new Timer(1);
    [SerializeField]
    HttpModel refrece;
    int time;

    public void Gettime(int value)
    {
        _timer.tickEvnet -= time_event;
        _timer.EndTimer();
        time = value;
        _timer.tickEvnet += time_event;
        _timer.StartTimer();
    }
    void time_event()
    {
        if (time <= 0)
        {
            
            loading.gameObject.SetActive(false);
            lypanle.gameObject.SetActive(true);
            audio.Play();
            refrece.Get();
            _timer.EndTimer();
        }
        else
        {
            loading.gameObject.SetActive(true);
            lypanle.gameObject.SetActive(false);
            waitsecond.text = "";
            time--;
        }
    }


    private void Update()
    {
        _timer.UpdateRepeatTimer(Time.deltaTime);
    }

    [SerializeField]
    Sprite suc_spr, fal_spr;
    [SerializeField]
    AudioClip suc_aud, fal_aud;
    [SerializeField]
    Image img;
    [SerializeField]
    AudioSource audio;

    public void successful()
    {
        img.sprite = suc_spr;
        audio.clip = suc_aud;
        Gettime(0);
    }

    public void failure()
    {
        img.sprite = fal_spr;
        audio.clip = fal_aud;
        Gettime(120);
    }

    string cg_flag;

    public void set()
    {
        if (cg_flag == "1")
            successful();
        else
            failure();
    }


    public void get_cg_flag(object value)
    {
        cg_flag = value.ToString();
    }

}
