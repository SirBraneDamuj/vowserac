using UnityEngine;
using System.Collections;

public class Letter : MonoBehaviour {

  public string letter;
  
  //disabled when dropped by player
  public bool disabled = false;
  private float timer = 0.0f;
  private Vector3 originalLocation;
  
  private float disabledTime = 2.0f;
  private const float travelDistance = 2.0f;
  private const float blinkSpeed = 0.15f;
  
  void Update() {
    if(disabled) {
      timer += Time.deltaTime;
      float delta = originalLocation.y + Mathf.Sin((timer / disabledTime) * Mathf.PI);
      Vector3 pos = transform.position;
      pos.y = delta;
      transform.position = pos;
      if(timer >= disabledTime) {
        timer = 0.0f;
        disabled = false;
      }
      
    }
  }
  
  public void Disable(string l, Vector3 pos) {
    disabled = true;
    timer = 0.0f;
    letter = l;
    originalLocation = pos;
    StartCoroutine(Blink());
  }
  
  IEnumerator Blink() {
    while(disabled) {
      renderer.enabled = false;
      yield return new WaitForSeconds(blinkSpeed);
      renderer.enabled = true;
      yield return new WaitForSeconds(blinkSpeed);
    }
  }

	void OnTriggerEnter2D(Collider2D other) {
    if(!disabled && other.tag == "Player") {
      other.SendMessage("onLetterPickup", letter);
      Destroy(gameObject);
    }
  }
}
