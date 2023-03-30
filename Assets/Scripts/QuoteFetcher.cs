using System;
using System.Collections;
using System.Text;
using System.Linq;
using SimpleJSON;

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using TMPro;
using System.IO;
using static Unity.Burst.Intrinsics.X86;
using Unity.VisualScripting;

public class QuoteFetcher : MonoBehaviour {

    public JSONNode jsonResult;

    public TMP_Text quoteTextUI;  
    public TMP_Text quoteAuthorUI;

    // instance
    public static QuoteFetcher instance;
    void Awake() {
        // set the instance to be this script
        instance = this;
        StartCoroutine(GetSingleDailyQuote());
    }

    // Sends an API request - returns a JSON file with just one quote
    private IEnumerator GetSingleDailyQuote() {

        // This method gets a daily quote from ZenQuotes.com, which only updates once a day at 00:00 CST 
        // We should first log the date and time before running this method.
        // If there is no previous date/time saved, then run the method.
        // If there is a date and time saved, then check if ( System.DateTime.UtcNow + 1day + 1hour) - date and time saved) > 24hrs

        /*
            CST 00:00 = 05:00 UTC

            DateTime currentTime = System.DateTime.UtcNow;
            DateTime savedTime;
            System.DateTime.Compare(currentTime, savedTime);
        
     
        */


        // Create the web request and download handler
        UnityWebRequest webReq = new UnityWebRequest();
        webReq.downloadHandler = new DownloadHandlerBuffer();

        // Build the url and query
        webReq.url = "https://zenquotes.io/api/today";

        //Wait for reply from server
        yield return webReq.SendWebRequest();

        // Convert the byte array to a JSON string
        string rawJson = Encoding.Default.GetString(webReq.downloadHandler.data);

        // Parse the raw string into a json result object
        jsonResult = JSON.Parse(rawJson);

        // To get specific data from the indexed object, ZenQuote keys are:
        // "q" key for quote
        // "a" key for author
        quoteTextUI.text = jsonResult[0]["q"];
        quoteAuthorUI.text = "- " + jsonResult[0]["a"];


        // Testing result
        Debug.Log(jsonResult);

        


        // Using JSON
        // Send a webrequest to receive the data from the api specified in the url
        // Data should be returned as a JSONNode object, containing an array of key-value pairs
        // This object can be saved as a large list of quotes
            // We then need a function to loop through the array and find the next quote that hasn't been displayed. 
            // Save the index number, move to the next index number when you need the next quote.
            // Once the index reaches the last index in the array, make another webrequest to pull a new JSON object containing a new list of quotes


    }



    //FileStream file = File.Open(Application.persistentDataPath + "/gameInfo.dat", FileMode.Open);


    // OVERVIEW
    // -------------------------------------------------------------------------------------------
    // This script is to get a quote of the day from zenquotes.com
    // Take the quote of the day and put it into the text field
    // Maybe download like 50 quotes and keep them locally
    // On button press, cycle through quotes that have already been shown
    // If all quotes in the 50 have been shown then delete the last quotes, download 50 more and show the first one




}
