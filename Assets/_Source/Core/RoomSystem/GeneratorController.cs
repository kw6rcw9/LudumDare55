using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Core.RoomSystem
{
    public class GeneratorController : MonoBehaviour
    {
        [SerializeField] private List<GameObject> roomPrefabs;
        [SerializeField] private GameObject parent;
        private RoomsPool _pool;
    
        [Inject]
        private void Construct(RoomsPool pool)
        {
            _pool = pool;
            _pool.InitPool(roomPrefabs, parent);
            
        
        }

        public void GetRoom()
        {
            _pool.TryGetFromPool(out GameObject room);
            Debug.Log(room.activeSelf);
            
        }
    
    
    
    
    
    
    
    
    
    }
}
