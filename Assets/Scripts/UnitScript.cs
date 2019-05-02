using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UnitScript : MonoBehaviour, IPointerClickHandler
{
    private UnitManager reference = null;
    private UIManager UIManager;

    /// <summary>
    /// Sets the reference to the UnitManager corresponding to the current gameObject this script is attached to.  MUST be set after instantiated.
    /// </summary>
    /// <param name="unit"></param>
    public void SetReferences(UnitManager unit, UIManager uiManager)
    {
        reference = unit;
        UIManager = uiManager;
    }

    /// <summary>
    /// Communicates with UI manager that this object has been clicked
    /// </summary>
    public void OnPointerClick(PointerEventData eventData)
    {
        UIManager.HandlePointerClick(eventData);
    }

    /// <summary>
    /// Returns a reference to the UnitManager corresponding to the current gameObject this script is attached to.
    /// </summary>
    /// <exception cref=""></exception>
    /// <returns></returns>
    public UnitManager GetReference()
    {
        return reference;
    }

    
}
