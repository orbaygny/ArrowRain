using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class AiParent : MonoBehaviour
{
    public static AiParent Instance { get; private set; }
    public int deathCount;
    int childCount;
    public GameObject tutorialPanel;
    public bool move;
    public bool land;
    private void Awake()
    {
        move = false;
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        foreach(Transform child in transform)
        {
            if (child.gameObject.activeSelf)
            {
                childCount++;
            }
        }
        //childCount = transform.childCount;
        
    }

    // Update is called once per frame
    void Update()
    {
        if(deathCount == childCount)
        {
            CanvasCont.Instance.GameWin();
        }

        if (!GameManager.Instance.firstStart && !move && !land)
        {
            
            transform.DOMoveY(0, 0.5f).OnComplete(StartMoving);
            land = true;
        }

    }

    public void StartMoving()
    {
        if(tutorialPanel != null && PlayerPrefs.GetInt("level") == 0)
        {
            tutorialPanel.SetActive(true);
        }
        Debug.Log("Anim Play");
        
        foreach(Transform child in transform)
        {
            child.gameObject.GetComponent<Animator>().SetBool("Land", true);    
        }
    }
}
