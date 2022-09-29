using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using ExpenseWireDesktopUI.EventModels;

namespace ExpenseWireDesktopUI.ViewModels
{
    public class ShellViewModel : Conductor<object>, IHandle<LogOnEvent>, IHandle<NewExpenseEvent>
    {
        private IEventAggregator _events;
        private HomePageViewModel _homePageVM;
        private SimpleContainer _container;
        private AddExpenseViewModel _addExpenseVM;
        public ShellViewModel(IEventAggregator events, HomePageViewModel homePageVM, SimpleContainer container, AddExpenseViewModel addExpenseVM)
        {
            _events = events;
            _homePageVM = homePageVM;
            _container = container;
            _addExpenseVM = addExpenseVM;
            _events.Subscribe( this );

            ActivateItem(_container.GetInstance<LoginViewModel>());
        }

        public void Handle(LogOnEvent message)
        {
            ActivateItem(_homePageVM);
        }

        public void Handle(NewExpenseEvent message)
        {
            ActivateItem(_addExpenseVM);
        }
    }
}
