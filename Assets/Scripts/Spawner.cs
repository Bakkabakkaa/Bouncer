using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;


public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject _gift;
    [SerializeField] private GameObject _snowman;
    [SerializeField] private GameObject _candy;
    [SerializeField] private Transform _gameBoard;
    private ColorManager _colorManager;

    private void Awake()
    {
        _colorManager = GetComponent<ColorManager>();
    }

    private void Start()
    {
        for (int i = 0; i < 6; i++)
        {
            var currentGift = Instantiate(_gift, GetRandomPoint(), Quaternion.identity);
            currentGift.GetComponent<Gift>().SetColor(_colorManager.GetRandomColor());
        }

        var snowmanInstance = Instantiate(_snowman, _gameBoard).GetComponent<Snowman>();
        snowmanInstance.SetSpawner(this);
        InstantiateCandy();



    }

    private Vector3 GetRandomPoint(float minDistanceFromCenter = 1f, float radius = 0.5f)
    {
        Vector3 point;
        int attempts = 0;

        do
        {
            float randomX = Random.Range(-_gameBoard.localScale.x * 5, _gameBoard.localScale.x * 5);
            float randomZ = Random.Range(-_gameBoard.localScale.z * 5, _gameBoard.localScale.z * 5);
            point = new Vector3(randomX, 0.05f, randomZ);

            attempts++;
            if (attempts > 100) break; // защита от бесконечного цикла
        } 
        while (Vector3.Distance(point, Vector3.zero) < minDistanceFromCenter ||
               Physics.OverlapSphere(point, radius).Length > 0);

        return point;
    }

    public void InstantiateCandy()
    {
        var currentCandy = Instantiate(_candy, GetRandomPoint(), _candy.transform.rotation);
        currentCandy.GetComponent<Candy>().SetColor(_colorManager.GetRandomColor());
    }
}