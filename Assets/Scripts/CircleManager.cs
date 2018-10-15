using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleManager : MonoBehaviour {
    public float DecreaseSpeed = 0.5f;
    public float DifficultyIncreaseFactor;
    public Vector3 minusAmount = new Vector3(0.1f, 0f, 0.1f);
    public Vector3 currentSize;
    public Vector3 spawnRotation;
    public GameManager gameManager;
    public Rotator rotator;


	void Update () {
        transform.position = new Vector3(0, -1, 0);
        transform.localScale -= minusAmount * DecreaseSpeed;
        currentSize = transform.localScale;
        ChangeDifficulty();
        if (currentSize.x <= minusAmount.x)
        {
            transform.localScale = new Vector3(10, 1, 10);
            spawnRotation = new Vector3(0, Random.Range(1f, 360f), 0);
            transform.eulerAngles = spawnRotation;

        }

    }

    void ChangeDifficulty()
    {
        DecreaseSpeed += (gameManager.Score / DifficultyIncreaseFactor);
        rotator.RotationSpeed += (gameManager.Score / (DifficultyIncreaseFactor / 100));
    }
}
