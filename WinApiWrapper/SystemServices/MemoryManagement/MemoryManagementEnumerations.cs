using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinApiWrapper.SystemServices.MemoryManagement
{
    /// <summary>
    /// Enumerazioni usate dalle funzioni di gestione memoria.
    /// </summary>
    internal static class MemoryManagementEnumerations
    {
        /// <summary>
        /// Opzioni di allocazione della memoria globale.
        /// </summary>
        [Flags]
        internal enum GlobalMemoryAllocationOptions
        {
            /// <summary>
            /// Alloca memoria, inizializzata a zero, che può essere spostata.
            /// </summary>
            /// <remarks>Non può essere usato insieme a <see cref="GMEM_FIXED"/>.</remarks>
            GHND = 
                GMEM_MOVEABLE |
                GMEM_ZEROINIT,
            /// <summary>
            /// Alloca memoria fissa.
            /// </summary>
            /// <remarks>Il valore restituito è un puntatore.</remarks>
            GMEM_FIXED = 0,
            /// <summary>
            /// Allora memoria che può essere spostata.
            /// </summary>
            GMEM_MOVEABLE = 2,
            /// <summary>
            /// Inizializza la memoria a zero.
            /// </summary>
            GMEM_ZEROINIT = 64,
            /// <summary>
            /// Alloca memoria fissa inizializzata a zero.
            /// </summary>
            GPTR =
                GMEM_FIXED |
                GMEM_ZEROINIT
        }
    }
}