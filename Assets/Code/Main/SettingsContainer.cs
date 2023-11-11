using UnityEngine;

namespace Main
{
    public class SettingsContainer : Singleton<SettingsContainer>
    {
        public PlayerSettings SpaceShipSettings => spaceShipSettings;

        [SerializeField] private PlayerSettings spaceShipSettings;
    }
}
