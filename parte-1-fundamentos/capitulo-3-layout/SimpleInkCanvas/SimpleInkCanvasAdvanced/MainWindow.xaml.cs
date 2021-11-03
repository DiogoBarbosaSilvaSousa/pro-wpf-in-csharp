using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SimpleInkCanvasAdvanced
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            LoadComboBox();

        }

        /// <summary>
        /// Método para carregar os dados no ComboBox
        /// </summary>
        private void LoadComboBox()
        {
            inkCanvasComboBox.Items.Add(InkCanvasEditingMode.None.ToString());
            inkCanvasComboBox.Items.Add(InkCanvasEditingMode.Ink.ToString());
            inkCanvasComboBox.Items.Add(InkCanvasEditingMode.GestureOnly.ToString());
            inkCanvasComboBox.Items.Add(InkCanvasEditingMode.InkAndGesture.ToString());
            inkCanvasComboBox.Items.Add(InkCanvasEditingMode.Select.ToString());
            inkCanvasComboBox.Items.Add(InkCanvasEditingMode.EraseByPoint.ToString());
            inkCanvasComboBox.Items.Add(InkCanvasEditingMode.EraseByStroke.ToString());

        }

        /// <summary>
        /// Evento que é disparado toda vez que o ComboBox é alterao trocando o valor
        /// do EditingMode para o InkCanvas.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void inkCanvasComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Console.WriteLine(inkCanvasComboBox.SelectedItem);
            string itemSelect = inkCanvasComboBox.SelectedItem.ToString();

            if (InkCanvasEditingMode.None.ToString() == itemSelect)
            {
                inkCanvas.EditingMode = InkCanvasEditingMode.None;
            }

            if (InkCanvasEditingMode.Ink.ToString() == itemSelect)
            {
                inkCanvas.EditingMode = InkCanvasEditingMode.Ink;
            }

            if (InkCanvasEditingMode.GestureOnly.ToString() == itemSelect)
            {
                inkCanvas.EditingMode = InkCanvasEditingMode.GestureOnly;
            }

            if (InkCanvasEditingMode.InkAndGesture.ToString() == itemSelect)
            {
                inkCanvas.EditingMode = InkCanvasEditingMode.InkAndGesture;
            }

            if (InkCanvasEditingMode.Select.ToString() == itemSelect)
            {
                inkCanvas.EditingMode = InkCanvasEditingMode.Select;
            }

            if (InkCanvasEditingMode.EraseByPoint.ToString() == itemSelect)
            {
                inkCanvas.EditingMode = InkCanvasEditingMode.EraseByPoint;
            }


            if (InkCanvasEditingMode.EraseByStroke.ToString() == itemSelect)
            {
                inkCanvas.EditingMode = InkCanvasEditingMode.EraseByStroke;
            }
        }
    }
}
