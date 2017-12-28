using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
	Jason
	12/27/2017
 */

[RequireComponent(typeof(Animator))]
public class Lever : MonoBehaviour {

	[Header("User Input")]
	public KeyCode leverKey;
	[Header("References")]
	public Animator leverAnim;

	// Change this string to whatever your players tag is.
	[Header("Player Detection")]
	public string playerTag;

	
	// Change this string to whatever your mecanim animator toggle parameter is called.
	[Header("Animator Properties")]
	public string leverToggleAnimName = "LeverToggle";

	// Handles player activation.
	private bool _canActivate = false;
	// Handles current state of lever.
	private bool _leverState = false;

	// Can only activate the lever when within trigger bounds.
	private void OnTriggerEnter(Collider other) {
		if(other.CompareTag(playerTag)) {
			_canActivate = true;
		}
	}

	// Use this for initialization
	private void Start () {
		if(!leverAnim)
			leverAnim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	private void Update () {
		// Toggle lever state when a key is pressed and when the player is within trigger bounds.
		if(Input.GetKeyDown(leverKey) && _canActivate) {
			ToggleLever();
		}
	}
	
	// Handles the lever toggling.
	public void ToggleLever() {
		leverAnim.SetTrigger(leverToggleAnimName);
		SetLeverState(!GetLeverState());

		// Remove this debug for production use.
		Debug.Log("Lever State:"+GetLeverState());
	}

	// Returns the state of the lever as a boolean.
	public bool GetLeverState() {
		return _leverState;
	}

	// Sets the state of the lever as a boolean.
	private void SetLeverState(bool val) {
		_leverState = val;
	}



}
