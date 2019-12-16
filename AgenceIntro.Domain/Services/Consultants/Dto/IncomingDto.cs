using System.Collections.ObjectModel;

namespace AgenceIntro.Domain.Services.Consultants.Dto
{
    public class IncomingDto : ConsultantDto
    {
        public IncomingDto()
        {
            this.IncomingList = new ObservableCollection<IncomingByDate>();
            this.IncomingList.CollectionChanged += IncomingList_CollectionChanged;
        }

        private void IncomingList_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            this.TotalPersonalEarnings = 0;
            foreach (var item in this.IncomingList)
            {
                this.TotalPersonalEarnings += item.NetEarnings;
            }
        }

        public ObservableCollection<IncomingByDate> IncomingList { get; }

        public float TotalPersonalEarnings { get; private set; }

        public float EarningPercent { get; set; }
    }
}
