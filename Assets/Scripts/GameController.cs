using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    float bank = 100;
    int stocksOwned = 0;
    float stockPrice;

    GameObject StockPrice;
    GameObject BankBalance;
    GameObject BuyPanel;
    GameObject stockpriceValue;
    GameObject StockOwnedValue;
    GameObject NotEnoughStocks;
    GameObject NotEnoughMoney;
    GameObject stockOwnedValue;

    public InputField NumberOfStocks;

    private void Start()
    {
        StockPrice = GameObject.Find("StockPriceValue");
        BankBalance = GameObject.Find("BankBalanceValue");
        BuyPanel = GameObject.Find("BuyPanel");
        stockpriceValue = GameObject.Find("stockpriceValue");
        StockOwnedValue = GameObject.Find("StockOwnedValue");
        NotEnoughStocks = GameObject.Find("NotEnoughStocks");
        NotEnoughMoney = GameObject.Find("NotEnoughMoney");
        stockOwnedValue = GameObject.Find("stocksOwnedValue");


        BankBalance.GetComponent<Text>().text = ("$") + bank.ToString();
        stockOwnedValue.GetComponent<Text>().text = stocksOwned.ToString();


        BuyPanel.SetActive(false);
        NotEnoughStocks.SetActive(false);
        NotEnoughMoney.SetActive(false);


    }

    private void Update()
    {
        stockPrice = gameObject.GetComponent<Graphing>().stockValue - (gameObject.GetComponent<Graphing>().stockValue%0.01f);
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
        float potentialBalance = bank - (int.Parse(NumberOfStocks.text) * stockPrice);
        Debug.Log(potentialBalance);
        if (potentialBalance < 0)
        {
            NotEnoughMoney.SetActive(true);
            return;
        }
        else
        {
            bank = potentialBalance;
        }
        BankBalance.GetComponent<Text>().text = ("$") + bank.ToString();
        stocksOwned = stocksOwned + int.Parse(NumberOfStocks.text);
        NumberOfStocks.text = 0f.ToString();
        StockOwnedValue.GetComponent<Text>().text = stocksOwned.ToString();
        stockOwnedValue.GetComponent<Text>().text = stocksOwned.ToString();
    }

    public void StocksSold()
    {
        if (stocksOwned - int.Parse(NumberOfStocks.text) < 0)
        {
            NotEnoughStocks.SetActive(true);
            return;
        }
        float newBalance = bank + (int.Parse(NumberOfStocks.text) * stockPrice);
        bank = newBalance;
        BankBalance.GetComponent<Text>().text = ("$") + bank.ToString();
        stocksOwned = stocksOwned - int.Parse(NumberOfStocks.text);
        NumberOfStocks.text = 0f.ToString();
        StockOwnedValue.GetComponent<Text>().text = stocksOwned.ToString();
        stockOwnedValue.GetComponent<Text>().text = stockOwnedValue.ToString();
    }

    public void TurnOffNotEnoughStocks()
    {
        NotEnoughStocks.SetActive(false);
    }

    public void TurnOffNotEnoughMoney()
    {
        NotEnoughMoney.SetActive(false);
    }
    
}
    

