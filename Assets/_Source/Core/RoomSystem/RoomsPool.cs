using System;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

namespace Core.RoomSystem
{
   
    public class RoomsPool
    {
        public static List<GameObject> Rooms { get; private set; }


        public void InitPool(List<GameObject> rooms, GameObject parent)
        {
            Rooms = new List<GameObject>();
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
            Debug.Log(Rooms.Count);
            if (Rooms.Count > 0)
            {
                var ind = rnd.Next(0, Rooms.Count);
                roomInstance = Rooms[ind];
                roomInstance.SetActive(true);
                Rooms.RemoveAt(ind);
                return true;
            }

            return false;
        }

        public void ReturnToPool(GameObject enemyInstance)
        {
            enemyInstance.SetActive(false);
            Rooms.Add(enemyInstance);
           
        }
    }
}
