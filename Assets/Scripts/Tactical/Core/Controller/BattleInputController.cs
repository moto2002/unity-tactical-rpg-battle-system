using UnityEngine;
using UnityEngine.InputNew;
using UnityEngine.Assertions;
using System;
using Tactical.Grid.Model;
using Tactical.Core.EventArgs;

namespace Tactical.Core.Controller {

	public class BattleInputController : MonoBehaviour {

		public static event EventHandler<InfoEventArgs<Point>> MoveEvent;
		public static event EventHandler<InfoEventArgs<int>> ActionEvent;

		private PlayerInput playerInput;
		private BattleControls battleControls;
		private Repeater horizontal;
		private Repeater vertical;
		private readonly string[] actionButtons = { "Confirm" };

		private void Start () {
			playerInput = GetComponent<PlayerInput>();
			battleControls = playerInput.GetActions<BattleControls>();
			horizontal = new Repeater(battleControls.moveX);
			vertical = new Repeater(battleControls.moveY);

			Assert.IsNotNull(playerInput, "playerInput required");
			Assert.IsNotNull(battleControls, "battleControls required");
		}

		private void Update () {
			int x = horizontal.Update();
			int y = vertical.Update();

			// Handle movement events.
			if (x != 0 || y != 0) {
				if (MoveEvent != null) {
					MoveEvent(this, new InfoEventArgs<Point>(new Point(x, y)));
				}
			}

			// Handle action events.
			for (int i = 0; i < actionButtons.Length; ++i) {
				var button = battleControls[actionButtons[i]] as ButtonInputControl;
				if (button != null && button.wasJustPressed) {
					if (ActionEvent != null) {
						ActionEvent(this, new InfoEventArgs<int>(i));
					}
				}
			}
		}

	}

	class Repeater {

		private const float threshold = 0.3f;
		private const float rate = 0.15f;
		private float next;
		private bool hold;
		private readonly AxisInputControl axis;

		public Repeater (AxisInputControl axis) {
			this.axis = axis;
		}

		public int Update () {
			int retValue = 0;
			int value = Mathf.RoundToInt(axis.rawValue);

			if (value != 0) {
				if (Time.time > next) {
					retValue = value;
					next = Time.time + (hold ? rate : threshold);
					hold = true;
				}
			} else {
				hold = false;
				next = 0;
			}

			return retValue;
		}
	}

}
