using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class CanvasCont : MonoBehaviour
{
    public static CanvasCont Instance { get; private set; }

    public GameObject buttonPanel;
    public GameObject startText;
    public Slider hpSlider;
    public GameObject winPanel;
    public GameObject failPanel;
    public GameObject outAmmoText;

    public TextMeshProUGUI lvlText;

    bool winLevel;
    bool lostLevel;
    
    private void Awake()
    {
        winLevel = true;
        lostLevel = true;

        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        lvlText.text = "Lv. "+(PlayerPrefs.GetInt("level")+1);
    }

    // Update is called once per frame
    void Update()
    {
        hpSlider.value = GameManager.Instance.playerHP;
        if (!GameManager.Instance.firstStart)
        {
            buttonPanel.SetActive(false);
            startText.SetActive(false);
        }
    }

    public void GameWin()
    {

        if (!GameManager.Instance.gameEnd)
        {
            if (winLevel)
            {
                
                winLevel = false;
            }
            GameManager.Instance.gameEnd = true;
            winPanel.SetActive(true);
            InterstitialsManager.Instance.ShowInterstitial();
        }
        
    }

    public void GameLose()
    {
        if (!GameManager.Instance.gameEnd)
        {
            if (lostLevel)
            {
                
                lostLevel = false;
            }
            GameManager.Instance.gameEnd = true;
            if (DrawObj.Instance.arrowCount == 0) { outAmmoText.SetActive(true); }
            failPanel.SetActive(true);
            InterstitialsManager.Instance.ShowInterstitial();
        }
        
    }
}
