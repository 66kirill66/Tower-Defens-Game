using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] Text hp;
    [SerializeField] GameObject hitEffect;
    [SerializeField] Canvas dead;
    public int playerHp;
    // Start is called before the first frame update
    void Start()
    {
        dead.enabled = false;
        playerHp = 3;
    }

    // Update is called once per frame
    void Update()
    {
        hp.text = "Lives : " +  playerHp.ToString();
        if(playerHp <= 0)
        {
            Time.timeScale = 0;
            dead.enabled = true;
            
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            GameObject hit = Instantiate(hitEffect, new Vector3(transform.position.x,transform.position.y + 5 ), transform.rotation);
            Destroy(hit, 1f);
            playerHp--;
            Destroy(collision.gameObject);
        }
        
    }


}
