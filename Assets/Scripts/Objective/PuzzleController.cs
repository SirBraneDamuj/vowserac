using UnityEngine;
using System.Collections;

public class PuzzleController : MonoBehaviour {

  public Puzzle puzzle;
  public string display;
  
  private static PuzzleController instance;

	// Use this for initialization
	void Start () {
    instance = this;
    puzzle = new Puzzle();
    display = puzzle.DisplayPuzzle();
	}
	
	// Update is called once per frame
	void Update () {
    
	}
  
  void OnGUI() {
    GUI.Box(new Rect(200,10,600,25), display);
  }
  
  private void ScoreLetterImpl(string letter) {
    puzzle.RevealLetter(letter);
    display = puzzle.DisplayPuzzle();
  }
  
  public static void ScoreLetter(string letter) {
    instance.ScoreLetterImpl(letter);
  }
}
