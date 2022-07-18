using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using ElephantSDK;
public class DrawObj : MonoBehaviour
{
    public static DrawObj Instance { get; private set; }
   
    [SerializeField] Camera mainCam;
    [SerializeField] private LayerMask layerMask;
    [SerializeField] private TrailRenderer trail;


    Vector3 pos;
    //TrailRenderer trail;
    Vector3[] positions;
    public GameObject arrow;
    public Transform arrowPoint;


    public int arrowCount;
    public int lastCount;

    public int money;

    int enemyCnt;
    private void Awake()
    {
        Instance = this;
       
    }
    // Start is called before the first frame update
    void Start()
    {
        enemyCnt = AiParent.Instance.transform.childCount;
        arrowCount = GameManager.Instance.arrowCount;
        money = GameManager.Instance.money;
        lastCount = 0;
       /* pos = Input.mousePosition;

         pos.y = transform.position.y;
         transform.position = pos;*/

        //trail = GetComponent<TrailRenderer>();

    }

    // Update is called once per frame
    void Update()
    {
        if (arrowCount == 0) { StartCoroutine(FailGame()); }
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit,100,layerMask))
        {
            Debug.Log("Ray Girdi");
            Vector3 point = hit.point;
            point.y = 0.18f;
            transform.position = point;
            Debug.DrawLine(ray.origin, hit.point);
        }
        
        /*pos = Input.mousePosition;
        pos.y = transform.position.y;
        transform.position = pos;*/

       

        if (Input.GetMouseButton(0) && arrowCount >0 && !GameManager.Instance.firstStart && !GameManager.Instance.gameEnd)
        {
            trail.enabled = true;
            if (trail.positionCount > lastCount)
            {
                arrowCount -= trail.positionCount - lastCount;
                lastCount = trail.positionCount;
            }
        }

        if (Input.GetMouseButtonUp(0) || arrowCount == 0 )
        {
            if (!GameManager.Instance.firstStart)
            {
                CreateArrows();
                Debug.Log("çıktı");
                trail.Clear();
                trail.enabled = false;
                lastCount = 0;
            }
        }
    }


    public void CreateArrows()
    {
        positions = new Vector3[trail.positionCount];
        trail.GetPositions(positions);
        foreach (Vector3 pos in positions)
        {
            Vector3 tmp = new Vector3(pos.x, mainCam.transform.position.y, mainCam.transform.position.z);
            GameObject temp = Instantiate(arrow,
                         tmp, arrow.transform.rotation);
            temp.GetComponent<ArrowMove>().movePos = pos;
            temp.GetComponent<ArrowMove>().move = true;
        }

        
    }

    public IEnumerator FailGame()
    {
        yield return new WaitForSeconds(1.5f);
        if (AiParent.Instance.deathCount < enemyCnt)
        {
            CanvasCont.Instance.GameLose();
        }
    }
}
