using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    int bank = 100;
    float stockPrice;

    GameObject StockPrice;
    GameObject BankBalance;
    GameObject BuyPanel;

    private void Start()
    {
        StockPrice = GameObject.Find("StockPriceValue");
        BankBalance = GameObject.Find("BankBalanceValue");
        BuyPanel = GameObject.Find("BuyPanel");


        BankBalance.GetComponent<Text>().text = ("$") + bank.ToString();

        BuyPanel.SetActive(false);
        

    }

    private void Update()
    {
        stockPrice = gameObject.GetComponent<Graphing>().stockValue;

        StockPrice.GetComponent<Text>().text = stockPrice.ToString();
    }

    public void OpenBuyPanel()
    {
        BuyPanel.SetActive(true);
    }

    public void CloseBuyPanel()
    {
        BuyPanel.SetActive(false);
    }

    
}
