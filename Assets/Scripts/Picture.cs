using System;
using System.Collections;
using UnityEngine;


namespace TestTask
{
    public class Picture : MonoBehaviour
    {
        [SerializeField] private Tile _tilePrefab;
        [SerializeField] private int _width;
        [SerializeField] private int _height;


        public static event Action LevelBuilded;



        private void Start()
        {
             StartCoroutine(SpawnTiles());
        }
        private IEnumerator SpawnTiles()
        {
            float step = _tilePrefab.transform.lossyScale.x;
            for (int i = 0; i < _height; i++)
            {
                for (int j = 0; j < _width; j++)
                {
                    Instantiate(_tilePrefab).transform.position = transform.position + new Vector3(j  * step, i * step, 0);
                    yield return null;
                }
            }
            LevelBuilded?.Invoke();
        }
    }
}

