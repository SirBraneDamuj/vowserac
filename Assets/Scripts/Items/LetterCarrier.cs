using UnityEngine;
using System.Collections;

public class LetterCarrier : MonoBehaviour {

  private string letter = "";
  
  void onLetterPickup(string newLetter) {
    this.letter = newLetter;
  }
  
  void OnTriggerEnter2D(Collider2D other) {
    if(this.letter != "" && other.tag == "ScoreArea") {
      PuzzleController.ScoreLetter(this.letter);
      this.letter = "";
    }
  }
  
  void OnGUI() {
    if(letter != "") {
      GUI.Box(new Rect(10,10,25,25), letter);
    }
  }
	
}
