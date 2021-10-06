using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CharacterSlot : MonoBehaviour, IDropHandler
{
    // Start is called before the first frame update
    bool assigned;
    public int RAmount;
    public Text displaytxt;
    ResourceTracker rt;

    private void Start()
    {
        RAmount = Random.Range(2, 7);
        displaytxt.GetComponent<Text>().text = RAmount.ToString();
        rt = GameObject.Find("Canvas").GetComponent<ResourceTracker>();
    }
    private void Update()
    {
        if (assigned)
        {

        }
    }
    public void OnDrop(PointerEventData eventdata)
    {
        if(eventdata.pointerDrag != null && assigned == false)
        {
            eventdata.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
            assigned = true;
            /*if (eventdata.pointerDrag.GetComponent<Character>().F)
            {
                tc.Sfood = tc.Sfood + RAmount;
            }
            else if (eventdata.pointerDrag.GetComponent<Character>().S)
            {
                tc.Ssupplies = tc.Ssupplies + RAmount;
            }
            else if (eventdata.pointerDrag.GetComponent<Character>().A)
            {
               tc.Sammo = tc.Sammo + RAmount;
            }*/

            rt.ResolveOrder(eventdata.pointerDrag.GetComponent<Character>().resource, RAmount);

        }
    }
    public void ResetAssign()
    {
        assigned = false;
    }



}
