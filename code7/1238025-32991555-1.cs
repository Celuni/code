    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Windows;
    namespace StackOverflow2
    {
    public partial class MainWindow : Window
    {
        readonly Dictionary<string, int> _dictionary;
        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
            List = new ObservableCollection<MyItem>();
            _dictionary = new Dictionary<string, int>();
                
            //bogus initial dictionary fill
            for (int i = 0; i < 2000; i++)
            {
                _dictionary.Add("Key_"+i,i+1);
            }
        }
        private int someValue = 10;
        public void Fillcollection()
        {
            Task.Factory.StartNew(() =>
            {
                foreach (KeyValuePair<string, int> item in _dictionary.OrderByDescending(value => value.Value))
                {
                    decimal value = ((decimal)item.Value / someValue) * 100;
                    MyItem myItem = new MyItem { IP = item.Key, Packets = item.Value, Percent = value };
                    this.Dispatcher.Invoke(()=>List.Insert(0,myItem));
                    Thread.Sleep(50);
                }
            });
        }
        public ObservableCollection<MyItem> List { get; set; }
        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            Fillcollection();
        }
    }
    public class MyItem
    {
        public string IP { get; set; }
        public int Packets { get; set; }
        public decimal Percent { get; set; }
    }
   }
    <Window x:Class="StackOverflow2.MainWindow"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
        xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
        xmlns:local="clr-namespace:StackOverflow2"
        mc:Ignorable="d"
        d:DataContext="{d:DesignInstance {x:Type local:MainWindow}}"
        Title="MainWindow" Height="350" Width="525">
        <Grid>
        <Grid.ColumnDefinitions>
            <ColumnDefinition Width="Auto"/>
            <ColumnDefinition Width="*"/>
        </Grid.ColumnDefinitions>
        <Button Content="FillCollection" Click="ButtonBase_OnClick" ></Button>
        <DataGrid ItemsSource="{Binding List}" Grid.Column="1" AutoGenerateColumns="True"></DataGrid>
    </Grid>
    </Window>
