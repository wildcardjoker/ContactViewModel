// Copyright (c) 2015 WildCardJoker
// Licensed under the MIT License: http://opensource.org/licenses/MIT
// Created: 2015-07-12
// Last Modified: 2015-07-25-8:22 PM

#region Using Directives

using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using ContactViewModel.Annotations;
using wcj;

#endregion

namespace ContactViewModel
{
    public class Base : INotifyPropertyChanged, INotifyCollectionChanged
    {
        #region Fields

        private Person _contactPerson;
        private ICommand _newContactCommand;
        private ObservableCollection<Person> _persons;

        #endregion

        #region Properties

        public Person ContactPerson
        {
            get { return _contactPerson; }
            set
            {
                _contactPerson = value;
                OnPropertyChanged("ContactPerson");
            }
        }

        public ICommand NewContactCommand => _newContactCommand ??
                                             (_newContactCommand =
                                                 new RelayCommand(param => AddNewContact()));

        public ObservableCollection<Person> Persons
        {
            get { return _persons; }
            set
            {
                _persons = value;
                OnPropertyChanged("Persons");
            }
        }

        #endregion

        #region INotifyCollectionChanged Members

        public event NotifyCollectionChangedEventHandler CollectionChanged;

        #endregion

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        private void AddNewContact()
        {
            ContactPerson = new Person();
        }

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            handler?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}