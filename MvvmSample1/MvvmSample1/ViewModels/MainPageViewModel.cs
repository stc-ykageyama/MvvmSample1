using System.ComponentModel;
using MvvmSample1.Models;
using Xamarin.Forms;

namespace MvvmSample1.ViewModels
{
    /// <summary>
    /// MainPageのViewModel
    /// </summary>
    class MainPageViewModel : INotifyPropertyChanged
    {
        // プロパティ変更後に発生させるイベントハンドラ
        public event PropertyChangedEventHandler PropertyChanged;

        // プロパティ
        private int number;
        public int Number
        {
            get { return number; }
            set
            {
                number = value;
                OnPropertyChanged(nameof(Number));
            }
        }

        // デクリメントコマンド
        public Command DecrementCommand { get; }

        // インクリメントコマンド
        public Command IncrementCommand { get; }

        // モデル
        private Counter model = new Counter();

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public MainPageViewModel()
        {
            // モデルのイベントハンドラ登録
            // ★このサンプルではプロパティが1個だからいいけど、プロパティがたくさんあると記述が大変！
            model.PropertyChanged += (sender, e) =>
            {
                switch (e.PropertyName)
                {
                    case nameof(Counter.Number):
                        Number = ((Counter)sender).Number;
                        break;
                }
            };
            // デクリメントコマンド実行時の処理
            DecrementCommand = new Command(() => model.Decrement());
            // インクリメントコマンド実行時の処理
            IncrementCommand = new Command(() => model.Increment());
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
