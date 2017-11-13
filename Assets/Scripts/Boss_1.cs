using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_1 : MonoBehaviour
{
    private Boss_Data bossData;
    public int bossHP;
    public int phase2HP;
    public int phase3HP;
    public float shot;
    public float speed;
    public GameObject bullet;
    public GameObject boss1;
    public GameObject plane;
    public float shotAngle;
    public float shotAngleRate;
    private int level;
    Coroutine spell1;
    Coroutine spell2;
    Coroutine spell3;
    Coroutine spell4;
    GameObject obj;

    // Use this for initialization
    void Start()
    {
        bossData = new Boss_Data(bossHP);
        Debug.Log(gameObject.name + "의 체력: " + bossData.getHP());
        level = 1;
    }

    void Update()
    {
        if (bossData.getHP() == bossHP && level == 1)
        {
            spell1 = StartCoroutine(BulletSpell1());
            level++;
        }
        if (bossData.getHP() < phase2HP && level == 2)
        {
            StopCoroutine(spell1);
            spell2 = StartCoroutine(BulletSpell2());
            level++;
        }
        if (bossData.getHP() < phase3HP && level == 3)
        {
            StopCoroutine(spell2);
            spell3 = StartCoroutine(BulletSpell1());
            spell4 = StartCoroutine(BulletSpell3());
            level++;
        }
        if (bossData.getHP() == 0)
        {
            StopCoroutine(spell3);
            StopCoroutine(spell4);
            Destroy(boss1);
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.CompareTag("Player Missile"))
        {
            bossData.decreaseHP(2);
            Debug.Log(gameObject.name + "의 체력: " + bossData.getHP());
        }
    }
    IEnumerator BulletSpell1()
    {
        do
        {
            yield return new WaitForSeconds(1.2f);
            for (int i = 0; i < shot; i++)
            {
                //탄 생성
                obj = (GameObject)Instantiate(bullet, boss1.transform.position, Quaternion.identity);

                //bullet을 원형으로 발사
                obj.GetComponent<Rigidbody2D>().AddForce(new Vector2(speed * Mathf.Cos(Mathf.PI * 2 * i / shot), speed * Mathf.Sin(Mathf.PI * i * 2 / shot)));
            }

            yield return new WaitForSeconds(1.2f);
            for (int i = 0; i < shot; i++)
            {
                obj = (GameObject)Instantiate(bullet, boss1.transform.position, Quaternion.identity);

                //bullet생성 위치를 바꾸고 원형으로 발사
                obj.GetComponent<Rigidbody2D>().AddForce(new Vector2(speed * Mathf.Cos(Mathf.PI * 2 * i / shot + Mathf.PI / 2), speed * Mathf.Sin(Mathf.PI * i * 2 / shot + Mathf.PI / 2)));
            }
        } while (true);
    }

    IEnumerator BulletSpell2()
    {
        float angle;
        int rotate;
        angle = 0;
        rotate = 0;
        do
        {
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
        Vector2 v;
        do
        {
            //탄 생성
            obj = (GameObject)Instantiate(bullet, boss1.transform.position, Quaternion.identity);

            v = plane.transform.position - boss1.transform.position;
            obj.GetComponent<Rigidbody2D>().AddForce(v.normalized * speed);
            yield return new WaitForSeconds(0.35f);
        } while (true);
    }
}



