using Full_Metal_Planete.src.decorators;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Full_Metal_Planete.src.user_controls
{
    /// <summary>
    /// Logique d'interaction pour UnitListView.xaml
    /// </summary>
    public partial class UnitListView : UserControl
    {
        private ObservableCollection<Unit> units;

        public ObservableCollection<Unit> Entities => units;

        public UnitListView()
        {
            InitializeComponent();
            units = new ObservableCollection<Unit>();
            playersListView.ItemsSource = units;
        }

        public void AddUnit(Unit unitIHM)
        {
            units.Add(unitIHM);
        }

        public void RemoveUnit()
        {
            units.Remove((Unit)playersListView.SelectedItem);
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (e.LeftButton == MouseButtonState.Pressed && playersListView.SelectedItem != null)
            {
                Unit unitIHM = (Unit)playersListView.SelectedItem;
                DataObject data = new DataObject();
                data.SetData("Object", unitIHM);
                data.SetData("TypeEntite", unitIHM.Type);
                DragDrop.DoDragDrop(this, data, DragDropEffects.Move);
            }
        }

        private void playersListView_RequestBringIntoView(object sender, RequestBringIntoViewEventArgs e)
        {
            e.Handled = true;
        }
    }
}
