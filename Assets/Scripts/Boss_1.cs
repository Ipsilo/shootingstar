using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_1 : MonoBehaviour
{
    public int bossHP;
    public int phase2HP;
    public int phase3HP;
    private Boss_Data bossData;
    public float shot;
    public float speed;
    public GameObject bullet;
    public GameObject boss1;
    public GameObject plane;
    public float shotAngle;
    public float shotAngleRate;
    private float angle;
    private int rotate;

    // Use this for initialization
    void Start()
    {
        bossData = new Boss_Data(bossHP);
        Debug.Log(gameObject.name + "의 체력: " + bossData.getHP());
        angle = 0;
        rotate = 0;

        StartCoroutine(BulletSpell3());
        if (bossData.getHP() < phase2HP)
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
            for (int i = 0; i < shot; i++)
            {
                Debug.Log(i);
                GameObject obj;
                //탄 생성
                obj = (GameObject)Instantiate(bullet, boss1.transform.position, Quaternion.identity);

                //bullet을 원형으로 발사
                obj.GetComponent<Rigidbody2D>().AddForce(new Vector2(speed * Mathf.Cos(Mathf.PI * 2 * i / shot), speed * Mathf.Sin(Mathf.PI * i * 2 / shot)));
            }
            //탄 발사 간격
            yield return new WaitForSeconds(1.2f);

            for (int i = 0; i < shot; i++)
            {
                Debug.Log(i);
                GameObject obj;
                obj = (GameObject)Instantiate(bullet, boss1.transform.position, Quaternion.identity);

                //bullet생성 위치를 바꾸고 원형으로 발사
                obj.GetComponent<Rigidbody2D>().AddForce(new Vector2(speed * Mathf.Cos(Mathf.PI * 2 * i / shot + Mathf.PI / 2), speed * Mathf.Sin(Mathf.PI * i * 2 / shot + Mathf.PI / 2)));
            }
            //탄 발사 간격
            yield return new WaitForSeconds(1.2f);
        } while (true);
    }

    IEnumerator BulletSpell2()
    {
        do
        {
            GameObject obj;
            obj = Instantiate(bullet, boss1.transform.position, Quaternion.identity);

            //bullet을 생성
            obj.GetComponent<Rigidbody2D>().AddForce(new Vector2(speed * Mathf.Cos(Mathf.PI * angle), speed * Mathf.Sin(Mathf.PI * angle)));

            if (angle > 2)
            {
                angle = 0;
            }
            if (angle < 2)
            {
                angle += shotAngle;
            }
            if (rotate == 0)
            {
                shotAngle += shotAngleRate;
                shotAngleRate += shotAngleRate / 100;
                if (shotAngle > 0.999)
                {
                    rotate = 1;
                }
            }

            if (rotate == 1)
            {
                shotAngle -= shotAngleRate;
                shotAngleRate -= shotAngleRate / 100;
                if (shotAngle < 0.1)
                {
                    rotate = 0;
                }
            }

            yield return new WaitForSeconds(0.015f);
        } while (true);
    }

    IEnumerator BulletSpell3()
    {
        Rigidbody2D temp;
        GameObject obj;
        Vector2 v;
        do
        {

            for (int i = 0; i < shot; i++)
            {
                Debug.Log(i);
                //탄 생성
                obj = (GameObject)Instantiate(bullet, boss1.transform.position, Quaternion.identity);

                //bullet을 원형으로 생성
                //obj.GetComponent<Rigidbody2D>().AddForce(new Vector2(speed * Mathf.Cos(Mathf.PI * 2 * i / shot), speed * Mathf.Sin(Mathf.PI * i * 2 / shot)));

                v = plane.transform.position;
                obj.GetComponent<Rigidbody2D>().AddForce(v.normalized * speed);
            }
            yield return new WaitForSeconds(0.1f);
        } while (true);
    }
}



