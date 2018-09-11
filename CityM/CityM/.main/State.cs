using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace CityM {
  public abstract class State {

    public StateManager parentManager;
    public int sendDelay;
    //public KeyboardManager.playerIndex player;
    //public KeyboardManager km;

    public State state;

    public string name; // when debug mode is active, what is this state called
    public bool active; // whether or not step function is run
    public bool visible; // whether or not draw function is run
    public bool flagForDeletion; // at end of Update, delete me (sent to manager)

    // The 'state' will be drawn to the right and below this point
    public float xPos;
    public float yPos;


    // CONSTRUCTOR:
    public State(StateManager creator, float xPos, float yPos) {

      // Passed in:
      this.parentManager = creator;
      this.state = this;
      this.xPos = xPos;
      this.yPos = yPos;

      // Default:
      this.active = true;
      this.visible = true;
      this.flagForDeletion = false;
      this.sendDelay = 0;

      // Makes referencing the keyboard manager easier
      //this.km = parentManager.km;
    }

    // VIRTUAL Functions (will be overridden)
    public virtual void Update(GameTime gameTime, KeyboardState ks) { }
    public virtual void Draw(GameTime gameTime) { }



    // Listen for a pause and do so at this time
    /*
    public void ListenPause() {
      // Pausing while in a board state:
      if (km.ActionPressed(KeyboardManager.action.pause, KeyboardManager.playerIndex.one)) {
        S_Pause pauseMenu = new S_Pause(parentManager, 0, 0, KeyboardManager.playerIndex.one);
        parentManager.AddStateQueue(pauseMenu);
        Console.WriteLine("Player 1 paused the game");
      }
      else if (km.ActionPressed(KeyboardManager.action.pause, KeyboardManager.playerIndex.two)) {
        S_Pause pauseMenu = new S_Pause(parentManager, 0, 0, KeyboardManager.playerIndex.two);
        parentManager.AddStateQueue(pauseMenu);
        Console.WriteLine("Player 2 paused the game");
      }
    }
    */








  } // end State class
}
