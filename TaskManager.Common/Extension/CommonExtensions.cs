using System;
using System.ComponentModel;
using System.Linq;
using System.Xml;

namespace TaskManager.Common.Extension {
    public static class CommonExtensions {
        /// <summary>
        ///     Get enum description
        /// </summary>
        /// <param name="enm">Enum instance</param>
        /// <returns>Desctiption</returns>
        public static string GetDescription(this Enum enm) {
            var description =
                (enm.GetType()
                    .GetField(enm.ToString())
                    .GetCustomAttributes(typeof (DescriptionAttribute), false)
                    .First() as DescriptionAttribute);
            return description != null ? description.Description : null;
        }
    }
}