using System;
using System.Collections;
using System.Text;
using System.Linq;
using SimpleJSON;
using UnityEngine;
using UnityEngine.Networking;
using static System.Net.WebRequestMethods;
using TMPro;

public class QuoteFetcher : MonoBehaviour {

    public string url;

    public JSONNode jsonResult;

    public string quoteText;
    public string quoteAuthor;

    public Text quoteTextUI;  

    // instance
    public static QuoteFetcher instance;
    void Awake() {
        // set the instance to be this script
        instance = this;
    }

    // sends an API request - returns a JSON file
    private IEnumerator GetData(string location) {

        // create the web request and download handler
        UnityWebRequest webReq = new UnityWebRequest();
        webReq.downloadHandler = new DownloadHandlerBuffer();

        // build the url and query
        webReq.url = "https://zenquotes.io/api/today";

        // Example return JSON from this call:
        /*
        
        [ {
           "q":"Spend eighty percent of your time focusing on the opportunities of tomorrow rather than the problems of yesterday.",
           "a":"Brian Tracy",
           "h":"<blockquote>&ldquo;Spend eighty percent of your time focusing on the opportunities of tomorrow rather than the problems of yesterday.&rdquo; &mdash; <footer>Brian Tracy</footer></blockquote>"
        } ]
        */

        yield return webReq.SendWebRequest();

        // convert the byte array and wait for a returning result
        string rawJson = Encoding.Default.GetString(webReq.downloadHandler.data);

        // parse the raw string into a json result we can easily read
        jsonResult = JSON.Parse(rawJson);


        // Testing result
        Console.Log(jsonResult);

        


        // Using JSON
        // Send a webrequest to receive the data from the api specified in the url
        // Data should be returned as a JSONNode object, containing an array of key-value pairs
        // This object can be saved as a large list of quotes
            // We then need a function to loop through the array and find the next quote that hasn't been displayed. 
            // Save the index number, move to the next index number when you need the next quote.
            // Once the index reaches the last index in the array, make another webrequest to pull a new JSON object containing a new list of quotes
        // To get specific data from the indexed object, zenquotes properties are:
        // "q" key for quote
        // "h" key for HTML pre-formatted quote
        // "a" key for author
        // "i" key for image
        // "c" key for character count in the quote






    }


    // OVERVIEW
    // -------------------------------------------------------------------------------------------
    // This script is to get a quote of the day from zenquotes.com
    // Take the quote of the day and put it into the text field
    // Maybe download like 50 quotes and keep them locally
    // On button press, cycle through quotes that have already been shown
    // If all quotes in the 50 have been shown then delete the last quotes, download 50 more and show the first one




}
