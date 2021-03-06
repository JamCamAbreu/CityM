﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;

namespace CityM {
  public class StateManager {


    // ------------- MEMBER VARIABLES ------------------------
    // State count for debugging
    private int stateCount;
    public bool debugMode;

    // Flag for clearing all states (must be done last)
    bool clearAllStates;

    // List of states, we will loop over these:
    public List<State> states = new List<State>();
    public List<State> statesToCreate = new List<State>();

    // Shared by all:
    static KeyboardState input;

    // References for easy access:
    public CityM game;
    public SpriteBatch sb;
    public Random random;
    public S_AudioEngine audioEngine;
    public InputManager im;



    // -------------- CONSTRUCTOR: ---------------------------
    public StateManager(CityM game) {
      this.game = game;
      //this.km = new KeyboardManager();
      this.random = new Random();
      this.debugMode = false;
      this.clearAllStates = false;


      // Add the ** FIRST ** game states here:

      audioEngine = new S_AudioEngine(this, 0, 0);
      this.AddState(audioEngine, 0);

      State mainMenu = new S_MainMenu(this, 0, 0);
      this.AddState(mainMenu, 0);
      this.stateCount = 2;
    }





    // ---------------- UPDATE -------------------------------
    public void Update(GameTime gameTime) {

      // Update the keyboard for BEGINNING of updates:
      im.InputUpdateCurrent();
      var num = states.Count - 1;

      // Loop through all states and update them!:
      State s;
      int delayTimer = 0;
      while (num > -1) {

        // Start with topmost state:
        if (delayTimer <= 0) {
          s = states[num];

          // ** UPDATE ALL STATES **
          // Only update if State is 'active' and not flagged for deletion:
          if (s.active && !s.flagForDeletion) { s.Update(gameTime, input); }


          // a 'delayTimer' allows states to push short delays to essentially mini-pause the state stack
          if (s.sendDelay > 0) {
            delayTimer += s.sendDelay;
            s.sendDelay = 0; // reset send delay from object (notification of it was received)
          }

          // State is flagged for deletion, remove it now:
          if (s.flagForDeletion) { RemoveState(s); }

        }

        --num;
      } // end while

      // decrement timer
      delayTimer--;


      // Clear all states flag
      if (clearAllStates) {
        states.Clear();
        clearAllStates = false; // reset flag
      }

      // Create any new states
      // Loop through states to create, creating and linking them to our states list
      foreach (State newState in statesToCreate.ToList()) {
        states.Add(newState);
        statesToCreate.Remove(newState);
      }

      // Log changes in state count
      if (states.Count != stateCount) {
        Console.WriteLine("Current State Count: " + states.Count + "\n");
        stateCount = states.Count;
      }

      // Debug mode activation:
      if (im.ActionPressed(InputManager.action.debugMode, InputManager.playerIndex.one)) {
        if (this.debugMode == false) { this.debugMode = true; Console.WriteLine("turned debugMode on"); }
        else { this.debugMode = false; Console.WriteLine("turned debugMode off"); }
      }

      // Update New becomes Old states:
      im.InputPushOld();
    } // end UPDATE







    // ---------------- DRAW ---------------------------------
    public void Draw(GameTime gameTime) {

      // Start at bottom of state list, draw bottom up
      SpriteBatch sb = this.game.spriteBatch;
      foreach (State s in states) {
        // If visible, draw:
        if (s.visible) { s.Draw(gameTime); }
      } // end foreach


      // TODO TODO TODO --------------------------------------------- << TODO

      // Debug Mode (draw in seperate foreach loop, on top of other states):
      if (debugMode) {

        /*
        sb.Begin();

        int line = 0;
        int lineHeight = 16;
        string str = "STATES";
        Vector2 debugTextPos = new Vector2(400, line * lineHeight);
        sb.DrawString(this.game.ft_debugMedium, str, debugTextPos, Color.Black);
        line++;


        foreach (State s in states) {
          str = s.GetType().ToString();
          debugTextPos.Y = line * lineHeight;
          sb.DrawString(this.game.ft_debugSmall, str, debugTextPos, Color.White);
          line++;

        }
        sb.End();
      */
      }

    } // end DRAW



      // TODO
      public void AddState(State state, int playerIndex) {
        states.Add(state);
      }


      // TODO
      public void RemoveState(State state) {
        states.Remove(state);
      }


      public void AddStateQueue(State s) {
        statesToCreate.Add(s);
      }

      public void clearStates() {
        clearAllStates = true;
      }







  } // end class definition
} // end namespace
