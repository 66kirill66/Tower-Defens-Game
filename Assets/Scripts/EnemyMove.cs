using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMove : MonoBehaviour
{
    NavMeshAgent agent;
    [SerializeField] Transform cube;
    
    void Start()
    {       
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(cube.position);
        if(transform.position == cube.position)
        {
            Destroy(gameObject);
        }
    }  
}
