using System;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

namespace Core.RoomSystem
{
   
    public class RoomsPool
    {
        private List<GameObject> _rooms;

        
        public void InitPool(List<GameObject> rooms, GameObject parent)
        {
            _rooms = new List<GameObject>();
            foreach (var room in rooms)
            {
                var roomInstance = GameObject.Instantiate(room, parent.transform);
                ReturnToPool(roomInstance);
            }

        }

        

        public bool TryGetFromPool(out GameObject roomInstance)
        {
            Random rnd = new Random();
            roomInstance = null;
            Debug.Log(_rooms.Count);
            if (_rooms.Count > 0)
            {
                var ind = rnd.Next(0, _rooms.Count);
                roomInstance = _rooms[ind];
                roomInstance.SetActive(true);
                _rooms.RemoveAt(ind);
                return true;
            }

            return false;
        }

        public void ReturnToPool(GameObject enemyInstance)
        {
            enemyInstance.SetActive(false);
            _rooms.Add(enemyInstance);
           
        }
    }
}
