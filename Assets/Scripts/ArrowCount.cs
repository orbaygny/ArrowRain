using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ArrowCount : MonoBehaviour
{

    Text arrowCount;
    // Start is called before the first frame update
    void Start()
    {
        arrowCount = GetComponent<Text>();
        arrowCount.text = DrawObj.Instance.arrowCount.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        arrowCount.text = DrawObj.Instance.arrowCount.ToString();
    }
}
