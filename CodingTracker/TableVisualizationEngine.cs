using ConsoleTableExt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingTracker
{
    internal class TableVisualizationEngine
    {
      internal static void DisplayCodingTracker(List<CodingSession> codingsessionsdata)
        {
            ConsoleTableBuilder
                .From(codingsessionsdata)
                .ExportAndWriteLine();
                
        }
    }
}
