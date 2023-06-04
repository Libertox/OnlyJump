using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OnlyJump.RecordMode
{
    public class ObjectPooling : MonoBehaviour
    {
        [SerializeField] private List<RecordModeObject> obstacles;
        [SerializeField] private List<RecordModeObject> coins;

        [SerializeField] private RecordModeObject[] obstalcesToPool;
        [SerializeField] private RecordModeObject coinToPoll;

        [SerializeField] private int amountToPool;

        private void Start()
        {
            InitCoins();
            InitObstalces();
        }

        private void InitCoins()
        {
            coins = new List<RecordModeObject>();
            for (int i = 0; i < amountToPool; i++)
            {
                RecordModeObject temp = Instantiate(coinToPoll);
                temp.gameObject.SetActive(false);
                coins.Add(temp);
            }
        }

        private void InitObstalces()
        {
            obstacles = new List<RecordModeObject>();
            for (int j = 0; j < obstalcesToPool.Length; j++)
            {
                for (int i = 0; i < amountToPool; i++)
                {
                    RecordModeObject temp = Instantiate(obstalcesToPool[j]);
                    temp.gameObject.SetActive(false);
                    obstacles.Add(temp);
                }
            }
        }
        public RecordModeObject GetCoin()
        {
            for (int i = 0; i < amountToPool; i++)
            {
                if (!coins[i].gameObject.activeInHierarchy)
                    return coins[i];
            }
            return null;
        }

        public RecordModeObject GetObstalces()
        {
            int index = Random.Range(0, obstacles.Count);
            while (obstacles[index].gameObject.activeInHierarchy)
            {
                index = Random.Range(0, obstacles.Count);
            }
            return obstacles[index];
        }
    }
}
