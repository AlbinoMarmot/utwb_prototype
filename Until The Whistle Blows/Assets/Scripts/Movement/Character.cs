using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Character : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    ////https://dev.to/matthewodle/simple-ui-element-dragging-script-in-unity-c-450p
    ////
    //private bool dragging;
    //private Vector2 offset;

    //public void Update()
    //{
    //    if (dragging)
    //    {
    //        transform.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y) - offset;
    //    }
    //}

    //public void OnPointerDown(PointerEventData eventData)
    //{
    //    dragging = true;
    //    offset = eventData.position - new Vector2(transform.position.x, transform.position.y);
    //}

    //public void OnPointerUp(PointerEventData eventData)
    //{
    //    dragging = false;
    //}



    //https://www.youtube.com/watch?v=BGr-7GZJNXg

    [SerializeField] private Canvas canvas;
    

    private RectTransform rectTransform;
    private Vector3 startpos;
    public Text displayamount;
    //sets what supply character grabs
   public bool F, S, A;
    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        startpos = transform.position;
    }

    private void Start()
    {
        
        
    }
    private void Update()
    {
        if (F)
        {
            displayamount.GetComponent<Text>().text = "Food";
        }
        else if (S)
        {
            displayamount.GetComponent<Text>().text = "Supplies";
        }
        else if (A)
        {
            displayamount.GetComponent<Text>().text = "Ammo";
        }
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("OnBeginDrag");
    }

    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("OnDrag");
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("OnEndDrag");
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("OnPointerDown");
    }

    public void Peset()
    {
        transform.position = startpos;
    }





    //https://answers.unity.com/questions/865952/how-to-click-and-drag-game-objects.html

    //private Vector3 screenPoint;
    //private Vector3 offset;
    ////public Camera cam;
    //// Start is called before the first frame update
    //void Start()
    //{

    //}

    //// Update is called once per frame
    //void Update()
    //{

    //}


    //void OnMouseDown()
    //{
    //    screenPoint = UnityEngine.Camera.main.WorldToScreenPoint(transform.position);
    //    offset = transform.position - UnityEngine.Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
    //}

    //void OnMouseDrag()
    //{
    //    Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
    //    Vector3 curPosition = UnityEngine.Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
    //    transform.position = curPosition;
    //}
}
