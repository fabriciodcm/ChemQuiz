using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;


namespace ChemQuiz.ViewModels
{
    public class QuizGroup<TKey, TItem> : ObservableCollection<TItem>
    {
        public TKey Key { get; private set; }

        public QuizGroup(TKey key, IEnumerable<TItem> items) {
            this.Key = key;
            foreach (var item in items)
                this.Items.Add(item);
        }
    }
}
