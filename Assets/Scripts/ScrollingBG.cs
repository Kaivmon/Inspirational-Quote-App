using System.Collections;
using TMPro;
using UnityEngine;

public class ScrollingBG : MonoBehaviour {

    public float speed = 0.2f;

    private MeshRenderer meshRenderer;

    void Start() {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    void Update() {

        meshRenderer.material.mainTextureOffset = new Vector2(0, Time.time * speed);

    }
 }
