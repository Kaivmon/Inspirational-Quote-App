using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;

public class ScrollingBG : MonoBehaviour {

    public float speed = 0.2f;
    public GameObject startingUI;


    private bool isQuoteDisplayed = false;
    private MeshRenderer meshRenderer;

    private void Start() {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    private void Update() {

        ScrollUp();
    }
    private void ScrollUp() {
        meshRenderer.material.mainTextureOffset = new Vector2(0, Time.time * speed);
    }

    public void OnButtonPress() {
        isQuoteDisplayed = true;
        StartCoroutine(ShowMainScreen());
    }

    private IEnumerator ShowMainScreen() {
        Vector2 pos = new Vector2(startingUI.transform.position.x, startingUI.transform.position.y - 1000);
        while(startingUI.transform.position.y > pos.y) { 
            startingUI.transform.position -= new Vector3(0, Time.time * speed/2, 0);
            yield return null;
        }
    }
}
