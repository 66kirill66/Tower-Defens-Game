using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerMove : MonoBehaviour
{
    [SerializeField] float attackRange;       
    Transform targetEnemy;
    [SerializeField] ParticleSystem shootEf;
    
   
    void Update()
    {
        SetTargetEnemy();

        if (targetEnemy)
        {
            LookAtEnemy();   //transform.LookAt(targetEnemy);

            FireAtEnemy();
        }
        else
        {
            Shoot(false);
        }
    }

    private void SetTargetEnemy()   // Find Enemyes
    {

        var sceneEnemies = FindObjectsOfType<EnemyHealth>(); //  Find Enemy Helth script in scene
        if (sceneEnemies.Length == 0) { return; }   // if  enemy count = 0 return.

        Transform closestEnemy = sceneEnemies[0].transform;   // enemy [index 0] position

        foreach (EnemyHealth other in sceneEnemies)
        {
            closestEnemy = GetClosest(closestEnemy, other.transform);   //  'GetClosest' update 
        }
        targetEnemy = closestEnemy;
    }

    private Transform GetClosest(Transform transformA, Transform transformB) 
    {
        var distToA = Vector3.Distance(transform.position, transformA.position);   // closestEnemy
        var distToB = Vector3.Distance(transform.position, transformB.position);   //  other.transform
        if (distToA < distToB)
        {
            return transformA;
        }
        return transformB;
    }
    private void FireAtEnemy()
    {
        float distanceToEnemy = Vector3.Distance(targetEnemy.transform.position, transform.position);
        if (distanceToEnemy <= attackRange)
        {          
            Shoot(true);
        }
        else
        {
            Shoot(false);
        }
    }
    public void Shoot(bool isActive)
    {       
        var emissionModule = shootEf.emission;
        emissionModule.enabled = isActive;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }

    private void LookAtEnemy()
    {
        Vector3 direction = targetEnemy.position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Lerp(transform.rotation, rotation, 6 * Time.deltaTime);
    }
}

