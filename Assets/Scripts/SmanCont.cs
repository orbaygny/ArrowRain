using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoreMountains.NiceVibrations;

public class SmanCont : MonoBehaviour
{
    [SerializeField] private Transform head;
    [SerializeField] private Transform spine;
    
     private int hitCount = 0;
    Animator animator;

    [HideInInspector] public bool isDead;

    public float smanHP;
    public int smanDmg;
    
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        if(PlayerPrefs.GetInt("level") == 0)
        {
            animator.SetBool("Tutorial", true);
            AiParent.Instance.transform.position = new Vector3(0, 6, -0.15f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameManager.Instance.firstStart && !isDead && !GameManager.Instance.gameEnd && AiParent.Instance.move)
        {
            if(PlayerPrefs.GetInt("level") != 0)
            {
                transform.position -= transform.forward * -0.15f * Time.deltaTime;
            }
             
            
            animator.applyRootMotion = true;
            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, 180, transform.rotation.eulerAngles.z);
        }
       else if(GameManager.Instance.gameEnd){ animator.SetBool("Lost", true);  }
    }

    public void GetDamage(float damage)
    {
        if (smanHP > 0)
        {
            smanHP -= damage;
        }
        if(smanHP <= 0 && !isDead)
            {
            MMVibrationManager.Haptic(HapticTypes.HeavyImpact);
            if (GameManager.Instance.dmgLvl < 3)      { head.GetChild(0).gameObject.SetActive(true); }
            else if(GameManager.Instance.dmgLvl < 5)  { head.GetChild(1).gameObject.SetActive(true); }
            else if(GameManager.Instance.dmgLvl < 7)  { head.GetChild(2).gameObject.SetActive(true); }
            else if(GameManager.Instance.dmgLvl < 9)  { head.GetChild(3).gameObject.SetActive(true); }
            else if(GameManager.Instance.dmgLvl < 11) { head.GetChild(4).gameObject.SetActive(true); }
            else if(GameManager.Instance.dmgLvl < 13) { head.GetChild(5).gameObject.SetActive(true); }
            else if(GameManager.Instance.dmgLvl < 15) { head.GetChild(6).gameObject.SetActive(true); }
            else if(GameManager.Instance.dmgLvl < 17) { head.GetChild(7).gameObject.SetActive(true); }
            else if(GameManager.Instance.dmgLvl >= 17) { head.GetChild(8).gameObject.SetActive(true); }
            
            Death();
            isDead = true;
        }

            else if(!isDead)
        {
            MMVibrationManager.Haptic(HapticTypes.SoftImpact);
            if (GameManager.Instance.dmgLvl < 3) { spine.GetChild(1).GetChild(hitCount).gameObject.SetActive(true); }
            else if (GameManager.Instance.dmgLvl < 5) { spine.GetChild(2).GetChild(hitCount).gameObject.SetActive(true); }
            else if (GameManager.Instance.dmgLvl < 7) { spine.GetChild(3).GetChild(hitCount).gameObject.SetActive(true); }
            else if (GameManager.Instance.dmgLvl < 9) { spine.GetChild(4).GetChild(hitCount).gameObject.SetActive(true); }
            else if (GameManager.Instance.dmgLvl < 11) { spine.GetChild(5).GetChild(hitCount).gameObject.SetActive(true); }
            else if (GameManager.Instance.dmgLvl < 13) { spine.GetChild(6).GetChild(hitCount).gameObject.SetActive(true); }
            else if (GameManager.Instance.dmgLvl < 15) { spine.GetChild(7).GetChild(hitCount).gameObject.SetActive(true); }
            else if (GameManager.Instance.dmgLvl < 17) { spine.GetChild(8).GetChild(hitCount).gameObject.SetActive(true); }
            else if (GameManager.Instance.dmgLvl >= 17) { spine.GetChild(9).GetChild(hitCount).gameObject.SetActive(true); }
            
            hitCount++;
        }
    }

    public void Death()
    {
        GetComponent<CapsuleCollider>().enabled = false;
        AiParent.Instance.deathCount++;
        GameManager.Instance.SetMoney();
        animator.SetBool("Death", true);
    }
}
