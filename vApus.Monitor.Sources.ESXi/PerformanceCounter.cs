﻿/*
 * 2014 Sizing Servers Lab, affiliated with IT bachelor degree NMCT
 * University College of West-Flanders, Department GKG (www.sizingservers.be, www.nmct.be, www.howest.be/en)
 * 
 * Author(s):
 *    Dieter Vandroemme
 */
using System.Collections.Generic;

namespace vApus.Monitor.Sources.ESXi {
    internal class PerformanceCounter {
        public int Id { get; set; }
        /// <summary>
        /// (perfInfo.rollupType == PerfSummaryType.none) ? string.Concat(perfInfo.groupInfo.key, '.', perfInfo.nameInfo.key) : string.Concat(perfInfo.groupInfo.key, '.', perfInfo.nameInfo.key, '.', perfInfo.rollupType);
        /// </summary>
        public string DotNotatedName { get; set; }

        public string Unit { get; set; }

        /// <summary>
        /// Only applicable if there are not instances.
        /// </summary>
        public double? Value { get; set; }

        public List<Instance> Instances { get; set; }
    }

    /// <summary>
    /// Compares the ids.
    /// </summary>
    internal class PerformanceCounterComparer : IComparer<PerformanceCounter> {
        private static PerformanceCounterComparer _performanceCounterComparer;

        public static PerformanceCounterComparer GetInstance() {
            if (_performanceCounterComparer == null) _performanceCounterComparer = new PerformanceCounterComparer();
            return _performanceCounterComparer;
        }

        private PerformanceCounterComparer() { }

        public int Compare(PerformanceCounter x, PerformanceCounter y) {
            return x.DotNotatedName.CompareTo(y.DotNotatedName);
        }
    }
}
