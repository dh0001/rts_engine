using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GetClick : MonoBehaviour, IPointerClickHandler
{
    private UIManager uiManager;

    /// <summary>
    /// Attaches this script to the given UI manager.
    /// </summary>
    /// <param name="manager"></param>
    public void AttachUIManager(UIManager manager)
    {
        uiManager = manager;
    }

    /// <summary>
    /// Communicates with UI manager that this object has been clicked
    /// </summary>
    public void OnPointerClick(PointerEventData eventData)
    {
        uiManager.HandlePointerClick(eventData);
    }
}
