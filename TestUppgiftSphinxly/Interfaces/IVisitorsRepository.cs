namespace TestUppgiftSphinxly.Interfaces
{
    public interface IVisitorsRepository
    {
        bool CheckIfVisitorIsSaved(string name);
        void SaveVisitor(string name);
        void DeleteVisitor(string name);
    }
}
