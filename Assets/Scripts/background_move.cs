using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class background_move : MonoBehaviour {
    public float ScrollSpeed = 1.0f;
    float Offset;
    private new Renderer renderer;

	// Use this for initialization
	void Start () {
        renderer = GetComponent<Renderer>();
	}
	
	// Update is called once per frame
	void Update () {
        Offset += Time.deltaTime * ScrollSpeed;
        renderer.material.mainTextureOffset = new Vector2(0, Offset);
	}
}
