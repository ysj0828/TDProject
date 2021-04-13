using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class EnemyScript : MonoBehaviour
{
    public float speed = 1f;
    public Transform[] healthBar;
    private int healthMax = 5;
    private int health;

    private Transform target;
    private int waypointIndexPoint1 = 0;
    private int waypointIndexPoint2 = 1;
    private int waypointIndexPoint3 = 2;
    private int waypointIndexPoint4 = 3;

    private bool spawnedAtPoint1 = false;
    private bool spawnedAtPoint2 = false;
    private bool spawnedAtPoint3 = false;
    private bool spawnedAtPoint4 = false;

    private bool isDead = false;



    

    void Start()
    {

        //스폰 장소에 따라 이니셜 타겟 웨이포인트 설정
        if (transform.position == GameObject.FindGameObjectWithTag("SpawnManager").GetComponent<WaveSpawner>().spawnPoint1.position)
        {
            target = waypoints.points[waypointIndexPoint1];
            spawnedAtPoint1 = true;
        }

        else if (transform.position == GameObject.FindGameObjectWithTag("SpawnManager").GetComponent<WaveSpawner>().spawnPoint2.position)
        {
            target = GameObject.FindGameObjectWithTag("TempWaypoint1").transform;
            spawnedAtPoint2 = true;
        }

        else if (transform.position == GameObject.FindGameObjectWithTag("SpawnManager").GetComponent<WaveSpawner>().spawnPoint3.position)
        {
            target = waypoints.points[waypointIndexPoint3];
            spawnedAtPoint3 = true;
        }

        else if (transform.position == GameObject.FindGameObjectWithTag("SpawnManager").GetComponent<WaveSpawner>().spawnPoint4.position)
        {
            target = GameObject.FindGameObjectWithTag("TempWaypoint2").transform;
            spawnedAtPoint4 = true;
        }

        //체력 바 설정
        this.health = healthMax;
        //체력바 회전각 확인
        healthBar[0].rotation = Quaternion.Euler(0, 0, 0);
        healthBar[1].rotation = Quaternion.Euler(0, 0, 0);


    }





    void Update()
    {

        // 체력 바 업데이트
        HealthBarUpdate();

        //이동 & way point loop 
        Vector2 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

        if (Vector2.Distance(transform.position, target.position) <= 0.05f && spawnedAtPoint1)
        {
            if (waypointIndexPoint1 >= waypoints.points.Length)
            {
                waypointIndexPoint1 = 0;
                getNextWaypoint1();
            }

            else
            {
                getNextWaypoint1();
            }
        }

        if (Vector2.Distance(transform.position, target.position) <= 0.05f && spawnedAtPoint2)
        {
            if (waypointIndexPoint2 >= waypoints.points.Length)
            {
                waypointIndexPoint2 = 0;
                getNextWaypoint2();
            }

            else
            {
                getNextWaypoint2();
            }
        }

        if (Vector2.Distance(transform.position, target.position) <= 0.05f && spawnedAtPoint3)
        {
            if (waypointIndexPoint3 >= waypoints.points.Length)
            {
                waypointIndexPoint3 = 0;
                getNextWaypoint3();
            }

            else
            {
                getNextWaypoint3();
            }
        }

        if (Vector2.Distance(transform.position, target.position) <= 0.05f && spawnedAtPoint4)
        {
            if (waypointIndexPoint4 >= waypoints.points.Length)
            {
                waypointIndexPoint4 = 0;
                getNextWaypoint4();
            }

            else
            {
                getNextWaypoint4();
            }
        }
    }

    //다음 way point 호출 함수
    void getNextWaypoint1()
    {
        waypointIndexPoint1++;
        target = waypoints.points[waypointIndexPoint1 - 1];
        Rotate1();
    }

    void getNextWaypoint2()
    {
        waypointIndexPoint2++;
        target = waypoints.points[waypointIndexPoint2 - 1];
        Rotate2();
    }

    void getNextWaypoint3()
    {
        waypointIndexPoint3++;
        target = waypoints.points[waypointIndexPoint3 - 1];
        Rotate3();
    }

    void getNextWaypoint4()
    {
        waypointIndexPoint4++;
        target = waypoints.points[waypointIndexPoint4 - 1];
        Rotate4();
    }


    //enemy prefab 회전
    void Rotate1()
    {
        var dir = waypoints.points[waypointIndexPoint1 - 1].position - transform.position;
        var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }

    void Rotate2()
    {
        var dir = waypoints.points[waypointIndexPoint2 - 1].position - transform.position;
        var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }

    void Rotate3()
    {
        var dir = waypoints.points[waypointIndexPoint3 - 1].position - transform.position;
        var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }

    void Rotate4()
    {
        var dir = waypoints.points[waypointIndexPoint4 - 1].position - transform.position;
        var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }

    void HealthBarUpdate()
    {
        float ratio = health / healthMax; //체력 비율

        //피해를 입으면 체력바 표시
        if (ratio < 1)
        {
            healthBar[0].gameObject.SetActive(true);
            healthBar[1].gameObject.SetActive(true);
        }

        //체력바 위치 재설정
        if (healthBar[0].gameObject.activeSelf)
        {
            healthBar[0].localScale = new Vector3(ratio * 0.6f, 0.05f, 1); //크기 조절
            healthBar[1].localScale = new Vector3(0.6f, 0.05f, 1); //크기 조절
            
            healthBar[0].position = transform.position + new Vector3(-(1 - ratio) * 0.3f, 0.3f, 0);
            healthBar[1].position = transform.position + new Vector3(-(1 - ratio) * 0.3f, 0.3f, 0);//위치 조절

        }
    }
    public void TakeDamage(int damage)
    {
        
        if (this.isDead == true) return;

        this.health -= damage;

        if (this.health <= 0)
        {
            this.isDead = true;
            this.OnDie();
        }
        
    }
    public void OnDie()
    {
        Destroy(this.gameObject);
    }
}
