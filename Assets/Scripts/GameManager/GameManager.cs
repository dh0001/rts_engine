using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

struct Tick
{
    public List<Action> actions;
}


///<summary>Manages information about the game, its progress, and its operation.</summary>
public class GameManager : MonoBehaviour
{
    /// <summary>Contains a reference to the ground.</summary>
    public GameObject Ground;

    ///<summary>Contains every unit in the game.</summary>
    List<UnitManager> units = new List<UnitManager>();

    ///<summary>Current ticks in queue.</summary>
    List<Tick> ticks = new List<Tick>();

    // ///<summary>How much time between every tick, in milliseconds.</summary>
    // const long TICK_RATE = 30;

    ///<summary>The last time the game was updated.</summary>
    long lastUpdate;

    ///<summary>When the game started.</summary>
    long gameStarted;
    
    ///<summary>The time that has elapsed in game.</summary>
    long gameTime;

    ///<summary>Actions created by UI.</summary>
    List<Action> newActions = new List<Action>();

    /// <summary>References the UIManager for the game.</summary>
    UIManager UIManager;


    public GameManager()
    {
        UIManager = new UIManager(this);
    }

    /// <summary>An interface used by the UI/AI/Network to add an action. </summary>
    public void CreateAction(Action action){
        newActions.Add(action);
    }

    /// <summary>An interface used by the UI/AI/Network to add actions. </summary>
    public void CreateActions(List<Action> actions){
        newActions.AddRange(actions);
    }


    void Awake()
    {
        // create units, will be passed a list of units to create, somehow
        List<string> passed = new List<string>();
        passed.Add("axe");
        //passed.Add("something");

        units = new List<UnitManager>();

        foreach (var p in passed)
        {
            units.Add(new UnitManager(p, UIManager));
        }

        // Setting the UI Manager for the ground
        Ground.GetComponent<GetClick>().AttachUIManager(UIManager);

        gameStarted = System.DateTimeOffset.Now.ToUnixTimeMilliseconds();
        gameTime = 0;
    }


    ///<summary>Populates the ticks property with what has happened since the last time the game was updated.</summary>
    /*  */
    void GetUpdates()
    {
        // add skipped ticks
        // for (; lastUpdate < gameTime - TICK_RATE * 2; lastUpdate += TICK_RATE)
        // {
        //     ticks.Add(new Tick());
        // }

        // add ui actions to the last tick
       // if (lastUpdate < gameTime - TICK_RATE){
            //lastUpdate += TICK_RATE;
            var t = new Tick();
            t.actions = newActions;
            newActions = new List<Action>();
            ticks.Add(t);
        //}

        //gameTime = System.DateTimeOffset.Now.ToUnixTimeMilliseconds() - gameStarted;
    }


    ///<summary>Used as the main game loop.</summary>
    void FixedUpdate()
    {
        //bool paused = false;

        // game loop
        GetUpdates();

        // update game
        foreach (var tick in ticks)
        {
            // populate actions
            if (tick.actions != null)
            {
                foreach (var action in tick.actions)
                {

                    action.TryExecuteAction();
                }
            }
            // elapse units
            foreach (var unit in units)
            {
                unit.Elapse();
            }
        }

        // reset ticks
        ticks = new List<Tick>();
    }
}