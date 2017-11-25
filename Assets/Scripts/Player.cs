using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    private void OnTriggerEnter2D(Collider2D col)
    {
        //Player Missile 태그를 가진 오브젝트와 충돌시 오브젝트 삭제
        if (col.CompareTag("Bullet"))
        {
            Debug.Log("불릿과 충돌");
            Destroy(this.gameObject);
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
