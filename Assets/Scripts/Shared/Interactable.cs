﻿using UnityEngine;
//TODO check if it is possible to raycast a circle
public class Interactable : MonoBehaviour
{

    //How close the player needs to be to interact with object
    public float radius = 3f;
    //bool isInRange = false;
    bool hasInteracted = false;
    bool focusStarted = false;
    public Transform player;
    public KeyCode keyToInteract = KeyCode.E;

    //Variable to make interaction only available in specific direction like chest from the front
    public Transform interactionTransform;

    public virtual void Interact()
    {
        //This is overriden for each object
        Debug.Log("Interacting..." + transform.name);
    }

    private void Start()
    {

        player = GameObject.FindWithTag("Player").transform;

        if (interactionTransform == null)
        {
            interactionTransform = transform;
        }
    }

    void Update()
    {
        if (hasInteracted == false)
        {
            float distance = Vector3.Distance(player.position, interactionTransform.position);
            if (distance <= radius)
            {
                OnFocus();
                if (Input.GetKeyDown(keyToInteract))
                {
                    hasInteracted = true;
                    Interact();
                }
            }
            else
            {
                focusStarted = false;
            }
        }
    }

    public void OnFocus()
    {
        //Handle interact letter
        if (!focusStarted)
        {
            focusStarted = true;
            Debug.Log("Possible interaction with key " + keyToInteract);
        }
        
        //hasInteracted = false;
        //isInRange = true;
        //player = playerTransform;
    }

    //public void OnDefocused()
    //{
    //    isInRange = false;
    //    player = null;
    //    hasInteracted = false;
    //}

    private void OnDrawGizmosSelected()
    {
        if (interactionTransform == null)
        {
            interactionTransform = transform;
        }
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(interactionTransform.position, radius);


    }

}