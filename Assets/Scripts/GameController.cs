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

    private void Awake()
    {
        StockPrice = GameObject.Find("StockPriceValue");
        BankBalance = GameObject.Find("bankBalanceValue");


        BankBalance.GetComponent<Text>().text = ("$") + bank.ToString();



    }

    private void Update()
    {
        stockPrice = gameObject.GetComponent<Graphing>().stockValue;

        StockPrice.GetComponent<Text>().text = stockPrice.ToString();
    }
}
