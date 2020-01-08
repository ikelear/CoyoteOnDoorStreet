using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    int bank = 100;
    int stocksOwned = 0;
    float stockPrice;

    GameObject StockPrice;
    GameObject BankBalance;
    GameObject BuyPanel;
    GameObject stockpriceValue;
    GameObject StockOwnedValue;
    GameObject NotEnoughStocks;

    public InputField NumberOfStocks;

    private void Start()
    {
        StockPrice = GameObject.Find("StockPriceValue");
        BankBalance = GameObject.Find("BankBalanceValue");
        BuyPanel = GameObject.Find("BuyPanel");
        stockpriceValue = GameObject.Find("stockpriceValue");
        StockOwnedValue = GameObject.Find("StockOwnedValue");
        NotEnoughStocks = GameObject.Find("NotEnoughStocks");


        BankBalance.GetComponent<Text>().text = ("$") + bank.ToString();



        BuyPanel.SetActive(false);
        NotEnoughStocks.SetActive(false);


    }

    private void Update()
    {
        stockPrice = gameObject.GetComponent<Graphing>().stockValue;

        StockPrice.GetComponent<Text>().text = stockPrice.ToString();
    }

    public void OpenBuyPanel()
    {
        BuyPanel.SetActive(true);
        stockpriceValue.GetComponent<Text>().text = stockPrice.ToString();
        StockOwnedValue.GetComponent<Text>().text = stocksOwned.ToString();
    }

    public void CloseBuyPanel()
    {
        BuyPanel.SetActive(false);
    }

    public void StocksBought()
    {
        stocksOwned = stocksOwned + int.Parse(NumberOfStocks.text);
        NumberOfStocks.text = 0f.ToString();
        StockOwnedValue.GetComponent<Text>().text = stocksOwned.ToString();


    }

    public void StocksSold()
    {
        if (stocksOwned - int.Parse(NumberOfStocks.text) < 0)
        {
            NotEnoughStocks.SetActive(true);
            return;
        }
        stocksOwned = stocksOwned - int.Parse(NumberOfStocks.text);
        NumberOfStocks.text = 0f.ToString();
        StockOwnedValue.GetComponent<Text>().text = stocksOwned.ToString();
    }

    public void TurnOffNotEnoughStocks()
    {
        NotEnoughStocks.SetActive(false);
    }
    
}
    

