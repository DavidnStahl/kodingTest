using System;
using TestUppgiftSphinxly.Interfaces;
using TestUppgiftSphinxly.Repositories;
using TestUppgiftSphinxly.ViewModels;

namespace TestUppgiftSphinxly.Services
{
    public class VisitorService
    {
        private static VisitorService instance = null;
        private static readonly Object padlock = new Object();
        private IViewModelBuilder _viewModelBuilder;
        private IVisitorsRepository _visitorRepository;

        public static VisitorService Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new VisitorService();
                        instance._visitorRepository = new VisitorsRepositoryCSV();
                        instance._viewModelBuilder = new ViewModelBuilder();
                    }
                    return instance;

                }
            }
        }

        public ResponseViewModel GetVisitorModel(string name)
        {
            var result = _visitorRepository.CheckIfVisitorIsSaved(name);
            if (result)
            {
                return _viewModelBuilder.BuildOldVisitorViewModel(name);
            }
            _visitorRepository.SaveVisitor(name);
            return _viewModelBuilder.BuildNewVisitorViewModel(name);
        }
        public void DeleteVisitorData(string name)
        {
            _visitorRepository.DeleteVisitor(name);
        }
    }
      
}
    
