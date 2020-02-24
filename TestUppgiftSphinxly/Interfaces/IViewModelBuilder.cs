using TestUppgiftSphinxly.ViewModels;

namespace TestUppgiftSphinxly.Services
{
    public interface IViewModelBuilder
    {
        ResponseViewModel BuildOldVisitorViewModel(string name);
        ResponseViewModel BuildNewVisitorViewModel(string name);
    }
}