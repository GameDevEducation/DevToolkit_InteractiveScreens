using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InputRelaySource : MonoBehaviour
{
    [SerializeField] LayerMask RaycastMask = ~0;
    [SerializeField] float RaycastDistance = 15f;
    [SerializeField] UnityEvent<Vector2> OnCursorInput = new UnityEvent<Vector2>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // retrieve a ray based on the mouse location
        Ray mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);

        // raycast to find what we have hit
        RaycastHit hitResult;
        if (Physics.Raycast(mouseRay, out hitResult, RaycastDistance, RaycastMask, QueryTriggerInteraction.Ignore))
        {
            // ignore if not us
            if (hitResult.collider.gameObject != gameObject)
                return;

            OnCursorInput.Invoke(hitResult.textureCoord);
        }
    }
}
