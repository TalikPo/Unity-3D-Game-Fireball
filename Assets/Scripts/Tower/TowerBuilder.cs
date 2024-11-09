using System.Collections.Generic;
using UnityEngine;

public class TowerBuilder : MonoBehaviour
{
    [SerializeField] private Block blockTemplate;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private Vector2Int towerMinMaxSize;
    [SerializeField] private Color[] colors;
    private int towerSize;
    private List<Block> blocks = new List<Block>();

    public List<Block> Build()
    {
        var currentSpawnPoint = spawnPoint.position;
        towerSize = Random.Range(towerMinMaxSize.x, towerMinMaxSize.y);
        for (int i = 0; i < towerSize; i++)
        {
            var spawnPosition = new Vector3(spawnPoint.position.x, currentSpawnPoint.y + blockTemplate.transform.localScale.y, spawnPoint.position.z);
            var newBlock = Instantiate(blockTemplate, spawnPosition, Quaternion.Euler(0, i * 5, 0), spawnPoint);
            newBlock.setColor(colors[Random.Range(0, colors.Length)]);
            blocks.Add(newBlock);
            currentSpawnPoint = newBlock.transform.position;
        }
        return blocks;
    }
}
