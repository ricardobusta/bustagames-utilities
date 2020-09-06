using UnityEngine;

namespace Scenes.Joystick
{
    public class MoveObjectWithInput : MonoBehaviour
    {
        [SerializeField] private BustaGames.Joystick.Joystick[] joys;

        private void Update()
        {
            foreach (var joystick in joys)
            {
                transform.position += joystick.Direction * Time.deltaTime;
            }
        }
    }
}
