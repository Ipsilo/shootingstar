using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour{
	public int HP;
	private Boss_Data enemyData;

	void Start(){
		enemyData = new Boss_Data (HP);
		Debug.Log (GameObject.name + "의 체력 :" + enemyData.getHP ());
	}

	void Update(){}
}