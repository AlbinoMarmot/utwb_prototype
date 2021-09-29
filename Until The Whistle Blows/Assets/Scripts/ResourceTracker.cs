using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceTracker : MonoBehaviour
{
    // Start is called before the first frame update
    public enum ResourceType
    {
        Food = 0,
        Supplies,
        Medicine,
        Morale
    }

    static public int[] armyResources;
    [SerializeField] UnityEngine.UI.Text[] resourceIndicators;

    [SerializeField] UnityEngine.UI.Text DescriptiveText;

    //All game objects that should only appear when an event is pending should go here
    [SerializeField] GameObject[] eventStuff;
    
    protected class EventOption
    {
        ResourceType[] resource;
        int[] value;

        public EventOption()
        {
            resource = new ResourceType[2];
            value = new int[2];

            resource[0] = (ResourceType)(Random.Range(0, 4));
            do
            {
                resource[1] = (ResourceType)(Random.Range(0, 4));
            }
            while (resource[0] == resource[1]);

            value[0] = Mathf.CeilToInt((float)(armyResources[(int)resource[0]]) * Random.Range(0.2f, 0.7f));
            value[1] = Mathf.CeilToInt((float)(armyResources[(int)resource[1]]) * Random.Range(0.2f, 0.7f)) * -1;

        }

        public int getResourceValue(int i)
        {
            return value[i];
        }

        public ResourceType getResource(int i)
        {
            return resource[i];
        }

        public string getResourceName(int i)
        {
            return resource[i].ToString();
        }
    }

    private EventOption[] options;

    //will be true whenever there is an event that the player needs to deal with before progressing
    public bool eventPending = false;

    void Start()
    {
        armyResources = new int[4];

        for(int i = 0; i < 4; i++)
        {
            armyResources[i] = 50;
            resourceIndicators[i].text = ((ResourceType)i).ToString() + ": " + armyResources[i].ToString();
        }


        CreateResourceEvent();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //creates a new event
    public void CreateResourceEvent()
    {
        if(!eventPending)
        {
            options = new EventOption[2];

            options[0] = new EventOption();
            options[1] = new EventOption();

            foreach(GameObject g in eventStuff)
            {
                g.SetActive(true);
            }

            DescriptiveText.text = "Option 1: Gain " + options[0].getResourceValue(0).ToString() + ' ' + options[0].getResourceName(0) + " and lose " + (options[0].getResourceValue(1) * -1).ToString() + ' ' + options[0].getResourceName(1) + '.' + '\n' + "Option 2: Gain " + options[1].getResourceValue(0).ToString() + ' ' + options[1].getResourceName(0) + " and lose " + (options[1].getResourceValue(1) * -1).ToString() + ' ' + options[1].getResourceName(1) + '.';

            eventPending = true;
        }
        else
        {
            Debug.Log("You can't make another event happen without completing the last one.");
        }
    }

    public void ResolveResourceEvent(int option)
    {
        if(eventPending)
        {
            armyResources[(int)options[option].getResource(0)] += options[option].getResourceValue(0);
            armyResources[(int)options[option].getResource(1)] += options[option].getResourceValue(1);

            if (armyResources[(int)options[option].getResource(1)] < 0)
            {
                DescriptiveText.text = "You have run out of " + options[option].getResourceName(1) + ". The battle is now over.";
            }
            else
            {
                resourceIndicators[(int)options[option].getResource(0)].text = options[option].getResourceName(0) + armyResources[(int)options[option].getResource(0)].ToString();
                resourceIndicators[(int)options[option].getResource(1)].text = options[option].getResourceName(1) + armyResources[(int)options[option].getResource(1)].ToString();

                foreach(GameObject g in eventStuff)
                {
                    g.SetActive(false);
                }

                eventPending = false;
            }
        }
        else
        {
            Debug.Log("How did you do that?");
        }
    }
}
