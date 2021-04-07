using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public float speed = 1000f;

    private Transform target;
    private int waypointIndex = 0;

    void Start()
    {
        target = waypoints.points[0];
    }

    void Update()
    {
        Vector2 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

        if (Vector2.Distance(transform.position, target.position) <= 0.5f)
        {
            if (waypointIndex >= waypoints.points.Length)
            {
                waypointIndex = 0;
                getNextWaypoint();
            }

            else
            {
                getNextWaypoint();
            }
        }
    }

    void getNextWaypoint()
    {
        waypointIndex++;
        target = waypoints.points[waypointIndex - 1];
        Rotate();
    }

    void Rotate()
    {
        var dir = waypoints.points[waypointIndex - 1].position - transform.position;
        var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }
}
