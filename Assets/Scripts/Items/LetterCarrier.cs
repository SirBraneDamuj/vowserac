using UnityEngine;
using System.Collections;

public class LetterCarrier : MonoBehaviour {

  private string letter = "";
  public GameObject letterPrefab;
  
  void onLetterPickup(string newLetter) {
    if(letter != "") {
      Vector3 pos = transform.position;
      GameObject lgo = Instantiate(letterPrefab, pos, transform.rotation) as GameObject;
      Letter l = lgo.GetComponent<Letter>();
      l.Disable(this.letter, transform.position);
    }
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
