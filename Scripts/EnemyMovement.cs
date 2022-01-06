using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyMovement : MonoBehaviour
{
    
    private Transform _target;
    private int _wavePointIndex;

    [SerializeField] private Transform retrunPoint;

    private Enemy enemy;

    private void Start()
    {
        retrunPoint = GameObject.FindGameObjectWithTag("EndPoint").GetComponent<Transform>();
        enemy = GetComponent<Enemy>();
        _target = WayPoint.wayPoints[0];
    }
    private void Update()
    {
        Vector3 dir = _target.position - transform.position;
        transform.Translate(dir.normalized * enemy._speed * Time.deltaTime, Space.World);
        if (enemy.dead)
        {
            _target = retrunPoint;
            return;
        }
        enemy._speed = enemy.startSpeed;
        if (Vector3.Distance(transform.position, _target.position) <= 0.4f)
        {
            SelectNewTarget();
        }
        

       
    }
    void SelectNewTarget()
    {
        if (_wavePointIndex >= WayPoint.wayPoints.Length - 1)
        {
            PlayerStats.Fishes--;
            Destroy(gameObject);
            return;
        }
        _wavePointIndex++;
        
        
        _target = WayPoint.wayPoints[_wavePointIndex];
    }

}
