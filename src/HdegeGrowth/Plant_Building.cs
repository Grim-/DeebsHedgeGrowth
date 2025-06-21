using RimWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Verse;

namespace HedgeGrowth
{
    public class HedgeSpawnExt : DefModExtension
    {
        public ThingDef wallDef;
        public ThingDef wallStuffDef;
    }

    public class Plant_Building : Plant
    {
        private HedgeSpawnExt _HedgeSpawnExt = null;
        private HedgeSpawnExt HedgeSpawnExt
        {
            get
            {
                if (_HedgeSpawnExt == null)
                {
                    _HedgeSpawnExt = this.def.GetModExtension<HedgeSpawnExt>();
                }

                return _HedgeSpawnExt;
            }
        }


        public override int YieldNow()
        {
            return 0;
        }

        public override void TickLong()
        {
            if (this.def.HasModExtension<HedgeSpawnExt>())
            {
                if (this.LifeStage == PlantLifeStage.Mature && HedgeSpawnExt != null)
                {
                    ThingDef wallDef = HedgeSpawnExt.wallDef != null ? HedgeSpawnExt.wallDef : ThingDefOf.Wall;
                    ThingDef wallStuffDef = HedgeSpawnExt != null ? HedgeSpawnExt.wallStuffDef : ThingDefOf.WoodLog;

                    GenSpawn.Spawn(ThingMaker.MakeThing(wallDef, wallStuffDef), this.Position, this.Map);
                    if (!this.Destroyed)
                    {
                        this.Destroy();
                    }

                    return;
                }
            }




            base.TickLong();
        }
    }
}
