using UnityEngine;
using System.Collections;

public class Respawn : MonoBehaviour {

  public Vector3 respawnPoint;

	// Use this for initialization
	void Start () {
    respawnPoint = transform.position;
	}
  
  void Reset() {
    this.transform.position = respawnPoint;
  }
}
