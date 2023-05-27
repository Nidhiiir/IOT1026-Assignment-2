using System;

namespace Assignment
{
    public class TreasureChest
    {
        private State _state = State.Locked;
        private readonly Material _material;
        private readonly LockType _lockType;
        private readonly LootQuality _lootQuality;

        // Default Constructor
        public TreasureChest()
        {
            _material = Material.Iron;
            _lockType = LockType.Expert;
            _lootQuality = LootQuality.Green;
        }

        private void ValidateCurrentState(State expectedState)
        {
            if (_state != expectedState)
            {
                throw new TressureMistake("Invalid state");
            }
        }

        /// <summary>
        /// Constructor that sets the initial state of the treasure chest.
        /// </summary>
        /// <param name="state">The initial state of the chest.</param>
        public TreasureChest(State state) : this()
        {
            _state = state;
        }

        /// <summary>
        /// Constructor that sets the material, lock type, and loot quality of the treasure chest.
        /// </summary>
        /// <param name="material">The material of the chest.</param>
        /// <param name="lockType">The lock type of the chest.</param>
        /// <param name="lootQuality">The loot quality of the chest.</param>
        public TreasureChest(Material material, LockType lockType, LootQuality lootQuality)
        {
            _material = material;
            _lockType = lockType;
            _lootQuality = lootQuality;
        }

        /// <summary>
        /// Retrieves the current state of the treasure chest.
        /// </summary>
        /// <returns>The current state of the chest.</returns>
        public State GetState()
        {
            return _state;
        }

        /// <summary>
        /// Manipulates the treasure chest based on the specified action.
        /// </summary>
        /// <param name="action">The action to perform on the chest.</param>
        /// <returns>The new state of the chest after the manipulation.</returns>
        public State? Manipulate(Action action)
        {
            switch (action)
            {
                case Action.Open:
                    ValidateCurrentState(State.Closed);
                    Open();
                    break;
                case Action.Close:
                    ValidateCurrentState(State.Open);
                    Close();
                    break;
                case Action.Lock:
                    ValidateCurrentState(State.Closed);
                    Lock();
                    break;
                case Action.Unlock:
                    ValidateCurrentState(State.Locked);
                    Unlock();
                    break;
                default:
                    throw new TressureMistake($"Invalid action: {action}");
            }

            return _state;
        }

        /// <summary>
        /// Unlocks the treasure chest.
        /// </summary>
        public void Unlock()
        {
            _state = State.Closed;
        }

        /// <summary>
        /// Locks the treasure chest.
        /// </summary>
        public void Lock()
        {
            _state = State.Locked;
        }

        /// <summary>
        /// Opens the treasure chest.
        /// </summary>
        public void Open()
        {
            // Check if the chest is closed
            if (_state == State.Closed)
            {
                _state = State.Open;
            }
            else if (_state == State.Open)
            {
                Console.WriteLine("already open!");
            }
            else if (_state == State.Locked)
            {
                Console.WriteLine("Chest not opened.. ");
            }
        }

        /// <summary>
        /// Closes the treasure chest.
        /// </summary>
        public void Close()
        {
            _state = State.Closed;
        }

        /// <summary>
        /// Returns a string representation of the treasure chest.
        /// </summary>
        /// <returns>A string describing the chest properties.</returns>
        public override string ToString()
        {
            return $"A {_state} chest with the following properties:\nMaterial: {_material}\nLock Type: {_lockType}\nLoot Quality: {_lootQuality}";
        }

        private static void ConsoleHelper(string prop1, string prop2, string prop3)
        {
            Console.WriteLine($"Choose from the following properties.\n1.{prop1}\n2.{prop2}\n3.{prop3}");
        }

        public enum State { Open, Closed, Locked };
        public enum Action { Open, Close, Lock, Unlock };
        public enum Material { Oak, RichMahogany, Iron };
        public enum LockType { Novice, Intermediate, Expert };
        public enum LootQuality { Grey, Green, Purple };
    }

    public class TressureMistake : Exception
    {
        // Default constructor of TressureMistake class
        public TressureMistake(string message) : base(message)
        {
            Console.WriteLine(message);
        }
    };
}
