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
        if (col.CompareTag("Bullet") || col.CompareTag("Enemy"))
        {
            Debug.Log("불릿과 충돌");
<<<<<<< HEAD
            Destroy(col.gameObject);
            Destroy(this.gameObject);
=======
            GameControll.health -= 1;
>>>>>>> c8c828cae5f9d3007bca41e320785079da0f9a56
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
