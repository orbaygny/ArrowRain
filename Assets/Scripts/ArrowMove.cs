using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ArrowMove : MonoBehaviour
{
    [HideInInspector] public bool move;
    [HideInInspector] public Vector3 movePos;
    Transform currentProjectile;
    bool vanish;
    // Start is called before the first frame update
    void Start()
    {
        if (GameManager.Instance.dmgLvl >= 3 && GameManager.Instance.dmgLvl < 5)
        {
            foreach(Transform child in transform)
                {
                child.gameObject.SetActive(false);
            }
            transform.GetChild(1).gameObject.SetActive(true);
            currentProjectile = transform.GetChild(1);
        }

       else if (GameManager.Instance.dmgLvl >= 5 && GameManager.Instance.dmgLvl < 7)
        {
            foreach (Transform child in transform)
            {
                child.gameObject.SetActive(false);
            }
            transform.GetChild(2).gameObject.SetActive(true);
            currentProjectile = transform.GetChild(2);
        }

       else if (GameManager.Instance.dmgLvl >= 7 && GameManager.Instance.dmgLvl < 9)
        {
            foreach (Transform child in transform)
            {
                child.gameObject.SetActive(false);
            }
            transform.GetChild(3).gameObject.SetActive(true);
            currentProjectile = transform.GetChild(2);
        }
        else if (GameManager.Instance.dmgLvl >= 9 && GameManager.Instance.dmgLvl < 11)
        {
            foreach (Transform child in transform)
            {
                child.gameObject.SetActive(false);
            }
            transform.GetChild(4).gameObject.SetActive(true);
            currentProjectile = transform.GetChild(4);
        }

        else if (GameManager.Instance.dmgLvl >= 11 && GameManager.Instance.dmgLvl < 13)
        {
            foreach (Transform child in transform)
            {
                child.gameObject.SetActive(false);
            }
            transform.GetChild(5).gameObject.SetActive(true);
            currentProjectile = transform.GetChild(5);
        }
        else if (GameManager.Instance.dmgLvl >= 13 && GameManager.Instance.dmgLvl < 15)
        {
            foreach (Transform child in transform)
            {
                child.gameObject.SetActive(false);
            }
            transform.GetChild(6).gameObject.SetActive(true);
            currentProjectile = transform.GetChild(6);
        }
        else if (GameManager.Instance.dmgLvl >= 15 && GameManager.Instance.dmgLvl < 17)
        {
            foreach (Transform child in transform)
            {
                child.gameObject.SetActive(false);
            }
            transform.GetChild(7).gameObject.SetActive(true);
            currentProjectile = transform.GetChild(7);
        }

        else if (GameManager.Instance.dmgLvl >= 17 )
        {
            foreach (Transform child in transform)
            {
                child.gameObject.SetActive(false);
            }
            transform.GetChild(8).gameObject.SetActive(true);
            currentProjectile = transform.GetChild(8);
        }

        else
        {
            currentProjectile = transform.GetChild(0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.dmgLvl >= 3 && GameManager.Instance.dmgLvl < 5)
        {
            foreach (Transform child in transform)
            {
                child.gameObject.SetActive(false);
            }
            transform.GetChild(1).gameObject.SetActive(true);
            currentProjectile = transform.GetChild(1);
        }

        else if (GameManager.Instance.dmgLvl >= 5 && GameManager.Instance.dmgLvl < 7)
        {
            foreach (Transform child in transform)
            {
                child.gameObject.SetActive(false);
            }
            transform.GetChild(2).gameObject.SetActive(true);
            currentProjectile = transform.GetChild(2);
        }

        else if (GameManager.Instance.dmgLvl >= 7 && GameManager.Instance.dmgLvl < 9)
        {
            foreach (Transform child in transform)
            {
                child.gameObject.SetActive(false);
            }
            transform.GetChild(3).gameObject.SetActive(true);
            currentProjectile = transform.GetChild(3);
        }
        else if (GameManager.Instance.dmgLvl >= 9 && GameManager.Instance.dmgLvl < 11)
        {
            foreach (Transform child in transform)
            {
                child.gameObject.SetActive(false);
            }
            transform.GetChild(4).gameObject.SetActive(true);
            currentProjectile = transform.GetChild(4);
        }

        else if (GameManager.Instance.dmgLvl >= 11 && GameManager.Instance.dmgLvl < 13)
        {
            foreach (Transform child in transform)
            {
                child.gameObject.SetActive(false);
            }
            transform.GetChild(5).gameObject.SetActive(true);
            currentProjectile = transform.GetChild(5);
        }
        else if (GameManager.Instance.dmgLvl >= 13 && GameManager.Instance.dmgLvl < 15)
        {
            foreach (Transform child in transform)
            {
                child.gameObject.SetActive(false);
            }
            transform.GetChild(6).gameObject.SetActive(true);
            currentProjectile = transform.GetChild(6);
        }
        else if (GameManager.Instance.dmgLvl >= 15 && GameManager.Instance.dmgLvl < 17)
        {
            foreach (Transform child in transform)
            {
                child.gameObject.SetActive(false);
            }
            transform.GetChild(7).gameObject.SetActive(true);
            currentProjectile = transform.GetChild(7);
        }

        else if (GameManager.Instance.dmgLvl >= 17)
        {
            foreach (Transform child in transform)
            {
                child.gameObject.SetActive(false);
            }
            transform.GetChild(8).gameObject.SetActive(true);
            currentProjectile = transform.GetChild(8);
        }
        if (move)
        {
            transform.DOMove(movePos, 0.5f).OnComplete(VanishTrue);
        }

        if (vanish)
        {
            StartCoroutine(DestroyTheProjectile());
            vanish = false;
        }
    }

    private void VanishTrue() { vanish = true; }

    private IEnumerator DestroyTheProjectile()
    {
        currentProjectile.GetComponent<BoxCollider>().enabled = false;
        yield return new WaitForSeconds(4f);
        move = false;
        transform.DOKill();
        Destroy(gameObject);
    }

    public void Trigger()
    {
        move = false;
        transform.DOKill();
        Destroy(gameObject);


    }
}
