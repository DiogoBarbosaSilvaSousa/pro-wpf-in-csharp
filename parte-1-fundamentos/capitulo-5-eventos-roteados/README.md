# Eventos Roteados

Todo desenvolvedor .NET está familiarizado com a ideia de ***eventos (events)*** - mensagens que são enviadas por um objeto (como um Elemento WPF) para notificar seu código quando algo significativo ocorrer. WPF aprimora o evento .NET modelo com o conceito de ***roteamento de eventos (event routing)***. O roteamento de eventos permite que um evento se origine em um elemento, mas seja criado por outro. Por exemplo, o roteamento de eventos permite que um clique que começa em um botão da barra de ferramentas suba para a barra de ferramentas e, em seguida, para a janela que o contém antes de ser tratado pelo seu código. O roteamento de eventos oferece a flexibilidade de escrever um código bem organizado que lida com eventos no lugar mais conveniente. Também é uma necessidade para trabalhar com o modelo de conteúdo WPF, que permite você construir elementos simples (como um botão) com dezenas de ingredientes distintos, cada um com seu próprio conjunto independente de eventos.

## Bubbling Events (Eventos borbulhantes)

***Arquivo MainWindow.xaml***
```
<Window x:Class="BubbledLabelClick.MainWindow"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
        xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
        xmlns:local="clr-namespace:BubbledLabelClick"
        mc:Ignorable="d"
        Title="BubbledLabelClick" Height="550" Width="400" MouseUp="SomethingClicked">
    <Grid Margin="3" MouseUp="SomethingClicked">
        <Grid.RowDefinitions>
            <RowDefinition Height="Auto"></RowDefinition>
            <RowDefinition Height="*"></RowDefinition>
            <RowDefinition Height="Auto"></RowDefinition>
            <RowDefinition Height="Auto"></RowDefinition>
        </Grid.RowDefinitions>

        <Label Margin="5" Grid.Row="0" HorizontalAlignment="Left"  Background="AliceBlue" BorderBrush="Black" BorderThickness="1"
 MouseUp="SomethingClicked">
            <StackPanel MouseUp="SomethingClicked">
                <TextBlock Margin="3"  MouseUp="SomethingClicked">
                    Rótulo de imagem e texto
                </TextBlock>
                <Image Source="/components/Images/happyface.png" Stretch="Fill"  MouseUp="SomethingClicked" Width="50" Height="50"/>
                <TextBlock Margin="3"  MouseUp="SomethingClicked">
                    Cortesia do StackPanel
                </TextBlock>
            </StackPanel>
        </Label>

        <ListBox Grid.Row="1" Margin="5" Name="lstMessages"></ListBox>
        <CheckBox Grid.Row="2" Margin="5" Name="chkHandle">
            Manipulando o primeiro evento
        </CheckBox>
        <Button Grid.Row="3" Margin="5" Padding="3" HorizontalAlignment="Right" Name="cmdClear" Click="cmdClear_Click">Limpar lista</Button>
    </Grid>
</Window>
```

***Arquivo MainWindow.xaml.cs***
```
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

namespace BubbledLabelClick
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        protected int eventCounter = 0;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void SomethingClicked(object sender, MouseButtonEventArgs e)
        {
            eventCounter++;
            string message = "#" + eventCounter.ToString() + ":\r\n" +
            " Sender(Remetente): " + sender.ToString() + "\r\n" +
            " Source(Fonte): " + e.Source + "\r\n" +
            " Original Source(Fonte original): " + e.OriginalSource;
            lstMessages.Items.Add(message);
            e.Handled = (bool)chkHandle.IsChecked;

        }

        private void cmdClear_Click(object sender, RoutedEventArgs e)
        {
            lstMessages.Items.Clear();
        }
    }
}

```
