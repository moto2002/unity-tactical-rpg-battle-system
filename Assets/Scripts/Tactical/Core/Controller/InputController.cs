using UnityEngine;
using UnityEngine.InputNew;
using UnityEngine.Assertions;
using System;
using System.Collections;
using Tactical.Grid.Model;
using Tactical.Core.EventArgs;

namespace Tactical.Core.Controller {

	public class InputController : MonoBehaviour {

		public static event EventHandler<InfoEventArgs<Vector2>> MoveEvent;
		public static event EventHandler<InfoEventArgs<float>> JumpEvent;

		private PlayerInput playerInput;
		private ExplorationControls explorationControls;

		private void Start () {
			playerInput = GetComponent<PlayerInput>();
			explorationControls = playerInput.GetActions<ExplorationControls>();

			Assert.IsNotNull(playerInput, "playerInput required");
			Assert.IsNotNull(explorationControls, "explorationControls required");
		}

		private void Update () {
			if (explorationControls != null) {
				if (explorationControls.move.vector2 != Vector2.zero) {
					if (MoveEvent != null) {
						MoveEvent(this, new InfoEventArgs<Vector2>(explorationControls.move.vector2));
					}
				}
				if (explorationControls.jump.isHeld) {
					if (JumpEvent != null) {
						JumpEvent(this, new InfoEventArgs<float>(explorationControls.jump.rawValue));
					}
				}
			}
		}

		// public static event EventHandler<InfoEventArgs<Point>> moveEvent;
		// public static event EventHandler<InfoEventArgs<int>> fireEvent;

		// private Repeater _hor = new Repeater("Horizontal");
		// private Repeater _ver = new Repeater("Vertical");
		// private string[] _buttons = new string[] {"Fire1", "Fire2", "Fire3"};

		// private void Update () {
		// 	int x = _hor.Update();
		// 	int y = _ver.Update();

		// 	if (x != 0 || y != 0) {
		// 		if (moveEvent != null) {
		// 			moveEvent(this, new InfoEventArgs<Point>(new Point(x, y)));
		// 		}
		// 	}

		// 	for (int i = 0; i < 3; ++i) {
		// 		if (Input.GetButtonUp(_buttons[i])) {
		// 			if (fireEvent != null) {
		// 				fireEvent(this, new InfoEventArgs<int>(i));
		// 			}
		// 		}
		// 	}
		// }

	}

	class Repeater {

		private const float threshold = 0.3f;
		private const float rate = 0.15f;
		private float _next;
		private bool _hold;
		private string _axis;

		public Repeater (string axisName) {
			_axis = axisName;
		}

		public int Update () {
			int retValue = 0;
			int value = Mathf.RoundToInt( Input.GetAxisRaw(_axis) );

			if (value != 0) {
				if (Time.time > _next) {
					retValue = value;
					_next = Time.time + (_hold ? rate : threshold);
					_hold = true;
				}
			} else {
				_hold = false;
				_next = 0;
			}

			return retValue;
		}
	}

}
