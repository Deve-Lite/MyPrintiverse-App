using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPrintiverse
{
    /// <summary>
    /// Class for storing global data.
    /// </summary>
    public static class GlobalConst
    {

        private static bool isLogged;
        /// <summary>
        /// Returns true if app user is logged else flase.
        /// </summary>
        public static bool IsLogged { get => isLogged; set => isLogged = value; }


        private static bool hasConnection;
        /// <summary>
        /// Returns true if device is connected to internet else false.
        /// </summary>
        public static bool HasConnection { get => hasConnection; set => hasConnection = value;  }

    }
}
