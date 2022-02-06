using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddCoins : MonoBehaviour
{

    [SerializeField] Text coinText;
    public int currentCoints;

    // Start is called before the first frame update
    void Start()
    {
        coinText.text = "Coints";
        currentCoints = 30;
    }
    public void Update()
    {
        coinText.text = "Coints:" + currentCoints.ToString();
    }

    public void AddCoints()
    {
        currentCoints ++;
        
    }
    public void TakeCoints(int coints)
    {
        currentCoints -= coints;
    }
}
