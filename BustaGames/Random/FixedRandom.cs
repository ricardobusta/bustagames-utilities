namespace BustaGames.Random {
    public class FixedRandom {
        private UnityEngine.Random.State _state;

        public FixedRandom(int seed) {
            UnityEngine.Random.InitState(seed);
            _state = UnityEngine.Random.state;
        }

        public float Value(float max) {
            return RandomRange(0, max);
        }

        public int Value(int max) {
            return RandomRange(0, max);
        }

        public float RandomRange(float min, float max) {
            UnityEngine.Random.state = _state;
            var result = UnityEngine.Random.Range(min, max);
            _state = UnityEngine.Random.state;
            return result;
        }

        public int RandomRange(int min, int max) {
            UnityEngine.Random.state = _state;
            var result = UnityEngine.Random.Range(min, max);
            _state = UnityEngine.Random.state;
            return result;
        }
    }
}