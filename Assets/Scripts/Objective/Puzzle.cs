using UnityEngine;
using System;
using System.Collections;

public class Puzzle {

  public string solution;
  public enum LetterState {
    SOLVED,
    PUNCTUATION,
    SPACE,
    UNSOLVED
  };
  public LetterState[] puzzleState;

  public Puzzle() : this("THIS TEST PUZZLE ISN'T VERY GOOD") {}
  
  public Puzzle(string phrase) {
    this.solution = phrase.ToUpper();
    this.puzzleState = new LetterState[this.solution.Length];
    for(int i=0; i<this.solution.Length; i++) {
      char ch = this.solution[i];
      LetterState st = LetterState.UNSOLVED;
      if(Char.IsPunctuation(ch)) {
        st = LetterState.PUNCTUATION;
      } else if(Char.IsWhiteSpace(ch)) {
        st = LetterState.SPACE;
      }
      this.puzzleState[i] = st;
    }
  }
  
  public void RevealLetter(string letter) {
    for(int i=0; i<this.solution.Length; i++) {
      char ch = this.solution[i];
      if(ch.ToString().ToUpper() == letter.ToUpper()) {
        this.puzzleState[i] = LetterState.SOLVED;
      }
    }
  }
  
  public string DisplayPuzzle() {
    string result = "";
    for(int i=0; i<this.solution.Length; i++) {
      LetterState st = this.puzzleState[i];
      if(st == LetterState.SPACE) {
        result += " | ";
      } else if(st == LetterState.UNSOLVED) {
        result += " _ ";
      } else {
        result += " " + this.solution[i] + " ";
      }
    }
    return result;
  }
}