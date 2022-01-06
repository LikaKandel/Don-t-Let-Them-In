using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform target;
    [SerializeField] private float speed = 70f;
    [SerializeField] private float explosionRadius = 70f;
    [SerializeField] private int damage = 20;
    //[SerializeField] private GameObject particles;

    public void Seek (Transform _target)
    {
        target = _target;
    }
    private void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.position - transform.position;
        
        float distanceThisFrame = speed * Time.deltaTime;

        if (dir.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }

        transform.Translate(dir.normalized * distanceThisFrame, Space.World);
        transform.LookAt(target);
        
    }

    private void HitTarget()
    {
        //GameObject effectIns = (GameObject)Instantiate(particles, transform.position, transform.rotation);
        //Destroy(effectIns, 2f);
        if (explosionRadius > 0)
        {
            Explode();
        }
        else if (explosionRadius == 0)
        {
            Damage(target);
        }
        Destroy(gameObject);
    }

    private void Damage(Transform enemy)
    {
        Enemy enemyScript = enemy.GetComponent<Enemy>();
        if (enemyScript != null)
        {
            enemyScript.TakeDamage(damage);
        }
    }
    private void Explode()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);
        foreach (Collider collider in colliders)
        {
            if (collider.tag == "Enemy")
            {
                Damage(collider.transform);
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Border"))
        {
            Destroy(gameObject);
            print("bullet destroyed");
        }
    }
}
