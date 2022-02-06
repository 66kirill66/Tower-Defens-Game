using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ShopMenu : MonoBehaviour
{
    [SerializeField] GameObject pauseText;
    bool isPaused;


    private GameObject flyingGun;
    private Camera mainCamera;
    AddCoins coints;
    RaycastHit hit;
    int costBild;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        coints = GetComponent<AddCoins>();
        mainCamera = Camera.main;
        isPaused = false;
    }

    // Update is called once per frame
    void Update()
    {
        PouseMenu();

        if (flyingGun != null)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                Vector3 worldPosition = hit.point;
                flyingGun.transform.position = worldPosition;
                if (Input.GetMouseButtonDown(0))
                {
                    if (Physics.Raycast(ray, out hit))
                    {
                        if (hit.transform.gameObject.tag == "Quad" && coints.currentCoints >= 10)
                        {
                            coints.TakeCoints(costBild);
                            Instantiate(flyingGun, hit.point, transform.rotation);
                            Destroy(hit.transform.gameObject);   // destroy Quad
                        }
                        Destroy(flyingGun);
                        Time.timeScale = 1;
                    }
                }
            }
        }
    }
    public void StartPlacingGun(GameObject gun)
    {
        if (coints.currentCoints >= 20)
        {
            if (flyingGun != null)
            {
                Destroy(flyingGun);
            }
            flyingGun = Instantiate(gun);
            costBild = 20;
            Time.timeScale = 0;
        }
            
        
    }
    public void StartPlacingSmallGun(GameObject gun)
    {
        if(coints.currentCoints >= 10)
        {
            if (flyingGun != null)
            {
                Destroy(flyingGun);
            }
            flyingGun = Instantiate(gun);
            costBild = 10;
            Time.timeScale = 0;
        }
        

    }

    private void PouseMenu()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused == false)
            {
                Time.timeScale = 0;
                pauseText.SetActive(true);
                isPaused = true;
            }
            else if (isPaused == true)
            {
                pauseText.SetActive(false);
                Time.timeScale = 1;
                isPaused = false;
            }
        }
    }
    public void StartGame()
    {
        SceneManager.LoadScene(0);      
    }

    
}
