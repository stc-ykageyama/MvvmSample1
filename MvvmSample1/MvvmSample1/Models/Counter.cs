using System.ComponentModel;

namespace MvvmSample1.Models
{
    /// <summary>
    /// カウンター
    /// </summary>
    class Counter : INotifyPropertyChanged
    {
        // プロパティ変更後に発生させるイベントハンドラ
        public event PropertyChangedEventHandler PropertyChanged;

        // プロパティ
        private int number;
        public int Number
        {
            get { return number; }
            // setは外部からできないようする
            private set
            {
                number = value;
                OnPropertyChanged(nameof(Number));
            }
        }

        /// <summary>
        /// Numberをデクリメント(-1)する
        /// </summary>
        public void Decrement()
        {
            Number -= 1;
        }

        /// <summary>
        /// Numberをインクリメント(+1)する
        /// </summary>
        public void Increment()
        {
            Number += 1;
        }

        /// <summary>
        /// プロパティ変更を通知する
        /// </summary>
        /// <param name="propertyName">プロパティ名</param>
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
