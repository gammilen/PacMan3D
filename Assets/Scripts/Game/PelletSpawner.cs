using System.Collections.Generic;
using UnityEngine;
using PacMan;

namespace Game
{
    public class PelletSpawner : MonoBehaviour
    {
        [SerializeField] private GameObject _pellet;
        [SerializeField] private GameObject _energizerPellet;

        [SerializeField] private CellsField _cellsField;
        [SerializeField] private PelletsRegistry _pellets;

        private Dictionary<IActiveEntity, GameObject> _pelletsObjects;

        private void Start()
        {
            _pellets.PelletConsumed += HandleConsumed;
            InitPellets();
        }

        private void OnDisable()
        {
            _pellets.PelletConsumed -= HandleConsumed;
        }

        private void HandleConsumed(IActiveEntity pellet)
        {
            if (_pelletsObjects.ContainsKey(pellet))
            {
                var go = _pelletsObjects[pellet];
                _pelletsObjects.Remove(pellet);
                Destroy(go);
            }
        }

        private void InitPellets()
        {
            _pelletsObjects = new Dictionary<IActiveEntity, GameObject>();
            foreach (var pellet in _pellets.GetPellets())
            {
                var item = Instantiate(_pellet, transform);
                item.transform.position = _cellsField.GetAgentPosition(pellet.Position);
                _pelletsObjects.Add(pellet, item);
            }

            foreach (var pellet in _pellets.GetEnergizerPellets())
            {
                var item = Instantiate(_energizerPellet, transform);
                item.transform.position = _cellsField.GetAgentPosition(pellet.Position);
                _pelletsObjects.Add(pellet, item);
            }
        }
    }
}