using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CurrentMoney : MonoBehaviour
{
    Text currentMoney;
    // Start is called before the first frame update
    void Start()
    {
        currentMoney = GetComponent<Text>();
        currentMoney.text = GameManager.Instance.money.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        currentMoney.text = GameManager.Instance.money.ToString();
    }
}
