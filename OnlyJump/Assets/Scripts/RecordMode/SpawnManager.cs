using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OnlyJump.RecordMode
{
    public class SpawnManager : MonoBehaviour
    {
        private ObjectPooling objectPooling;
        [SerializeField] private HandilingRecord recording;
        [SerializeField] private SpeedMultiplexerSO speedMultiplexerSO;

        [SerializeField] private int minTimeToSpawnObstalces;
        [SerializeField] private int maxTimeToSpawnObstalces;

        [SerializeField] private int minTimeToSpawnCoins;
        [SerializeField] private int maxTimeToSpawnCoins;

        private bool spawningObstalces;
        private bool spawningCoin;

        private void Awake() => objectPooling = GetComponent<ObjectPooling>();
      
        private void Update()
        {
            if (LevelManager.Instance.IsPlayState() && !spawningObstalces)
            {
                spawningObstalces = true;
                StartCoroutine(SpawnObstacles());
            }

            if (LevelManager.Instance.IsPlayState() && !spawningCoin)
            {
                spawningCoin = true;
                StartCoroutine(SpawnCoin());
            }
        }

        private IEnumerator SpawnObstacles()
        {
            int intervalsObstalcesSpawn = Random.Range(minTimeToSpawnObstalces, maxTimeToSpawnObstalces);

            yield return new WaitForSeconds(intervalsObstalcesSpawn);

            RecordModeObject obst = objectPooling.GetObstalces();
            obst.transform.position = new Vector2(transform.position.x, obst.transform.position.y);
            obst.gameObject.SetActive(true);
            obst.SetSpeedMultiplexer(speedMultiplexerSO.GetSpeedBust(recording.CurrentRecord));
            spawningObstalces = false;

        }

        private IEnumerator SpawnCoin()
        {
            int intervalsCoinsSpawn = Random.Range(minTimeToSpawnCoins, maxTimeToSpawnCoins);
            yield return new WaitForSeconds(intervalsCoinsSpawn);
            RecordModeObject coin = objectPooling.GetCoin();
            if (coin != null)
            {
                coin.transform.position = new Vector2(transform.position.x, coin.transform.position.y);
                coin.gameObject.SetActive(true);
                coin.SetSpeedMultiplexer(speedMultiplexerSO.GetSpeedBust(recording.CurrentRecord));
            }
            spawningCoin = false;
        }
    }
}
