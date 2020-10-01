using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(MissionManager))]
[RequireComponent(typeof(DataManager))]
[RequireComponent(typeof(PlayerManager))]
public class ManagerController : MonoBehaviour
{
    //ManagerCOntroller инициализирует все managers и запускает (Startup)
    public static MissionManager Mission { get; private set; }
    public static DataManager Data { get; private set; }
    public static PlayerManager Player { get; private set; }

    //List Managers для дальнейшего запуска (Startup) всех managers
    private List<IGameManager> _startupManagers;

    private void Awake()
    {
        Data = GetComponent<DataManager>();
        Mission = GetComponent<MissionManager>();
        Player = GetComponent<PlayerManager>();

        _startupManagers = new List<IGameManager>();
        _startupManagers.Add(Data);
        _startupManagers.Add(Mission);
        _startupManagers.Add(Player);

        StartCoroutine(StartupManagers());
    }

    private IEnumerator StartupManagers()
    {
        foreach(IGameManager manager in _startupManagers)
        {
            manager.Startup();
        }

        yield return null;
    }

}
