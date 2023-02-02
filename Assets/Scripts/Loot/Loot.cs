using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loot : MonoBehaviour
{
    [System.Serializable]
    public class LootItem
    {
        public int weight;
        public GameObject iten;
    }

    public List<LootItem> itens;

    [SerializeField] int totalWeight = 0;


    public void SpawnLoot()
    {
        int wight = Random.Range(0, totalWeight);

        foreach (LootItem iten in itens)
        {
            if (wight < iten.weight)
            {
                if(iten.iten != null)
                    Instantiate(iten.iten, transform.position, Quaternion.identity);
                return;
            }
            wight -= iten.weight;
        }
    }

    void OnValidate()
    {
        if (itens.Count > 0)
        {
            totalWeight = 0;

            foreach (LootItem iten in itens)
            {
                totalWeight += iten.weight;
            }
        }

    }


    [ContextMenu("Sort Loot")]
    void SortLoot()
    {
        itens.Sort((LootItem a, LootItem b) =>
        {
            return a.weight > b.weight ? 0 : 1;
        });
    }

}
