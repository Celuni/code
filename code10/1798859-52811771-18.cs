        public class RespawnManager : MonoBehaviour
        {
            public static RespawnManager Singleton;
            private void Awake()
            {
                if(Singleton)
                {
                    enabled = false;
                    return;
                }
                Singleton = this;
            }
            private void DestroyAndRespawn(GameObject obj)
            {
                StartCoroutine(DestroyAndRespawnRoutine(obj));
            }
            private IEnumerator DestroyAndRespawnRoutine(GameObject obj)
            {
                // disable the obj
                obj.SetActive(false);
                // Wait 3 seconds
                yield return new WaitForSeconds(3f);
                // Set the objactive
                obj.SetActive(true);
            }
        }
