using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pay_event : MonoBehaviour
{
    [SerializeField]
    Sprite wx, zfb, yhk;
    [SerializeField]
    Image pic;
    public GameObject Enlargement;
    public void getpay(string value)
    {
        switch (value)
        {
            case "微信":
                pic.sprite = wx;
                break;
            case "支付宝":
                pic.sprite = zfb;
                break;
            default:
                pic.sprite = yhk;
                if (transform.parent.Find("Image"))
                    transform.parent.Find("Image").gameObject.SetActive(false);
                break;
        }
    }

    public void LoadImage(string obj)
    {
        if (obj != null)
        {
            StartCoroutine(loadtexture(obj.ToString()));
        }

    }

    IEnumerator loadtexture(string obj)
    {
        Debug.Log(obj);

        //foreach (Image i in sprit)
        //    i.sprite = default_image;

        WWW www = new WWW(obj);
        yield return www;
        if (www.error != null)
        {
            Debug.Log(www.error);
            var btn = pic.GetComponent<Self_Button>();
            btn.onClick = null;
        }
        if (www != null && string.IsNullOrEmpty(www.error))
        {
            Sprite sprite = Sprite.Create(www.texture, new Rect(0, 0, www.texture.width, www.texture.height), Vector2.zero);
            pic.sprite = sprite;
            var btn = pic.GetComponent<Self_Button>();
            btn.onClick.AddListener(delegate ()
            {
                Enlargement.GetComponent<Image>().sprite = sprite;
                Enlargement.transform.parent.gameObject.SetActive(true);
            });
        }
    }
}
