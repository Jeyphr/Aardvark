using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

interface IInteractable
{
    public void Interact();
}

public class gs_interaction : MonoBehaviour
{
    [Header("Statistics")]
    [SerializeField] public Transform   iSource;
    [SerializeField] public float       iRange    = 1;
    [SerializeField] public float       iTime     = 3;

    // Update is called once per frame
    void Update()
    {
        Ray r = new Ray(iSource.position, iSource.forward);
        if(Physics.Raycast(r, out RaycastHit hitInfo, iRange))
        {
            if (hitInfo.collider.gameObject.TryGetComponent(out IInteractable interactOBJ))
            {
                if (Input.GetKeyDown(KeyCode.F)) StartCoroutine(Action(interactOBJ));
                if (Input.GetKeyUp(KeyCode.F)) StopCoroutine(Action(interactOBJ));
                
            }
        }
    }

    IEnumerator Action(IInteractable interactOBJ)
    {
        yield return new WaitForSeconds(iTime);
        interactOBJ.Interact();
    }
}
