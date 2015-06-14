// Copyright 2014 Google Inc. All rights reserved.
//a
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Collider))]
public class Teleport : MonoBehaviour
{
	private Vector3 startingPosition;
	public static float moveSize = 0.1f;
	
	void Start ()
	{
		startingPosition = transform.localPosition;
		SetGazedAt (false);

		Debug.Log (">>>>>>>>>>>>>>>>>> HelloWorld <<<<<<<<<<<<<<<<<<<<<");
	}

	void Update ()
	{
		string k = CheckKey ();
		if (k != "") {
			Debug.Log (">>>>>>>>>>>>>>>>>> update <<<<<<<<<<<<<<<<<<<<< " + k);
			MoveTo(k);
		}
	}

	public string CheckKey ()
	{
		if (Input.GetKey (KeyCode.UpArrow)) {
			return "up";
		}
		if (Input.GetKey (KeyCode.DownArrow)) {
			return "down";
		}
		if (Input.GetKey (KeyCode.RightArrow)) {
			return "right";
		}
		if (Input.GetKey (KeyCode.LeftArrow)) {
			return "left";
		}
		return "";
	}

	public void MoveTo (string op)
	{
		if (op == "up") {
			transform.Translate (0, 0, moveSize);
		}
		if (op == "down") {
			transform.Translate (0, 0, moveSize * -1);
		}
		if (op == "right") {
			transform.Translate (moveSize, 0, 0);
		}
		if (op == "left") {
			transform.Translate (moveSize * -1, 0, 0);
		}
	}

	public void SetGazedAt (bool gazedAt)
	{
		GetComponent<Renderer> ().material.color = gazedAt ? Color.green : Color.red;
	}

	public void Reset ()
	{
		transform.localPosition = startingPosition;
	}

	public void ToggleVRMode ()
	{
		Cardboard.SDK.VRModeEnabled = !Cardboard.SDK.VRModeEnabled;
	}

	public void TeleportRandomly ()
	{
		Vector3 direction = Random.onUnitSphere;
		direction.y = Mathf.Clamp (direction.y, 0.5f, 1f);
		float distance = 2 * Random.value + 1.5f;
		transform.localPosition = direction * distance;
	}
}
