using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Block : MonoBehaviour
{
    [SerializeField] private MeshRenderer meshRenderer;
    public event UnityAction<Block> OnBlockDestroyed;

    public void setColor(Color color)
    {
        meshRenderer.material.color = color;
    }

    public void Destroy()
    {
        OnBlockDestroyed?.Invoke(this);
        gameObject.SetActive(false);
    }


}
