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

    public TextMeshPro quotetext;

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

        quotetext.text = 

        yield return null;

    }

    // This script is to get a quote of the day from zenquotes.com
    // Take the quote of the day and put it into the text field
    // Maybe download like 50 quotes and keep them locally
    // On button press, cycle through quotes that have already been shown
    // If all quotes in the 50 have been shown then delete the last quotes, download 50 more and show the first one




}
