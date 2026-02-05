using System;
using System.Collections.Generic;

namespace Tutorial.UniversalStorage
{
    public class Stats
    {
        public Dictionary<StatTypes, object> _statTypeToStat = new Dictionary<StatTypes, object>();

        public void Add<T>(StatTypes statType, ReactiveVariable<T> stat) where T : IEquatable<T>
        {
            _statTypeToStat.Add(statType, stat);
        }

        public bool TryGet<T>(StatTypes statType, out ReactiveVariable<T> stat) where T : IEquatable<T>
        {
            if (_statTypeToStat.TryGetValue(statType, out object value))
            {
                if (value is ReactiveVariable<T> findedStat)
                {
                    stat = findedStat;
                    return true;
                }
            }

            stat = null;
            return false;
        }
    }
}
