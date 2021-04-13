using UnityEngine;

public class Projectile : MonoBehaviour
{
    private Movement2D movement2D;
    private Transform target;
    private int damage;

    public void Setup(Transform target, int damage) //불릿스크립트에서 부르는 셋업 함수
    {
        movement2D = GetComponent<Movement2D>();  //이동설정위한 무브먼트 호출 및 타겟, 데미지 설정
        this.target = target;    
        this.damage = damage;
        if (target != null){
            RotateToTarget();
        }

    }
    
    private void Update()
    {
        if (target != null)  //적 위치 지속적으로 파악 후 경로 변경
        {
            Vector3 direction = (target.position - transform.position).normalized;
            movement2D.MoveTo(direction);
            
        }
        else //적 없을경우 오브젝트 파괴
        {
            Destroy(gameObject);
        }
    }
    
    private void RotateToTarget() //적 방향으로 총알 회전
    {
        float dx = target.position.x - transform.position.x;
        float dy = target.position.y - transform.position.y;
        float degree = Mathf.Atan2(dy, dx) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, degree);
        
    }
    private void OnTriggerEnter2D(Collider2D collision) // 적과 부딛혔을경우 적에게 데미지 주는 함수 후출 및 총알 삭제.
    {
        if (!collision.CompareTag("Enemy")) return;
        if (collision.transform != target) return;

        collision.GetComponent<EnemyScript>().TakeDamage(damage);
        Destroy(gameObject);
    }
}
