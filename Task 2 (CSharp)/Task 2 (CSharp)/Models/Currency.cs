using System.ComponentModel;
using System.Runtime.CompilerServices;
using Task_2__CSharp_.Annotations;

namespace Task_2__CSharp_.Models
{
    public class Currency : INotifyPropertyChanged
    {
        private decimal _rateInRubles;

        public string Name { get; set; }

        public decimal RateInRubles
        {
            get => _rateInRubles;
            set
            {
                _rateInRubles = value;
                OnPropertyChanged(nameof(RateInRubles));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}