using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;
using Valve.VR;


public class SpawnTest : MonoBehaviour
{
    public Hand hand;
    public GameObject crimeScene;
    public GameObject rewind;
    public LinearMapping linearMap;
    public SteamVR_TrackedController trackedController;

    bool dirty = false;

    void SpawnIt()
    {
        Debug.Log("spawn it");
        rewind = Instantiate(rewind) as GameObject;
        linearMap = rewind.GetComponentInChildren<LinearMapping>();
        crimeScene = Instantiate(crimeScene) as GameObject;
        crimeScene.GetComponent<LinearAnimator>().linearMapping = linearMap;
    }
    private void Update()
    {
        if(trackedController.padPressed)
        {
            Debug.Log("dirty false");
            dirty = false;
        }

        if(hand.GetStandardInteractionButtonDown())
        {
            if(!dirty)
            {
                SpawnIt();
                hand.AttachObject(rewind);
                dirty = true;
                return;
            }

            if(dirty)
            {
                hand.HoverUnlock(rewind.GetComponent<Interactable>());
                hand.DetachObject(hand.currentAttachedObject);
            }

            
        }


    }
}
