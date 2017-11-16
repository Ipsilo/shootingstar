using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {
    public Slider healthBarSlider;//slider 참조
    
	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {
		
	}
    
    void OnTriggerStay(Collider other)
    {
        if (((other.gameObject.name == "bullet")|| (other.gameObject.name == "Enemy")&& healthBarSlider.value > 0)){
            healthBarSlider.value -= 10;
        }
    }
}
