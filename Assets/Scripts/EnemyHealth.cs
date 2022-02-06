using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int enemyHealth;
    [SerializeField] AudioClip fireSound;
    [SerializeField] GameObject destroyEfect;
  
    AudioSource audioSource;
    AddCoins coins;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        coins = FindObjectOfType<AddCoins>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyHealth == 0)
        {
            coins.AddCoints();
            enemyHealth--;
            
            Destroy(gameObject,0.7f);
        }
    }
    private void OnParticleCollision(GameObject other)
    {
        enemyHealth--;
        GameObject Ef = Instantiate(destroyEfect, transform.position, transform.rotation);
        Destroy(Ef, 0.5f);
        audioSource.PlayOneShot(fireSound);
               
    }
}
