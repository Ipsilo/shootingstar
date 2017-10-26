using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_1 : MonoBehaviour {
    public int BossHP;
    public int Phase2HP;
    public int Phase3HP;
    private Boss_Data bossData;
    public int Shot;
    public int Speed;
    public GameObject bullet;
    public GameObject Boss1;

	// Use this for initialization
	void Start () {
        bossData = new Boss_Data(BossHP);
        Debug.Log(gameObject.name + "의 체력: " + bossData.getHP());
        StartCoroutine(bulletStart());
    }

    void Update()
    {

    }

    IEnumerator bulletStart()
    {
        do
        {
            for (int i = 0; i < Shot; i++)
            {
                Debug.Log(i);
                GameObject obj;
                obj = Instantiate(bullet, Boss1.transform.position, Quaternion.identity);

                //보스의 위치에 bullet을 생성
                obj.GetComponent<Rigidbody2D>().AddForce(new Vector2(Speed * Mathf.Cos(Mathf.PI * 2 * i / Shot), Speed * Mathf.Sin(Mathf.PI * 2 * i / Shot)));
            }
            //지정해둔 각도의 방향으로 모든 총탄을 날린다
            yield return new WaitForSeconds(1f);
        } while (true);
    }

}

