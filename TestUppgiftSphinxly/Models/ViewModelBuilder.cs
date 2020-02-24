using TestUppgiftSphinxly.ViewModels;

namespace TestUppgiftSphinxly.Services
{
    public class ViewModelBuilder : IViewModelBuilder
    {
        public ResponseViewModel BuildNewVisitorViewModel(string name)
        {
            var model =  new ResponseViewModel();
            model.Response = $"Välkommen {name}";
            model.Name = name;
            return model;
        }

        public ResponseViewModel BuildOldVisitorViewModel(string name)
        {
            var model = new ResponseViewModel();
            model.Response = $"Välkommen tillbaka {name}";
            model.Name = name;
            return model;
        }
    }
}