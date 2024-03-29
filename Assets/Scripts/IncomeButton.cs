using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IncomeButton : MonoBehaviour
{
    [SerializeField] private Text costText;
    [SerializeField] private Text lvText;
    [SerializeField] private Button button;
    [SerializeField] private Image image;
    [SerializeField] private GameObject effect;

    private Color32 alpha;

    // Start is called before the first frame update
    void Start()
    {
        lvText.text = "lv. " + GameManager.Instance.incLvl;
        costText.text = GameManager.Instance.incCost.ToString();
     
        alpha = image.color;
        if (GameManager.Instance.incCost > GameManager.Instance.money)
        {
            button.interactable = false;
            alpha.a = 100;
            image.color = alpha;
            effect.SetActive(false);
        }

        else
        {
            button.interactable = true;
            alpha.a = 255;
            image.color = alpha;
            effect.SetActive(true);
        }


    }

    // Update is called once per frame
    void Update()
    {
        if (!GameManager.Instance.gameEnd)
        {
            lvText.text = "lv. " + GameManager.Instance.incLvl;
            costText.text = GameManager.Instance.incCost.ToString();
            if (GameManager.Instance.incCost > GameManager.Instance.money)
            {
                button.interactable = false;
                alpha.a = 100;
                image.color = alpha;
                effect.SetActive(false);
            }

            else
            {
                button.interactable = true;
                alpha.a = 255;
                image.color = alpha;
                effect.SetActive(true);
            }
        }
       
    }
}
