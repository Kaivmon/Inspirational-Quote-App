using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;

public class ScrollingBG : MonoBehaviour {

    // This script moves both textures to the left, and when the first texture is off the screen, moves it back to the far right.
    // Move both textures -1 x position per second
    // When first texture x position reaches 0 - max width, move position to second texture position + max width.

    public RectTransform cloudImg1;
    public RectTransform cloudImg2;
    public float speed = 1;

    public float rectWidth;

    void Start() {
        rectWidth = (cloudImg1.sizeDelta.x * cloudImg1.localScale.x);
    }

    // Update is called once per frame
    void Update() {
        StartCoroutine(ScrollLeft());
        RetileRight();
    }

    private IEnumerator ScrollLeft() {
        

        Vector3 pos = cloudImg1.position;
        pos.x -= speed;
        cloudImg1.position = pos;
        
        pos = cloudImg2.position;
        pos.x -= speed;
        cloudImg2.position = pos;
        yield return null;


    }

    private void RetileRight() {
        if(cloudImg1.position.x + rectWidth <= 0) {
            cloudImg1.position = new Vector3(cloudImg2.position.x + rectWidth, 0, 0);
        }
        if (cloudImg2.position.x + rectWidth <= 0) {
            cloudImg2.position = new Vector3(cloudImg1.position.x + rectWidth, 0, 0);
        }
    }
}
