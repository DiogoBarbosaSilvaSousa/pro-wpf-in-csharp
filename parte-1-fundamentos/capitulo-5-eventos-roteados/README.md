# Eventos Roteados

Todo desenvolvedor .NET está familiarizado com a ideia de ***eventos (events)*** - mensagens que são enviadas por um objeto (como um Elemento WPF) para notificar seu código quando algo significativo ocorrer. WPF aprimora o evento .NET modelo com o conceito de ***roteamento de eventos (event routing)***. O roteamento de eventos permite que um evento se origine em um elemento, mas seja criado por outro. Por exemplo, o roteamento de eventos permite que um clique que começa em um botão da barra de ferramentas suba para a barra de ferramentas e, em seguida, para a janela que o contém antes de ser tratado pelo seu código. O roteamento de eventos oferece a flexibilidade de escrever um código bem organizado que lida com eventos no lugar mais conveniente. Também é uma necessidade para trabalhar com o modelo de conteúdo WPF, que permite você construir elementos simples (como um botão) com dezenas de ingredientes distintos, cada um com seu próprio conjunto independente de eventos.

## Bubbling Events (Eventos borbulhantes)

A Figura abaixo mostra uma janela simples que demonstra o borbulhamento de eventos. Quando você clica em uma parte do rótulo, a sequência de eventos é mostrada em uma caixa de listagem. Depois de clicar na imagem no rótulo é exibida a sequência de eventos na Listbox. O evento MouseUp viaja por cinco níveis, terminando no formulário personalizado BubbledLabelClick. Se você deixar o CheckBox "Manipulando o primeieo evento" só exibirá o primeiro evento do clique caso contrário será exibido os cinco eventos como falado anteriormente.

![BubbledLabelClick](https://github.com/DiogoBarbosaSilvaSousa/pro-wpf-in-csharp/blob/main/parte-1-fundamentos/capitulo-5-eventos-roteados/02.png)

***Checkbox Marcado***

![BubbledLabelClick](https://github.com/DiogoBarbosaSilvaSousa/pro-wpf-in-csharp/blob/main/parte-1-fundamentos/capitulo-5-eventos-roteados/01.png)

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

        <Label Margin="5" Grid.Row="0" HorizontalAlignment="Left" Background="AliceBlue" BorderBrush="Black" BorderThickness="1"
 MouseUp="SomethingClicked">
            <StackPanel MouseUp="SomethingClicked">
                <TextBlock Margin="3"  MouseUp="SomethingClicked">
                    Rótulo de imagem e texto
                </TextBlock>
                <Image Source="/components/Images/happyface.png" Stretch="Fill" MouseUp="SomethingClicked" Width="50" Height="50"/>
                <TextBlock Margin="3"  MouseUp="SomethingClicked">
                    Cortesia do StackPanel
                </TextBlock>
            </StackPanel>
        </Label>

        <ListBox Grid.Row="1" Margin="5" Name="lstMessages"></ListBox>
        <CheckBox Grid.Row="2" Margin="5" Name="chkHandle">
            Manipulando o primeiro evento
        </CheckBox>
        <Button Grid.Row="3" Margin="5" Padding="3" HorizontalAlignment="Right" Name="cmdClear" Click="cmdClear_Click">
        Limpar lista
        </Button>
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

## Eventos Anexados (Attached Events)

O exemplo de rótulo extravagante é um exemplo bastante simples de borbulhamento de evento porque todos os elementos apoiam o evento MouseUp. No entanto, muitos controles têm seus próprios eventos mais especializados. O botão é um exemplo - adiciona um evento Click que não é definido por nenhuma classe base. Isso introduz um dilema interessante. Imagine que você envolve uma pilha de botões em um StackPanel. Vocês deseja lidar com todos os cliques de botão em um manipulador de eventos. A abordagem crua é anexar o evento Click de cada botão para o mesmo manipulador de eventos. Mas o evento Click oferece suporte ao borbulhamento de eventos, o que dá a você um melhor opção. Você pode controlar todos os cliques de botão manipulando o evento Click em um nível superior (como o contendo StackPanel).
Infelizmente, esse código aparentemente óbvio não funciona:

```
<StackPanel Click="DoSomething" Margin="5">
 <Button Name="cmd1">Comando 1</Button>
 <Button Name="cmd2">Comando 2</Button>
 <Button Name="cmd3">Comando 3</Button>
</StackPanel>
```

O problema é que o StackPanel não inclui um evento Click, então isso é interpretado pelo analisador XAML como um erro. A solução é usar uma sintaxe de evento anexado diferente na forma ***ClassName.EventName*** . Aqui está o exemplo corrigido:

```
<StackPanel  Button.Click="DoSomething" Margin="5">
        <Button Name="cmd1" Tag="The first button." Margin="5">Comando 1</Button>
        <Button Name="cmd2" Tag="The second button." Margin="5">Comando 2</Button>
        <Button Name="cmd3" Tag="The third button." Margin="5">Comando 3</Button>
</StackPanel>
```

***Código do método usado na chamada de evento ali eu mostro duas formas de capturar informações uma através do Name do Button outra acessando uma de suas propriedades***

```
private void DoSomething(object sender, RoutedEventArgs e)
{
            Button cmd = (Button)e.OriginalSource;
            MessageBox.Show((string)cmd.Tag);

            if (e.Source == cmd1)
            { MessageBox.Show("cmd1"); }
            else if (e.Source == cmd2)
            { MessageBox.Show("cmd2"); }
            else if (e.Source == cmd3)
            { MessageBox.Show("cmd3"); }
}
```

![AttachedEvents](https://github.com/DiogoBarbosaSilvaSousa/pro-wpf-in-csharp/blob/main/parte-1-fundamentos/capitulo-5-eventos-roteados/03.png)

## Tunneling Events (Eventos de tunelamento)

Os eventos de túnel funcionam da mesma forma que os eventos de bolha, mas na direção oposta. Por exemplo, se MouseUp era um evento encapsulado (o que não é), clicar na imagem no exemplo de rótulo extravagante causaria MouseUp para disparar primeiro na janela, depois no Grid, depois no StackPanel e assim por diante, até atingir o fonte real, que é a imagem no rótulo. 
Os eventos de encapsulamento são fáceis de reconhecer porque começam com a palavra ***Preview***. Além disso o WPF geralmente define eventos de bubbling e tunneling em pares. Isso significa que se você encontrar um evento Borbulhante de MouseUp, você provavelmente também pode encontrar um evento PreviewMouseUp de tunelamento. O evento de tunelamento sempre dispara antes do evento de borbulhamento, conforme mostrado na Figura.

![Contexto dos eventos](https://github.com/DiogoBarbosaSilvaSousa/pro-wpf-in-csharp/blob/main/parte-1-fundamentos/capitulo-5-eventos-roteados/04.png)
