using UnityEngine;

public class Turret : MonoBehaviour
{
    //lock on the closest enemy nearby 
    //create gizmos around the turret to see the range
    private Transform target;
    private Enemy targetEnemy;
    [Header("General")]
    [SerializeField] private float _range;
    [Header("Use Bullets")]
    [SerializeField] private Transform _partToRotate;
    [SerializeField] private GameObject bullet;
    [SerializeField] private int damageOverTime;
    [Header("UseLaser")]
    public bool useLaser = false;
    public LineRenderer lineRenderer;
    [SerializeField] private ParticleSystem impactEffect;
    [SerializeField] private Light impactLight;
    [SerializeField] private float slowPrecent;

    [Header("Unity Setup Field")]
    private float _turnSpeed = 10f;
    [SerializeField]private Transform firePoint;
    private float fireCountDown;
    public float fireRate = 0.3f;
    private Enemy enemyScript;
    

    private void Start()
    {
        InvokeRepeating(nameof(UpdateTarget), 0f, 0.5f);
    }

    void UpdateTarget()
    {
        
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;
        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            enemyScript = enemy.GetComponent<Enemy>();
            if (distanceToEnemy < shortestDistance && !enemyScript.dead )
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
                
            }
            else
            {
                target = null;
            }
        }
        if (nearestEnemy != null && shortestDistance <= _range)
        {
            target = nearestEnemy.transform;
            targetEnemy = nearestEnemy.GetComponent<Enemy>();

        }
        else
        {
            target = null;
        }

        
    }

    private void Shoot()
    {
        if (fireCountDown > 0) return;
        GameObject bulletGO = (GameObject)Instantiate(bullet, firePoint.position, firePoint.rotation);
        Bullet bulletScript = bulletGO.GetComponent<Bullet>();
        if (bullet != null) bulletScript.Seek(target);
        print("i shoot!");
    }

    private void Update()
    {
        print(fireCountDown);
        
        if (target == null) 
        {
            if (useLaser)
            {
                if (lineRenderer.enabled)
                {
                    lineRenderer.enabled = false;
                    impactEffect.Stop();
                    impactLight.enabled = false;
                }
            }

            return;
        }
        TurretHeadRotation();

        if (useLaser)
        {
            Laser();
        }
        else
        {
            if (fireCountDown <= 0)
            {
                Shoot();
                fireCountDown = 1f / fireRate;
            }
            fireCountDown -= Time.deltaTime;
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _range);
    }
    void TurretHeadRotation()
    {
        if (target == null) return;
        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(_partToRotate.rotation, lookRotation, Time.deltaTime * _turnSpeed).eulerAngles;
        _partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);
        
    }
    void Laser()
    {
        targetEnemy.TakeDamage(damageOverTime * Time.deltaTime);
        targetEnemy.Slow(slowPrecent);
        
        if (!lineRenderer.enabled)
        {
            lineRenderer.enabled = true;
            impactEffect.Play();
            impactLight.enabled = true;
        }
        lineRenderer.SetPosition(0, firePoint.position);
        lineRenderer.SetPosition(1, target.position);

        Vector3 dir = firePoint.position - target.position;
        impactEffect.transform.position = target.position + dir.normalized * .5f;
        
        impactEffect.transform.rotation = Quaternion.LookRotation(dir);
    }

    public void SetFireRate(float _fireRate)
    {
        fireCountDown = 1f / _fireRate;
    }
}
