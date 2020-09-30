using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    static public GameManager SingleManager;

    public GameObject playerPrefab;
    private void Awake()
    {
        SingleManager = this;
        Invoke("StartPlayer", 1f);
    }

    public void StartPlayer()
    {
        Vector3 startPosition = Vector3.zero;

        GameObject player = Instantiate(playerPrefab);

        player.transform.position = startPosition;
    }
}
