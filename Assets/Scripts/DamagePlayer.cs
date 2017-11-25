using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class DamagePlayer : MonoBehaviour {
    public int playerHealth = 30;
    int damage = 10;

    void start()
    {
        Debug.Log(playerHealth);

    }

    void OnCollisionEnter(Collision _colision)
    {
        if (_colision.gameObject.tag == "Bullet")
        {
            playerHealth -= damage;
            Debug.Log("enemy just touched something weird");
        }
    }

}
