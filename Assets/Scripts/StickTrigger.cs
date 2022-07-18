using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickTrigger : MonoBehaviour
{
    
    //[SerializeField] private GameObject parentObj;
    

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.CompareTag("Projectile"))
        {
            GetComponent<SmanCont>().GetDamage(GameManager.Instance.arrowDamage);
            Debug.Log(GameManager.Instance.arrowDamage);
            
        }

        if (other.gameObject.CompareTag("Line"))
        {
            CanvasCont.Instance.GameLose();
        }
    }


}
