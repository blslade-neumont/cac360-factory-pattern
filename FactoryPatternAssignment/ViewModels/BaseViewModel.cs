using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace FactoryPatternAssignment.ViewModels
{
    public class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        protected virtual void SetProperty<T>(ref T member, T value, [CallerMemberName] string propertyName = null)
        {
            if (!Equals(member, value))
            {
                member = value;
                OnPropertyChanged(propertyName);
            }
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
