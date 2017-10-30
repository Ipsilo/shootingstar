using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_1 : MonoBehaviour {
    public int BossHP;
    public int Phase2HP;
    public int Phase3HP;
    private Boss_Data bossData;
    public float Shot;
    public float Speed;
    public GameObject bullet;
    public GameObject Boss1;
    public float ShotAngle;
    private float Angle;
    public int rotate;

	// Use this for initialization
	void Start () {
        bossData = new Boss_Data(BossHP);
        Debug.Log(gameObject.name + "의 체력: " + bossData.getHP());
        Angle = 0;
        rotate = 0;
        StartCoroutine(BulletSpell1());
        if (bossData.getHP() < Phase2HP)
        {
            StartCoroutine(BulletSpell2());
        }
    }

    void Update()
    {

    }
    IEnumerator BulletSpell1()
    {
        do
        {
            for (int i = 0; i < Shot; i++)
            {
                Debug.Log(i);
                GameObject obj;
                obj = (GameObject)Instantiate(bullet, Boss1.transform.position, Quaternion.identity);

                //보스의 위치에 bullet을 생성합니다.
                obj.GetComponent<Rigidbody2D>().AddForce(new Vector2(Speed * Mathf.Cos(Mathf.PI * 2 * i / Shot), Speed * Mathf.Sin(Mathf.PI * i * 2 / Shot)));
            }
            yield return new WaitForSeconds(1.2f);

            for (int i = 0; i < Shot; i++)
            {
                Debug.Log(i);
                GameObject obj;
                obj = (GameObject)Instantiate(bullet, Boss1.transform.position, Quaternion.identity);

                //보스의 위치에 bullet을 생성합니다.
                obj.GetComponent<Rigidbody2D>().AddForce(new Vector2(Speed * Mathf.Cos(Mathf.PI * 2 * i / Shot + Mathf.PI / 2), Speed * Mathf.Sin(Mathf.PI * i * 2 / Shot + Mathf.PI / 2)));
            }
            yield return new WaitForSeconds(1.2f);
        } while (true);
    }
    IEnumerator BulletSpell2()
    {
        do
        {
            if (Angle >= 2)
            {
                Angle = 0;
            }
            GameObject obj;
            obj = Instantiate(bullet, Boss1.transform.position, Quaternion.identity);

            //보스의 위치에 bullet을 생성
            obj.GetComponent<Rigidbody2D>().AddForce(new Vector2(Speed * Mathf.Cos(Mathf.PI * Angle), Speed * Mathf.Sin(Mathf.PI * Angle)));

            Angle += ShotAngle;

            if (rotate == 0)
            {
                ShotAngle += ShotAngle/100;
                if (ShotAngle > 0.7)
                {
                    rotate = 1;
                }
            }

            if(rotate == 1)
            {
                ShotAngle -= ShotAngle/100;
                if(ShotAngle < 0.1)
                {
                    rotate = 0;
                }
            }

            yield return new WaitForSeconds(0.015f);
        } while (true);
    }

}

