using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{
    public int hits = 1;
    public int points = 10;
    public Vector3 rotator;
    public Material hitMaterial;

    Material _backMat;
    Renderer _renderer;
    void Start()
    {
        transform.Rotate(rotator *(transform.position.x + transform.position.y)* 0.1f);
        _renderer = GetComponent<Renderer>();
        _backMat = _renderer.sharedMaterial; 
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(rotator * Time.deltaTime);
    }
    private void OnCollisionEnter(Collision collision)
    {
        hits--;
        GameManager.Instance.Score += points;
        if(hits <= 0)
        {
            Destroy(gameObject);
        }
        _renderer.sharedMaterial = hitMaterial;
        Invoke("RestoredMaterial", 0.05f);
    }
    void RestoredMaterial()
    {
        _renderer.sharedMaterial = _backMat;
    }
}
