using UnityEngine;

namespace Scenes.Joystick
{
    public class MoveObjectWithInput : MonoBehaviour
    {
        [SerializeField] private BustaGames.Joystick.Joystick[] joys;

        public void Reset()
        {
            transform.position = Vector3.zero;
        }
        
        private void Update()
        {
            foreach (var joystick in joys)
            {
                transform.position += joystick.Direction * Time.deltaTime;
            }
        }
    }
}
