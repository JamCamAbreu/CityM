using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace CityM {
  public abstract class State {

    //public GameStateManager parentManager;
    //public KeyboardManager.playerIndex player;
    //public KeyboardManager km;
    //public int sendDelay;

    public State state;

    public string name; // when debug mode is active, what is this state called
    public bool active; // whether or not step function is run
    public bool visible; // whether or not draw function is run
    public bool flagForDeletion; // at end of Update, delete me (sent to manager)

    // The 'state' will be drawn to the right and below this point
    public float xPos;
    public float yPos;


  } // end State class
}
