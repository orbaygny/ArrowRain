using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [HideInInspector] public float arrowDamage;
    [HideInInspector] public int income;
    [HideInInspector] public int arrowCount;

    [HideInInspector] public int dmgLvl;
    [HideInInspector] public int incLvl;
    [HideInInspector] public int cntLvl;

    [HideInInspector] public int dmgCost;
    [HideInInspector] public int incCost;
    [HideInInspector] public int cntCost;

    [HideInInspector] public int money;

    [HideInInspector] public int playerHP;

    [HideInInspector] public bool firstStart;

    [HideInInspector] public bool gameEnd;

    int firstTime;
    public List<GameObject> levels = new List<GameObject>();
    
    [Space]
    [Space]
    public GameObject CurrentLevel;
    public bool isTesting = false;
    // Start is called before the first frame update

    private void Awake()
    {
        Instance = this;
        
        Application.targetFrameRate = 60;

        Screen.sleepTimeout = SleepTimeout.NeverSleep;
        if (isTesting == false)
        {
            if (levels.Count == 0)
            {
                foreach (Transform level in transform)
                {
                    levels.Add(level.gameObject);
                }
            }
            
                CurrentLevel = levels[PlayerPrefs.GetInt("level") % levels.Count];
                levels[PlayerPrefs.GetInt("level") % levels.Count].SetActive(true);
            
        }
        else
        {
            CurrentLevel.SetActive(true);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        firstStart = true;
        gameEnd = false;

        

        arrowDamage = (PlayerPrefs.GetInt("level")+1);
        income = PlayerPrefs.GetInt("income", 5);
        arrowCount = PlayerPrefs.GetInt("arrowCount", 25);

        dmgLvl = PlayerPrefs.GetInt("level") + 1;
        incLvl = PlayerPrefs.GetInt("incLvl", 1);
        cntLvl = PlayerPrefs.GetInt("cntLvl", 1);

        dmgCost = PlayerPrefs.GetInt("dmgCost", 10);
        incCost = PlayerPrefs.GetInt("incCost", 10);
        cntCost = PlayerPrefs.GetInt("cntCost", 10);

        playerHP = 10;
         
        money = PlayerPrefs.GetInt("money", 0);

      
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("ArrowDamage: " + arrowDamage);
        Debug.Log("ArrowLvl" + dmgLvl);

        if (Input.GetMouseButton(0))
        {
            if (firstStart && EventSystem.current.currentSelectedGameObject == null)
            {
                
                firstStart = false;
            }
           


        }
    }

    public void SetArrowDamage()
    {
        Debug.Log("Arrow Damage Setted");

        if (PlayerPrefs.GetInt("level") + 1 > PlayerPrefs.GetInt("dmgLvl", 1))
        {
            PlayerPrefs.SetFloat("arrowDmg", arrowDamage + 0.5f);
            PlayerPrefs.SetInt("dmgLvl", dmgLvl + 1);
        }
        
       
        
    }

    public void SetIncome()
    {
        money -= incCost;
        income += 1;
        incLvl++;
        incCost += 10*incLvl;

        PlayerPrefs.SetInt("money", money);
        PlayerPrefs.SetInt("income", income);
        PlayerPrefs.SetInt("incLvl", incLvl);
        PlayerPrefs.SetInt("incCost", incCost);
    }

    public void SetArrowCount()
    {
        money -= cntCost;
        arrowCount += 5;
        cntLvl++;
        cntCost += 10*cntLvl;
        DrawObj.Instance.arrowCount = arrowCount;
        PlayerPrefs.SetInt("money", money);
        PlayerPrefs.SetInt("arrowCount", arrowCount);
        PlayerPrefs.SetInt("cntLvl", cntLvl);
        PlayerPrefs.SetInt("cntCost", cntCost);
    }

    public void SetMoney()
    {
        
        money += income;
        PlayerPrefs.SetInt("money", money);
    }

    public void PlayerDamage()
    {
        playerHP -= 1;
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void NextLevel()
    {
        //StartCoroutine(LevelUp());
        if ((levels.IndexOf(CurrentLevel) + 1) == levels.Count)
        {
            PlayerPrefs.SetInt("level", PlayerPrefs.GetInt("level") + 1);
            //  GameHandler.Instance.Appear_TransitionPanel();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        else
        {
            CurrentLevel = levels[(PlayerPrefs.GetInt("level") + 1) % levels.Count];
            levels[(PlayerPrefs.GetInt("level")) % levels.Count].SetActive(false);
            PlayerPrefs.SetInt("level", PlayerPrefs.GetInt("level") + 1);
            levels[PlayerPrefs.GetInt("level") % levels.Count].SetActive(true);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }


}
