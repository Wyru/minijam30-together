using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeSpawn : MonoBehaviour
{
    public Transform[] spanwPoints;

    public GameObject slimePrefab;

    List<SlimeBehavior> slimes;

    int wave;

    void Start()
    {
        slimes = new List<SlimeBehavior>();
    }

    void Update()
    {
        if(slimes.TrueForAll(IsDead))
        {
            int numerOfEnemies = fib(wave++);

            for (int i = 0; i < slimes.Count; i++)
            {
                Destroy(slimes[i].gameObject);
            }

            slimes.Clear();

            for (int i = 0; i < numerOfEnemies; i++)
            {
                int pos = Random.Range(0, spanwPoints.Length);
                SlimeBehavior slime = Instantiate(slimePrefab, spanwPoints[pos]).GetComponent<SlimeBehavior>();
                slimes.Add(slime);
            }
        }
    }

    int fib(int i)
    {
        if (i == 0)
            return 1;

        if (i == 1)
            return 1;

        return fib(i - 1) + fib(i - 2);
    }

    private static bool IsDead(SlimeBehavior slime)
    {
        return slime.Dead;
    }
}
