using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using LitJson;
using System.Text.RegularExpressions;

public class buysellOrders_event : MonoBehaviour {

    [SerializeField]
    Text buyer_tel, saler_tel, coin_num, price, money, creat_time, sk_time, zftype, zhuangtai, order_id, img;


    public enum buysell
    {
        buy,
        sell,
    }
    public buysell type;


    public void set_type(string value)
    {
        if(value == "sell")
            type = buysell.sell;
        if (value == "buy")
            type = buysell.buy;
    }

    public void GetJson(JsonData json)
    {
        Debug.Log(JsonMapper.ToJson(json));

        JsonData data = json["data"];
        try { buyer_tel.text = Regex.Unescape(JsonMapper.ToJson(data["buyer_tel"]).Replace("\"", "")); }
        catch { buyer_tel.text = "----"; }
        try { saler_tel.text = Regex.Unescape(JsonMapper.ToJson(data["saler_tel"]).Replace("\"", "")); }
        catch { saler_tel.text = "----"; }
        try { coin_num.text = Regex.Unescape(JsonMapper.ToJson(data["coin_num"]).Replace("\"", "")); }
        catch { coin_num.text = "----"; }
        try { price.text = Regex.Unescape(JsonMapper.ToJson(data["price"]).Replace("\"", "")); }
        catch { price.text = "----"; }
        try { money.text = Regex.Unescape(JsonMapper.ToJson(data["money"]).Replace("\"", "")); }
        catch { money.text = "----"; }
        try { creat_time.text = Regex.Unescape(JsonMapper.ToJson(data["creat_time"]).Replace("\"", "")); }
        catch { creat_time.text = "----"; }
        try { sk_time.text = Regex.Unescape(JsonMapper.ToJson(data["sk_time"]).Replace("\"", "")); }
        catch { sk_time.text = "----"; }
        try { zftype.text = Regex.Unescape(JsonMapper.ToJson(data["zftype"]).Replace("\"", "")); }
        catch { zftype.text = "----"; }
        try { zhuangtai.text = Regex.Unescape(JsonMapper.ToJson(data["zhuangtai"]).Replace("\"", "")); }
        catch { zhuangtai.text = "----"; }
        try { order_id.text = Regex.Unescape(JsonMapper.ToJson(data["order_id"]).Replace("\"", "")); }
        catch { order_id.text = "----"; }
        try { img.text = Regex.Unescape(JsonMapper.ToJson(data["img"]).Replace("\"", "")); }
        catch { img.text = "----"; }
        Resets();
        Resetlist(zhuangtai.text);
    }

    [SerializeField]
    Transform Father;
    public void Resets()
    {
        buy_update.gameObject.SetActive(false);
        zftype1.gameObject.SetActive(false);
        zftype2.gameObject.SetActive(false);
        fountion1.gameObject.SetActive(false);
        fountion2.gameObject.SetActive(false);
        orderid.gameObject.SetActive(false);
        dk_img.gameObject.SetActive(false);
        dd_state.gameObject.SetActive(false);
        buyer.gameObject.SetActive(false);
        seller.gameObject.SetActive(false);
    }


    [SerializeField]
    Transform buy_update,dk_img, dd_state, zftype1, zftype2, fountion1, fountion2, orderid,buyer,seller;
    public void Resetlist(string zhuangtai)
    {
        if (type == buysell.sell)
        {
            buyer.gameObject.SetActive(true);
        }
        if (type == buysell.buy)
        {
            seller.gameObject.SetActive(true);
        }

        switch (zhuangtai)
        {
            case "待付款":
                if (type == buysell.sell)
                {
                    zftype1.gameObject.SetActive(true);
                    dd_state.gameObject.SetActive(true);
                    orderid.gameObject.SetActive(true);
                }
                break;

            case "请付款":
                if (type == buysell.buy)
                {
                    buy_update.gameObject.SetActive(true);
                    zftype2.gameObject.SetActive(true);
                    fountion1.gameObject.SetActive(true);
                    orderid.gameObject.SetActive(true);
                }
                break;
            case "待确认":
                zftype1.gameObject.SetActive(true);
                dk_img.gameObject.SetActive(true);
                dd_state.gameObject.SetActive(true);
                orderid.gameObject.SetActive(true);
                break;

            case "请确认":
                zftype1.gameObject.SetActive(true);
                dk_img.gameObject.SetActive(true);
                dd_state.gameObject.SetActive(true);
                orderid.gameObject.SetActive(true);
                if (type == buysell.sell)
                    fountion2.gameObject.SetActive(true);
                break;
            case "撤销排单":
                zftype1.gameObject.SetActive(true);
                dd_state.gameObject.SetActive(true);
                break;
            case "超时取消":
                zftype1.gameObject.SetActive(true);
                dd_state.gameObject.SetActive(true);
                break;
            case "已确认":
                zftype1.gameObject.SetActive(true);
                dk_img.gameObject.SetActive(true);
                dd_state.gameObject.SetActive(true);
                orderid.gameObject.SetActive(true);
                break;
            case "已完成":
                zftype1.gameObject.SetActive(true);
                dk_img.gameObject.SetActive(true);
                dd_state.gameObject.SetActive(true);
                orderid.gameObject.SetActive(true);
                break;
            case "未收到款":
                zftype1.gameObject.SetActive(true);
                dk_img.gameObject.SetActive(true);
                dd_state.gameObject.SetActive(true);
                orderid.gameObject.SetActive(true);
                if (type == buysell.sell)
                    fountion2.gameObject.SetActive(true);
                break;
        }

        
        StartCoroutine(delator());
        
    }

    [SerializeField]
    HttpModel sell,buy;
    public void Close()
    {
        if (type == buysell.sell)
            sell.Get();
        if (type == buysell.buy)
            buy.Get();
    }

    [SerializeField]
    HttpModel sell2, buy2;
    public void Close2()
    {
        if (type == buysell.sell)
            sell2.Get();
        if (type == buysell.buy)
            buy2.Get();
    }

    IEnumerator delator()
    {

        yield return new WaitForSeconds(0.2f);
        Father.gameObject.SetActive(false);
        Father.gameObject.SetActive(true);
    }

}
