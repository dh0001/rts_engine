using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

struct Tick{
    public List<Action> actions;
}


///<summary>Manages information about the game, its progress, and its operation.</summary>
public class GameManager : MonoBehaviour
{
    public Text Text;
    int buttonPressedCount = 0;

    ///<summary>Contains every unit in the game.</summary>
    List<UnitManager> units = new List<UnitManager>();

    ///<summary>Current ticks in queue.</summary>
    List<Tick> ticks = new List<Tick>();

    ///<summary>How much time between every tick, in milliseconds.</summary>
    const int TICK_RATE = 300;

    ///<summary>The last time the game was updated.</summary>
    int lastUpdate;

    ///<summary>When the game started.</summary>
    int gameStarted;
    
    ///<summary>The time that has elapsed in game.</summary>
    int gameTime;

    ///<summary>Actions created by UI.</summary>
    List<Action> newActions;


    /// <summary>An interface used by the UI/AI/Network to attach actions to units. </summary>
    public void CreateAction(Action action){
        // create action and add to a latest tick
        newActions.Add(action);
    }


    public void CreateActions(List<Action> action){
        // create action and add to a latest tick
    }


    void Start()
    {
        // create units, will be passed a list of units to create, somehow
        List<string> passed = new List<string>();
        passed.Add("axe");

        units = new List<UnitManager>();

        foreach (var p in passed)
        {
            units.Add(new UnitManager(p));
        }

        gameTime = 0;
    }


    ///<summary>Populates the ticks property with what has happened since the last time the game was updated.</summary>
    void GetUpdates()
    {
        // get all ticks except 'last' tick
        for (; lastUpdate < gameTime - TICK_RATE; lastUpdate += TICK_RATE)
        {
            ticks.Add(new Tick());
        }

        //add ui actions to the last tick
        if (lastUpdate < gameTime){
            var t = new  Tick();
            t.actions = newActions;
            newActions = new List<Action>();
            ticks.Add(t);
        }
    }


    ///<summary>Used as the main game loop.</summary>
    void FixedUpdate()
    {
        //bool paused = false;

        // game loop
        GetUpdates();

        if (Input.GetMouseButtonDown(1))
        {
            Vector3 mousePosition = Input.mousePosition;
            buttonPressedCount++;
            Text.text = buttonPressedCount.ToString();
        }

        // update game
        foreach (var tick in ticks)
        {
            // populate actions
            foreach (var action in tick.actions){
                action.TryExecuteAction();
            }

            // elapse units
            foreach(var unit in units){
                unit.Elapse();
            }
        }
    }
}