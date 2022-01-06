using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SpawnWave : MonoBehaviour
{
    //spawn enemies between seet count down display countdown in scene
    [SerializeField] private GameObject _enemyPrefab;
    [SerializeField] private Transform _spawnPos;
    private int _enemyCount;
    private bool spawnWave = false;

    [SerializeField] private float timeBetweenWave;
    private float _countDown;

    [SerializeField] Text _countDownText;
    private void Start()
    {
        _countDown = 5f;
        _enemyCount = 1;
    }
    private void Update()
    {
        
        DisplayText();
        if (_countDown <= 0 || spawnWave)
        {
            spawnWave = false;
            StartCoroutine(WaveSpawner());
            _countDown = timeBetweenWave;
        }
        _countDown -= Time.deltaTime;
        
    }

    IEnumerator WaveSpawner()
    {
        
        for (int i = 0; i < _enemyCount; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(1f);
        }
        _enemyCount++;
        PlayerStats.Rounds++;
        
    }
    public void SpawnWavwNow()
    {
        spawnWave = true;
    }
    private void SpawnEnemy()
    {
        Instantiate(_enemyPrefab, _spawnPos.position, _spawnPos.rotation);
    }
    private void DisplayText()
    {
        _countDownText.text = "Next Wave: " + Mathf.Floor(_countDown).ToString();
    }
    
}
