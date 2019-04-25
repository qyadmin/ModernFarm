using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class lb_event : MonoBehaviour {

	public void Getsl(string value)
    {
        Debug.Log(int.Parse(value));
        if (int.Parse(value) > 0)
            this.GetComponent<Text>().color = new Color(0.13f,0.56f,0.13f);
        if (int.Parse(value) < 0)
            this.GetComponent<Text>().color = new Color(0.56f, 0.13f, 0.13f);

    }
}
