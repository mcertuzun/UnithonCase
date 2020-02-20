using UnityEngine;
using UnityEngine.Serialization;

namespace Game.Managers
{
    public class ImageLibrary : MonoBehaviour, IProvidable
    {
        public Sprite GreenCubeSprite;
        public Sprite GreenCubeRocketHintSprite;
        public Sprite GreenCubeBombHintSprite;
        public Sprite YellowCubeSprite;
        public Sprite YellowCubeRocketHintSprite;
        public Sprite YellowCubeBombHintSprite;
        public Sprite BlueCubeSprite;
        public Sprite BlueCubeRocketHintSprite;
        public Sprite BlueCubeBombHintSprite;
        public Sprite RedCubeSprite;
        public Sprite RedCubeRocketHintSprite;
        public Sprite RedCubeBombHintSprite;

        public Sprite BalloonSprite;
        public Sprite GreenBalloonSprite;
        public Sprite YellowBalloonSprite;
        public Sprite BlueBalloonSprite;
        public Sprite RedBalloonSprite;
        
        public Sprite CrateLayer1Sprite;
        public Sprite CrateLayer2Sprite;
        
        public Sprite DuckSprite;

        public Sprite PinwheelBackground;
        public Sprite GreenPinwheelLeaf;
        public Sprite BluePinwheelLeaf;
        public Sprite YellowPinwheelLeaf;
        public Sprite RedPinwheelLeaf;
        
        public Sprite VerticalRocketSprite;
        public Sprite HorizontalRocketSprite;
        public Sprite BombSprite;

        private void Awake()
        {
            ServiceProvider.Register(this);
        }
    }
}