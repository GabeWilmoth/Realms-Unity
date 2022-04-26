using UnityEngine;

public class ObjectClicker : MonoBehaviour
{
    private int treeLayer;
    private string previousGameObjectClicked = "";
    private int objectClickCounter = 1;
    private int totalClicks = 3;
    private void Start()
    {
        treeLayer = LayerMask.NameToLayer("Tree"); //TODO: Build a Generic NameToLayer Mask so we can use this Clicker for multiple "Layers". This should take an Object Mapping of Layers-to-Clicks-To-Remove...
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, 100f))
            {
                if (hit.transform != null && hit.transform.gameObject.layer == treeLayer)
                {
                    string currentGameObjectClicked = PrintName(hit.transform.gameObject);

                    if(currentGameObjectClicked == previousGameObjectClicked) {
                        objectClickCounter++;
                    } else {
                        objectClickCounter = 1;
                        previousGameObjectClicked = currentGameObjectClicked;
                    }

                    if(objectClickCounter == totalClicks) {
                        hit.transform.gameObject.SetActive(false);
                    }
                }
            }
        }
    }

    private string PrintName(GameObject go)
    {
        return go.name;
    }
}
