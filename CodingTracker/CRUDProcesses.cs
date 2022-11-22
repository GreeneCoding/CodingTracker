namespace CodingTracker;

internal class CRUDProcesses
{
    
    internal static void AddProcess()
    {
        string startTime = UserInput.GetStartTime();
        string endTime = UserInput.GetEndTime(startTime);
        string duration = UserInput.GetDuration(startTime, endTime);
        CRUDController.AddCodingEntry(startTime, endTime, duration);
        
    }
    internal static void ReadProcess()
    {
        CRUDController.GetCodingEntries();
    }
    internal static void UpdateProcess()
    {
        int id = UserInput.GetCodingEntryId();
        string startTime = UserInput.GetStartTime();
        string endTime = UserInput.GetEndTime(startTime);
        string duration = UserInput.GetDuration(startTime, endTime);
        CRUDController.UpdateCodingEntry(id,startTime,endTime,duration);
    }
    internal static void DeleteProcess()
    {
        int id = UserInput.GetCodingEntryId();
        CRUDController.DeleteCodingEntry(id);
    }



}
