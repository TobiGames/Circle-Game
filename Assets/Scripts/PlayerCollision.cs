using UnityEngine;

public class PlayerCollision : MonoBehaviour {
    public CircleManager circleManager;
    public Rotator rotator;
    public GameObject CirclePrefab;
    public GameManager gameManager;

    void OnCollisionEnter(UnityEngine.Collision collisionInfo)
    {
        Debug.Log(collisionInfo.collider.name);
        circleManager.enabled = false;
        rotator.enabled = false;
        Destroy(CirclePrefab.gameObject);
        gameManager.enabled = false;
    }

}
