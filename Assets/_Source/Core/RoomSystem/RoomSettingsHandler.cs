using System.Collections;
using System.Collections.Generic;
using Core.RoomSystem;
using UnityEngine;

public class RoomSettingsHandler : MonoBehaviour
{
    [field: SerializeField] public Services Services { get; set; }
    [field: SerializeField] public bool IsNeeded { get; set; }
    [field: SerializeField] public int RoomId { get; set; }
}
