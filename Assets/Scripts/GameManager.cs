using System.Collections;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public float slideDownSpeed = 0.1f;
    public float fadeInSpeed = 0.5f;

    [SerializeField]
    private GameObject startingUI;
    [SerializeField]
    private GameObject quoteUI;


    public void OnButtonPress() {
        StartCoroutine(ShowQuoteScreen());
    }

    private IEnumerator ShowQuoteScreen() {

        // Slide up the opening menu and then deactivcate it.
        Vector2 pos = new Vector2(startingUI.transform.position.x, startingUI.transform.position.y - 1000);
        while (startingUI.transform.position.y > pos.y) {
            startingUI.transform.position -= new Vector3(0, Time.time * slideDownSpeed, 0);
            yield return null;
        }

        startingUI.SetActive(false);
        //quoteUI.SetActive(true);


        // Fade in the quote text.
        float opacity = 0;
        Color color;

        while (opacity < 1) {
            opacity += (Time.time * fadeInSpeed)/100;
            foreach (TMP_Text text in quoteUI.GetComponentsInChildren<TMP_Text>()) {

                color = text.color;
                color.a = opacity;
                text.color = color;
            }
            yield return null;
        }
    }
}