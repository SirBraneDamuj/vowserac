using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {

  public Vector3 damageForce = new Vector3(25.0f, 5.0f, 0.0f);
  public float paralyzeTime = 0.3f;
  private Movement movement;
  
  void Start() {
    movement = GetComponent<Movement>();
  }

	void onDamage() {
    movement.AddVelocity(damageForce);
    movement.Paralyze(paralyzeTime);
  }
}
