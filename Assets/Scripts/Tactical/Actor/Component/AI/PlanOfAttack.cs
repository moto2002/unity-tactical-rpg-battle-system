using UnityEngine;
using Tactical.Core.Enums;
using Tactical.Grid.Model;

namespace Tactical.Actor.Component.AI {

	public class PlanOfAttack {

		public Ability ability;
		public Targets target;
		public Point moveLocation;
		public Point fireLocation;
		public Directions attackDirection;

	}

}
