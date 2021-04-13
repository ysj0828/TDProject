using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TowerState { SearchTarget = 0, AttackToTarget }
public class BulletScript : MonoBehaviour
{

    public GameObject bulletPrfab;                              //총알 모양
    public Transform towerMuzzle;                               //총구 위치
    public float attackRate = 0.5f;                             //공격 속도
    public float attackRange = 4.0f;                            //공격 범위
    public int attackDamage = 1;                                //공격력
    private TowerState towerState = TowerState.SearchTarget;    //타워 상태 (적찾기, 공격중)
    private Transform targetEnemy = null;                       //적 타겟

    // Start is called before the first frame update
    public void Start()
    {
        ChangeState(TowerState.SearchTarget); //시작시 적 찾기모드 설정
    }

   
    private void Update()
    {
        if (targetEnemy != null) //주변 적 존재시
        {
            RotateToTarget(); //타워 회전함수 호출
        }
    }

    private void RotateToTarget()  //적 위치로 회전
    {
        float dx = targetEnemy.position.x - transform.position.x;
        float dy = targetEnemy.position.y - transform.position.y;
        float degree = Mathf.Atan2(dy, dx) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 0, degree), 0.01f);
    }

    public void ChangeState(TowerState newState)// 타워 스테이스 변경 함수
    {
        StopCoroutine(towerState.ToString());//enum 에서 값 찾아서 현재 호출되는 지속 함수 멈추고

        towerState = newState;

        StartCoroutine(towerState.ToString()); //새로운 스테이터스로 변경후 지속함수 호출
    }

    private IEnumerator SearchTarget() //찾는 모드일때 지속함수
    {
        while (true)
        {
            float closestDistSqr = Mathf.Infinity;
            Transform enemys = null;
            enemys = GameObject.Find("Enemy_fast(Clone)").transform; // 여기서 적없으면 에러남 ㅋㅋㅋㅋㅋㅋ
            if (enemys != null)                                      // 적 찾은경우에 거리 계산해서 이전 적 거리보다 가까우면 타겟 바꾸는 함수인데 작동 안되는듯 ㅋㅋㅋㅋ (이래서 전에 리스트로 했던거)
            {
                float distance = Vector3.Distance(enemys.position, transform.position);
                if (distance <= attackRange && distance <= closestDistSqr)
                {
                    closestDistSqr = distance;
                    targetEnemy = enemys;
                }
            }
            if (targetEnemy != null)
            {
                ChangeState(TowerState.AttackToTarget);  //적 찾으면 공격모드로 변경
            }

            else
            {
                continue;
            }
            yield return null;
        }
    }
    private IEnumerator AttackToTarget() //공격모드일때 지속함수
    {
        while (true)
        {
            if (targetEnemy == null)
            {
                ChangeState(TowerState.SearchTarget); //적 없으면 공격중지
                break;
            }

            float distance = Vector3.Distance(targetEnemy.position, transform.position);
            if (distance > attackRange) // 적 멀어지면 공격 중지
            {
                targetEnemy = null;
                ChangeState(TowerState.SearchTarget);
                break;
            }
            yield return new WaitForSeconds(attackRate); //함수 반복 호출되는 시간 (기존 정한 공격속도)

            SpawnBullet();  //총알 생성함수 (아래)
        }
    }

    private void SpawnBullet()
    {
        GameObject clone = Instantiate(bulletPrfab, towerMuzzle.position, Quaternion.identity);  //총알 지속적으로 클로닝 (어택함수 한번 호출 될때마다)
        clone.GetComponent<Projectile>().Setup(targetEnemy, attackDamage);   //프로젝타일 함수에 셋업 호출 (데미지랑 적 설정해서 타겟따라 움직임, 로테이션 변경등)

    }
}
