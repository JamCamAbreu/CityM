using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework.Input;

namespace CityM {
  public class InputManager {

    public enum playerIndex {
      one,
      two,
      all,
      none // used for ai
    }

    public enum action {
      up,
      down,
      left,
      right,

      select,

      cancel,
      pause,

      action_1,
      action_2,
      action_3,

      debugMode
    }

    // Member Variables
    KeyboardState imCur;
    KeyboardState imPrev;

    // Constructor
    public InputManager() {
      this.imCur = new KeyboardState();
      this.imPrev = new KeyboardState();
    }

    public void InputUpdateCurrent() { this.imCur = Keyboard.GetState(); }
    public void InputPushOld() { this.imPrev = this.imCur; }

    // Key was just pressed
    public bool KeyPressed(Keys key) {
      return (imCur.IsKeyDown(key) && !imPrev.IsKeyDown(key));
    }

    // Key was just released
    public bool KeyReleased(Keys key) {
      return (!imCur.IsKeyDown(key) && imPrev.IsKeyDown(key));
    }

    // Is the key currently being HELD down?
    public bool KeyDown(Keys key) { return imCur.IsKeyDown(key); }

    // Is the key currently not being touched?
    public bool KeyUp(Keys key) { return !imCur.IsKeyDown(key); }


    // Key was just pressed
    public bool ActionPressed(action a, playerIndex p) {

      // ------- PLAYER ONE PRESSED --------
      if (p == playerIndex.one) {
        switch (a) {
          case action.up:
            return KeyPressed(Keys.W);

          case action.left:
            return KeyPressed(Keys.A);

          case action.down:
            return KeyPressed(Keys.S);

          case action.right:
            return KeyPressed(Keys.D);

          case action.select:
            return KeyPressed(Keys.E) || KeyPressed(Keys.Enter) || KeyPressed(Keys.Space);

          case action.cancel:
            return KeyPressed(Keys.Q) || KeyPressed(Keys.Back);

          case action.pause:
            return KeyPressed(Keys.LeftShift);

          case action.action_1:
            return KeyPressed(Keys.B);

          case action.action_2:
            return KeyPressed(Keys.N);

          case action.action_3:
            return KeyPressed(Keys.M);

          case action.debugMode:
            return KeyPressed(Keys.F2);


          default:
            return false;
        } // end switch
      } // end player one input check

      // ------- PLAYER TWO PRESSED --------
      else if (p == playerIndex.two) {

        switch (a) {
          default:
            return false;
        } // end switch
      } // end player two input check

      // If player index wall, return if either were true
      else if (p == playerIndex.all) {
        return ActionPressed(a, playerIndex.one) || ActionPressed(a, playerIndex.two);
      }
      else
        return false;
    }







  } // end class definition
} // end namespace
