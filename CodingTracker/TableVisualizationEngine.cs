using ConsoleTableExt;

namespace CodingTracker;

internal class TableVisualizationEngine
{
  internal static void DisplayCodingTracker(List<CodingSession> codingsessionsdata)
    {
        ConsoleTableBuilder
            .From(codingsessionsdata)
            .ExportAndWriteLine();
            
    }
}
