using Danmokou;
using Danmokou.Achievements;
using Danmokou.Core;
using Danmokou.Danmaku;
using Danmokou.GameInstance;
using UnityEngine;


namespace Danmokou.Miniprojects
{
    [CreateAssetMenu(menuName = "Data/GameDef/DemoPGJ")]
    public class DemoPrideGameJamDef : CampaignDanmakuGameDef
    {
        public override InstanceFeatures MakeFeatures(DifficultySettings d, InstanceMode mode, long? highScore) => new()
        {
            Basic = new BasicFeatureCreator
            {
                Continues = mode.OneLife() ? 0 : 42,
                StartLives = mode.OneLife() ? 1 : Campaign.StartLives
            },
            Score = new ScoreFeatureCreator(highScore),
            Power = new DisabledPowerFeatureCreator(),
            Faith = new FaithFeatureCreator(),
            ItemExt = new LifeItemExtendFeatureCreator(),
            Rank = new DisabledRankFeatureCreator(),
            ScoreExt = new ScoreExtendFeatureCreator(),
            Meter = d.meterEnabled ?
                new MeterFeatureCreator() :
                new DisabledMeterFeatureCreator()
        };
    }
}
