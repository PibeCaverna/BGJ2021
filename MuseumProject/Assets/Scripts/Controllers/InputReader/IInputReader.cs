using UnityEngine;

namespace InputReader
{
	public interface IInputReader
	{
		Vector2 Stick { get; }
		
		bool OnInteract { get; }
		bool Interacting { get; }
        bool OffInteract { get; }

        bool OnJump { get; }
		bool Jumping { get; }
        bool OffJump { get; }

        bool OnRoll { get; }
		bool Rooling { get; }
        bool OffRool { get; }

		bool OnAttack{ get; }
		bool Attacking{ get; }
		bool OffAttack{ get; }

		void ButtonInput();

	}
}
