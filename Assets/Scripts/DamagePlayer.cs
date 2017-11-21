using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;



public class DamagePlayer : MonoBehaviour {
    public int playerHealth = 30;
    int damage = 10;

    void start()
    {
        print(playerHealth);

    }

    void OnCollisionEnter(Collision _colision)
    {
        if (_colision.gameObject.tag == "Enemy")
        {
            playerHealth -= damage;
            print("enemy just touched something weird");
        }
    }

}
