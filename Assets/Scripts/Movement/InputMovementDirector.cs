using UnityEngine;

namespace PacMan
{
    public class InputMovementDirector : IMovementUpdater
    {
        public void UpdateTarget(IMovement movement)
        {
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
            {
                movement.TrySetDirection(Direction.Up);
            }
            else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
            {
                movement.TrySetDirection(Direction.Down);
            }
            else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            {
                movement.TrySetDirection(Direction.Left);
            }
            else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            {
                movement.TrySetDirection(Direction.Right);
            }
        }
    }
}