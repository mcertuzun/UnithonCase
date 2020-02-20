using Game.Core.Enums;
using Game.Core.ItemBase;
using UnityEngine;

namespace Game.Managers
{
    public class ParticleManager : MonoBehaviour, IProvidable
    {
        public ParticleSystem CubeYellowParticle;
        public ParticleSystem CubeBlueParticle;
        public ParticleSystem CubeGreenParticle;
        public ParticleSystem CubeRedParticle;
        
        public ParticleSystem ComboHintParticle;

        private void Awake()
        {
            ServiceProvider.Register(this);
        }

        public void PlayCubeParticle(Item item)
        {
            ParticleSystem particleSystemReference;

            switch (item.GetMatchType())
            {
                case MatchType.Green:
                    particleSystemReference = CubeGreenParticle;
                    break;
                case MatchType.Yellow:
                    particleSystemReference = CubeYellowParticle;
                    break;
                case MatchType.Blue:
                    particleSystemReference = CubeBlueParticle;
                    break;
                case MatchType.Red:
                    particleSystemReference = CubeRedParticle;
                    break;
                case MatchType.Special:
                    particleSystemReference = ComboHintParticle;
                    break;
                default:
                    return;
            }

            var particle = Instantiate(particleSystemReference, item.transform.position, Quaternion.identity,
                item.Cell.Board.ParticlesParent);
            particle.Play(true);
        }

        public ParticleSystem PlayComboParticleOnItem(Item item)
        {
            var particle = Instantiate(ComboHintParticle, item.transform.position, Quaternion.identity,
                item.transform);
            particle.Play(true);
            return particle;
        }

        public void StopParticle(ParticleSystem particle)
        {
            Destroy(particle);
        }
    }
}