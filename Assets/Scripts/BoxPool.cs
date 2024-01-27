using System.Collections.Generic;
using UnityEngine;

public class BoxPool : MonoBehaviour
{
    public GameObject specialBoxPrefab;
    public int poolSize = 6;
    public Vector3[] spawnPositions;

    private Queue<GameObject> boxPool = new Queue<GameObject>();

    void Start()
    {
        for (int i = 0; i < poolSize; i++)
        {
            GameObject obj = Instantiate(specialBoxPrefab);
            obj.SetActive(false);
            boxPool.Enqueue(obj);
        }

        ActivateRandomBoxes();
    }

    void OnEnable()
    {
        SpecialBox.OnBoxUsed += ReturnBoxToPool;
    }

    void OnDisable()
    {
        SpecialBox.OnBoxUsed -= ReturnBoxToPool;
    }

    public GameObject GetBox()
    {
        GameObject obj;
        if (boxPool.Count > 0)
        {
            obj = boxPool.Dequeue();
        }
        else
        {
            obj = Instantiate(specialBoxPrefab);
        }

        obj.SetActive(true);
        return obj;
    }

    private void ReturnBoxToPool(SpecialBox box)
    {
        box.ResetBox();
        ReturnBox(box.gameObject);
    }

    public void ReturnBox(GameObject box)
    {
        box.SetActive(false);
        boxPool.Enqueue(box);
    }

    public void ActivateRandomBoxes()
    {
        for (int i = 0; i < spawnPositions.Length; i++)
        {
            GameObject box = GetBox();
            int randomIndex = Random.Range(0, spawnPositions.Length);
            box.transform.position = spawnPositions[randomIndex];
        }
    }
}
