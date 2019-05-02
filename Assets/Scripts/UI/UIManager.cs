using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIManager
{
    public Camera CameraObject;
    public UnitManager SelectedUnit = null;
    private GameManager gameManager;

    public UIManager(GameManager manager)
    {
        gameManager = manager;
    }

    /// <summary>
    /// Handles mouse button clicks for UI
    /// </summary>
    /// <param name="eventData"></param>
    public void HandlePointerClick(PointerEventData clickEvent)
    {
        RaycastResult rcResult = clickEvent.pointerCurrentRaycast;

        if (rcResult.isValid) // check if the raycast hit a gameObject
        {
            if (clickEvent.button == PointerEventData.InputButton.Left)
            {
                var component = rcResult.gameObject.GetComponent<UnitScript>();
                if (SelectedUnit == null && component != null)
                {
                    SelectedUnit = component.GetReference();
                }
            }
            else if (clickEvent.button == PointerEventData.InputButton.Right)
            {
                if (SelectedUnit != null)
                {
                    Vector3 clickedPosition = rcResult.worldPosition;
                    gameManager.CreateAction(new MoveAction(SelectedUnit, clickedPosition));
                }
            }
            // mouse button click
            else
            {
                // TODO: Do something
            }
        }
    }

    private void Update()
    {
    }


}
