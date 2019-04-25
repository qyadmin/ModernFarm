using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class question_event : MonoBehaviour {

    [SerializeField]
    Text id;
    [SerializeField]
    Text titel;
    [SerializeField]
    Text value;
    private void Start()
    {
        this.GetComponent<Button>().onClick.AddListener(delegate() {
            saveid();
        });
    }
    public void saveid()
    {
        Static.Instance.AddValue("wt_id",id.text);
        titel.text = value.text;

    }
}
