using Assets.Scripts;
using Assets.Scripts.Objects.Electrical;
using Assets.Scripts.Objects.Motherboards;
using Assets.Scripts.Util;
using HarmonyLib;
using UnityEngine;

namespace TraderHashMod
{
    [HarmonyPatch(typeof(SatelliteDish), nameof(SatelliteDish.GetLogicValue))]
    public class TraderHash
    {
        [HarmonyPrefix]
        public static bool Prefix(LogicType logicType, TraderContact ____strongestContact, ref double __result)
        {
            if (logicType == LogicType.SignalID && ____strongestContact != null)
            {
                //string str = ____strongestContact.DisplayName;
                //int value = Hash128.Parse(str).GetHashCode();
                int value = ____strongestContact.TradeData.TraderData.IdHash;
                __result = value;
                return false;
            }
            return true;
        }
    }
}