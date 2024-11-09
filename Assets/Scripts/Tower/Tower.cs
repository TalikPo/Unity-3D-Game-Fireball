using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(TowerBuilder))]
public class Tower : MonoBehaviour
{
    [SerializeField] private TowerBuilder towerBuilder;
    private List<Block> blocks = new List<Block>();
    public event UnityAction OnTowerDistroyed;
    public event UnityAction<int> OnTowerSizeUpdate;
    void Start()
    {
        blocks = towerBuilder.Build();

        foreach (var block in blocks)
        {
            block.OnBlockDestroyed += whenBlockDestroyed;
        }
        OnTowerSizeUpdate?.Invoke(blocks.Count);
    }

    private void whenBlockDestroyed(Block destroyedBlock)
    {
        blocks.Remove(destroyedBlock);
        foreach (var block in blocks)
        {
            block.transform.position = new Vector3(block.transform.position.x, block.transform.position.y - block.transform.localScale.y, block.transform.position.z);
        }
        OnTowerSizeUpdate?.Invoke(blocks.Count);
        Destroy();
    }

    private void Destroy()
    {
        if(blocks.Count == 0)
        {
            OnTowerDistroyed?.Invoke();
        }
    }
}
