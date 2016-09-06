using UnityEngine;
using UnityEngine.InputNew;
using UnityEngine.Assertions;
using System;
using System.Collections.Generic;
using Tactical.Grid.Model;
using Tactical.Core.Enums;
using Tactical.Core.EventArgs;

namespace Tactical.Core.Controller {

	public class BattleInputController : MonoBehaviour {

		public static event EventHandler<InfoEventArgs<Point>> MoveEvent;
		public static event EventHandler<InfoEventArgs<BattleInputs>> ActionEvent;
		public PlayerInput playerInput;

		private ExplorationControls explorationControls;
		private BattleControls battleControls;
		private Repeater horizontal;
		private Repeater vertical;
		private Dictionary<BattleInputs, ButtonInputControl> actionButtons = new Dictionary<BattleInputs, ButtonInputControl> ();

		private void Start () {
			explorationControls = playerInput.GetActions<ExplorationControls>();
			battleControls = playerInput.GetActions<BattleControls>();

			// Create the repeaters for the axis.
			horizontal = new Repeater(battleControls.moveX);
			vertical = new Repeater(battleControls.moveY);

			// Create the action buttons.
			actionButtons.Add(BattleInputs.Confirm, battleControls.confirm);
			actionButtons.Add(BattleInputs.Cancel, battleControls.cancel);
			actionButtons.Add(BattleInputs.RotateCameraLeft, explorationControls.rotateCameraLeft);
			actionButtons.Add(BattleInputs.RotateCameraRight, explorationControls.rotateCameraRight);

			Assert.IsNotNull(explorationControls, "explorationControls required");
			Assert.IsNotNull(battleControls, "battleControls required");
		}

		private void OnValidate () {
			Assert.IsNotNull(playerInput, "playerInput required");
		}

		private void Update () {
			HandleMove();
			HandleAction();
		}

		private void HandleMove () {
			int x = horizontal.Update();
			int y = vertical.Update();

			// Handle movement inputs.
			if (x != 0 || y != 0) {
				if (MoveEvent != null) {
					MoveEvent(this, new InfoEventArgs<Point>(new Point(x, y)));
				}
			}
		}

		private void HandleAction () {
			// Handle action inputs.
			foreach (var item in actionButtons) {
				if (item.Value.wasJustPressed) {
					if (ActionEvent != null) {
						Debug.Log(string.Format("Sending ActionEvent: {0}", item.Value.name));
						ActionEvent(this, new InfoEventArgs<BattleInputs>(item.Key));
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
