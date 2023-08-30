using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class DataPersistenceManager : MonoBehaviour
{
    [Header("File storage config")]
    [SerializeField] private string filename;
    [SerializeField] private bool useEncryption;
    private GameData _gameData;
    private List<IDataPersistence> dataPersistenceObjects;
    private FileDataHandler _dataHandler;
    public static DataPersistenceManager instance { get; private set; }

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("Found more than one Data persistence manager in the scene");
        }
        instance = this;
    }

    private void Start()
    {
        this._dataHandler = new FileDataHandler(Application.persistentDataPath, filename, useEncryption);
        this.dataPersistenceObjects = FindAllDataPersistenceObjects();
            LoadGame();
    }

    public void NewGame()
    {
        this._gameData = new GameData();
    }

    public void LoadGame()
    {
        this._gameData = _dataHandler.Load();

        if (this._gameData == null)
        {
            Debug.Log("No data was found. Initialising data to defaults.");
            NewGame();
        }

        foreach (IDataPersistence dataPersistenceObj in dataPersistenceObjects)
        {
            dataPersistenceObj.LoadData(_gameData);
        }
    }

    public void SaveGame()
    {
        foreach (IDataPersistence dataPersistenceObj in dataPersistenceObjects)
        {
            dataPersistenceObj.SaveData(ref _gameData);
        }

        _dataHandler.Save(_gameData);
    }

    private List<IDataPersistence> FindAllDataPersistenceObjects()
    {
        IEnumerable<IDataPersistence> dataPersistenceObjects = FindObjectsOfType<MonoBehaviour>()
            .OfType<IDataPersistence>();

        return new List<IDataPersistence>(dataPersistenceObjects);
    }
}

