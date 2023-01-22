using System;
using System.Net;
using Newtonsoft.Json.Linq;
using UnityEngine;

public class Program_PEP:MonoBehaviour
{
public GameObject textMesh;
  
void Update()
{
String symbolA="PEP"; 
    textMesh.GetComponent<TMPro.TextMeshPro>().text=GetStockData(symbolA);  
}
    

    public static String GetStockData(string symbol)
{
String mktData="";
    string url = $"https://query1.finance.yahoo.com/v7/finance/quote?symbols={symbol}";

    try
    {
        using (WebClient client = new WebClient())
        {
            string json = client.DownloadString(url);
            JObject data = JObject.Parse(json);
            var stockData = data["quoteResponse"]["result"][0];

            // String StockSymbol = $"Stock Symbol: {stockData["symbol"]}";
            // Console.WriteLine(StockSymbol);

            // String mktPrice = $"Mkt. Price: {stockData["regularMarketPrice"]}";
            // Console.WriteLine(mktPrice);
            
            // String mktOpen = $"Mkt. Open: {stockData["regularMarketOpen"]}";
            // Console.WriteLine(mktOpen);
            
            // String mktClose = $"Mkt. Close: {stockData["regularMarketPreviousClose"]}";
            // Console.WriteLine(mktClose);
            
            // String mktChange = $" Mkt. Change: ${stockData["regularMarketChange"]}";
            // Console.WriteLine(mktChange);
            
            // String mktChangePercent = $"Mkt. Change Percent: %{stockData["regularMarketChangePercent"]}";
            // Console.WriteLine(mktChangePercent);
            
            mktData =  $"Mkt. Symbol: {stockData["symbol"]} \n" + $"Mkt. Price: {stockData["regularMarketPrice"]} \n" + $"Mkt. Open: {stockData["regularMarketOpen"]} \n" + 
            $"Mkt. Close: {stockData["regularMarketPreviousClose"]} \n" + "Mkt. Cap: " + ((long)stockData["marketCap"]).ToString("C0").Remove(4)+"B";
            Console.WriteLine(mktData);
        }

    }
    catch (WebException ex)
    {
        Console.WriteLine("An error occurred: " + ex.Message);
    }
return mktData;
}


    
}
