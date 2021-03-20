using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private int wayPointCount;
    private Transform[] wayPoints;
    private int currentIndex = 0;
    private Movement2D movement2D;
    private EnemySpawner enemySpawner;

    public void Setup(EnemySpawner enemySpawner, Transform[] wayPoints)
    {
        movement2D = GetComponent<Movement2D>();
        this.enemySpawner = enemySpawner;

        wayPointCount = wayPoints.Length;
        this.wayPoints = new Transform[wayPointCount];
        this.wayPoints = wayPoints;

        transform.position = wayPoints[currentIndex].position;
        Rotate();

        StartCoroutine("Onmove");

    }
    private IEnumerator Onmove()
    {
        NextMoveTo();

        while (true)
        {
            if (Vector3.Distance(transform.position,wayPoints[currentIndex].position)<0.02f * movement2D.MoveSpeed)
            {
                NextMoveTo();
            }

            yield return null;
        }
    }
    private void NextMoveTo()
    {
        if(currentIndex < wayPointCount - 1)
        {
            transform.position = wayPoints[currentIndex].position;
            currentIndex++;
            Vector3 direction = (wayPoints[currentIndex].position - transform.position).normalized;
            Rotate();
            movement2D.MoveTo(direction);
        }
        else if (currentIndex == 3)
        {
            transform.position = wayPoints[currentIndex].position;
            currentIndex = 0;
            Vector3 direction = (wayPoints[currentIndex].position - transform.position).normalized;
            Rotate();
            movement2D.MoveTo(direction);
        }
        else
        {
            OnDie();
        }
    }
    private void Rotate()
    {
        float dx = wayPoints[currentIndex].position.x - transform.position.x;
        float dy = wayPoints[currentIndex].position.y - transform.position.y;
        float degree = Mathf.Atan2(dy, dx) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, degree);
    }
    public void OnDie()
    {
        enemySpawner.DestroyEnemy(this);
    }
}
