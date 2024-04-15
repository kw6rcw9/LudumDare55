using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Core.RoomSystem
{
    public class GeneratorController : MonoBehaviour
    {
        [SerializeField] private List<GameObject> roomPrefabs;
        [SerializeField] private GameObject parent;
        [field: SerializeField] public GameObject Hall { get; private set; }
        [field: SerializeField] public int NeededCorrectTasksNum { get; set; }
        private RoomsPool _pool;
        public static Action EnterRoom;
    
        [Inject]
        private void Construct(RoomsPool pool)
        {
            _pool = pool;
            _pool.InitPool(roomPrefabs, parent);
            
        
        }

        public void GetRoom()
        {
            
            if(_pool.TryGetFromPool(out GameObject room))
            {
                if (!gameObject.activeSelf)
                {
                    gameObject.SetActive(true);
                    EnterRoom?.Invoke();
                }
                
            }
            else
            {
                Game.Lose();
            }
           
            
            
            
            
        }
    
    
    
    
    
    
    
    
    
    }
}
