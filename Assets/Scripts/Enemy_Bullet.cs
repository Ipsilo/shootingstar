using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Bullet : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    private void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        //Player Missile 태그를 가진 오브젝트와 충돌시 HP감소
        if (col.CompareTag("Player"))
        {
            Debug.Log("플레이어와 충돌");
            Destroy(this.gameObject);
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
