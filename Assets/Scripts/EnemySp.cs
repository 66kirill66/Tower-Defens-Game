using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySp : MonoBehaviour
{
    [SerializeField] float secondsBetweenSpawns = 2f;
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] GameObject enemyPrefab2;
    [SerializeField] Transform enemyParentTransform;
     
    public int score;   
    void Start()
    {
        score = 0;
        StartCoroutine(RepeatedLySpawnEnemies());      
    }
    IEnumerator RepeatedLySpawnEnemies()
    {
        while (true)  //forever
        {
            if (score <= 10)
            {
                AddScore();
                GameObject newEnemy = Instantiate(enemyPrefab, transform.position, Quaternion.identity);
                newEnemy.transform.parent = enemyParentTransform;   // transfer clones to empty plase
                yield return new WaitForSeconds(secondsBetweenSpawns);  // Wait  2 seconds and then agane
            }
            else
            {
                AddScore();
                GameObject newEnemy = Instantiate(enemyPrefab2, transform.position, Quaternion.identity);
                newEnemy.transform.parent = enemyParentTransform;   // transfer clones to empty plase
                yield return new WaitForSeconds(secondsBetweenSpawns);  // Wait  2 seconds and then agane
            }
            
        }
    }
    private void AddScore()
    {
        score++;       
    }
}
