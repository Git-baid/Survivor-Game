using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroprateManager : MonoBehaviour
{
    [System.Serializable]
    public class Drops
    {
        public string name;
        public GameObject prefab;
        public float droprate;
    }

    public List<Drops> drops;

    private void OnDestroy()
    {
        float randomNum = UnityEngine.Random.Range(0f, 1f);
        List<Drops> possibleDrops = new List<Drops>();

        // Go through list of drops and determine which would have dropped
        foreach (Drops d in drops)
        {
            if(randomNum <= d.droprate)
            {
                possibleDrops.Add(d);
            }
        }

        // If an item(s) would have dropped, go through the list of items that would have dropped and only pick the rarest one to spawn
        if(possibleDrops.Count > 0)
        {
            Drops chosenDrop = possibleDrops[0];

            for (int i = 1; i < possibleDrops.Count; i++)
            {
                if (possibleDrops[i].droprate < chosenDrop.droprate) 
                {
                    chosenDrop = possibleDrops[i];
                }
            }
            Instantiate(chosenDrop.prefab, transform.position, Quaternion.identity);
        }

    }
}
