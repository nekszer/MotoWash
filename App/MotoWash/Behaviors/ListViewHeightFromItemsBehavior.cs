using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Text;
using Xamarin.Forms;

namespace MotoWash.Behaviors
{
    public class ListViewHeightFromItemsBehavior<T> : Behavior<ListView>
    {
        public double RowHeight { get; set; }
        public ListView List { get; set; }

        protected override void OnAttachedTo(ListView bindable)
        {
            base.OnAttachedTo(bindable);
            List = bindable;
            List.PropertyChanged += Bindable_PropertyChanged;
        }

        protected override void OnDetachingFrom(ListView bindable)
        {
            base.OnDetachingFrom(bindable);
            List.PropertyChanged -= Bindable_PropertyChanged;
        }

        private void Bindable_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName != ListView.ItemsSourceProperty.PropertyName) return;
            var source = (sender as ListView).ItemsSource;
            if (source is ObservableCollection<T> notifyCollectionChanged)
            {
                SetSize(notifyCollectionChanged.Count);
                notifyCollectionChanged.CollectionChanged += NotifyCollectionChanged_CollectionChanged;
            }
        }

        private void SetSize(int count)
        {
            List.HeightRequest = count * RowHeight;
        }

        private void NotifyCollectionChanged_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if(sender is ObservableCollection<T> collection)
                SetSize(collection.Count);
        }
    }
}
