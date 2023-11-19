using Data;
using Tools;
using UnityEngine;

namespace Main
{
    public class PlayerPrefs : SingleBehaviour<PlayerPrefs>
    {
        public PlayerSettings SpaceShipSettings => spaceShipSettings;

        [SerializeField] private PlayerSettings spaceShipSettings;
    }
}
